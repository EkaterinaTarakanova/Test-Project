using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private int minutes = 1;
    [SerializeField] private int seconds = 30;
    [SerializeField] private Text timerText;
    private float currentTime;

    void Start()
    {
        currentTime = minutes * 60 + seconds;
        UpdateTimerText();
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
            UpdateTimerText();

            if (currentTime <= 0)
                SceneManager.LoadScene(1);
        }
    }

    private void UpdateTimerText()
    {
        int minutesRemaining = Mathf.FloorToInt(currentTime / 60);
        int secondsRemaining = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutesRemaining, secondsRemaining);
    }
}

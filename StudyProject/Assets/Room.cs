using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudyProject 
{
    public class Room : MonoBehaviour
    {
        [SerializeField] private GameObject[] doors;

        public void UpdateRoom(bool[] wallStates)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].SetActive(!wallStates[i]);
            }
        }
    }

}

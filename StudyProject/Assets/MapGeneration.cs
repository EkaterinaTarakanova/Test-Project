using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StudyProject 
{
    public class MapGeneration : MonoBehaviour
    {
        [SerializeField] private Vector2Int size;
        [SerializeField] private int startPos;
        [SerializeField] private Room room;
        [SerializeField] private Vector2 offset;
        private List<Cell> board;

        private void Start()
        {
            GenerateMaze();
        }

        private void GenerateDungeon()
        {
            for (int i = 0; i < size.x; i++)
            {
                for (int j = 0; j < size.y; j++)
                {
                    var currentCell = board[i + j * size.x];

                    if (currentCell.IsVisited)
                    {
                        var newRoom = Instantiate(room, new Vector2(i * offset.x, -j * offset.y), Quaternion.identity);
                        newRoom.UpdateRoom(currentCell.Status);
                    }
                }
            }
        }

        private void GenerateMaze()
        {
            InitializeMaze();

            var currentCell = startPos;
            var path = new Stack<int>();

            while (true)
            {
                board[currentCell].IsVisited = true;

                if ((currentCell == board.Count - 1))
                {
                    break;
                }

                var neighbors = GetNeighbors(currentCell);

                if (neighbors.Count == 0)
                {
                    if (path.Count == 0)
                    {
                        break;
                    }

                    else
                    {
                        currentCell = path.Pop();
                    }
                }

                else
                {
                    path.Push(currentCell);

                    var newCell = neighbors[Random.Range(0, neighbors.Count)];

                    GetCellStatus(currentCell, newCell);
                    currentCell = newCell;
                }
            }

            GenerateDungeon();
        }

        private void InitializeMaze()
        {
            board = new List<Cell>();
            InitializeBoard(size);
        }

        private void GetCellStatus(int currentCell, int newCell)
        {
            if (newCell > currentCell)
            {
                if (newCell - 1 == currentCell)
                {
                    board[currentCell].Status[2] = true;
                    currentCell = newCell;
                    board[currentCell].Status[3] = true;
                }

                else
                {
                    board[currentCell].Status[1] = true;
                    currentCell = newCell;
                    board[currentCell].Status[0] = true;
                }
            }

            else
            {
                if (newCell + 1 == currentCell)
                {
                    board[currentCell].Status[3] = true;
                    currentCell = newCell;
                    board[currentCell].Status[2] = true;
                }

                else
                {
                    board[currentCell].Status[0] = true;
                    currentCell = newCell;
                    board[currentCell].Status[1] = true;
                }
            }
        }

        private void InitializeBoard(Vector2Int size)
        {
            board = Enumerable.Range(0, size.x * size.y).Select(x => new Cell()).ToList();
        }

        private List<int> GetNeighbors(int cell)
        {
            var neighbors = new List<int>();

            if (cell - size.x >= 0 && !board[cell - size.x].IsVisited)
                neighbors.Add(cell - size.x);

            if (cell + size.x < board.Count && !board[cell + size.x].IsVisited)
                neighbors.Add(cell + size.x);

            if (cell % size.x != 0 && !board[cell - 1].IsVisited)
                neighbors.Add(cell - 1);

            if ((cell + 1) % size.x != 0 && !board[cell + 1].IsVisited)
                neighbors.Add(cell + 1);

            return neighbors;
        }
    }
}

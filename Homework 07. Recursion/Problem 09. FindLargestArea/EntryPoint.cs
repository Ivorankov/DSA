using System;
using System.Collections.Generic;

namespace Problem_09.FindLargestArea
{
    class EntryPoint
    {
        static void Main()
        {
            FindLargestConnectingPath(0, 0);

            Console.WriteLine(bestArea.Count);

            Console.ReadKey();
        }

        private static char[,] maze = 
    {
        {' ', ' ', ' ', '|', ' ', ' ', ' '},
        {' ', ' ', '|', '|', ' ', '|', ' '},
        {' ', ' ', '|', '|', 'e', '|', ' '},
        {' ', ' ', '|', '|', '|', '|', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' '},
    };

        private static List<Tuple<int, int>> path = new List<Tuple<int, int>>();

        private static List<Tuple<int, int>> bestArea = new List<Tuple<int, int>>();

        private static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < maze.GetLength(0);
            bool colInRange = col >= 0 && col < maze.GetLength(1);
            return rowInRange && colInRange;
        }

        private static void FindLargestConnectingPath(int row, int col)
        {
            if (!InRange(row, col))
            {
                return;
            }

            if (maze[row, col] == 'e')
            {
                PrintPath();
            }

            if (maze[row, col] != ' ')
            {
                return;
            }

            maze[row, col] = 's';
            path.Add(new Tuple<int, int>(row, col));

            FindLargestConnectingPath(row, col - 1); // left
            FindLargestConnectingPath(row - 1, col); // up
            FindLargestConnectingPath(row, col + 1); // right
            FindLargestConnectingPath(row + 1, col); // down

            maze[row, col] = ' ';
            path.RemoveAt(path.Count - 1);
        }

        private static void PrintPath()
        {
            if (bestArea.Count < path.Count)
            {
                bestArea = new List<Tuple<int, int>>(path);
            }
        }
    }
}

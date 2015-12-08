using System;
using System.Collections.Generic;

namespace Problem_07.PathsInMatrix
{
    class EntryPoint
    {
        static void Main()
        {
            FindPathToExit(0, 0);

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

        static List<Tuple<int, int>> path = new List<Tuple<int, int>>();

        private static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < maze.GetLength(0);
            bool colInRange = col >= 0 && col < maze.GetLength(1);
            return rowInRange && colInRange;
        }

        private static void FindPathToExit(int row, int col)
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

            FindPathToExit(row, col - 1); // left
            FindPathToExit(row - 1, col); // up
            FindPathToExit(row, col + 1); // right
            FindPathToExit(row + 1, col); // down

            maze[row, col] = ' ';
            path.RemoveAt(path.Count - 1);
        }

        private static void PrintPath()
        {
            Console.Write("Found the exit in " + path.Count + " steps");
            Console.WriteLine();
            var temp = maze;


            foreach (var cell in path)
            {
                temp[cell.Item1, cell.Item2] = '0';
            }

            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    Console.Write(temp[i,j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}

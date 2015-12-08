namespace Problem_08.CheckIfPathExists
{
    using System;
    using System.Collections.Generic;

    internal class EntryPoint
    {
        static void Main()
        {
            maze = new char[100,100];
            FindPathToExit(0, 0);

            Console.ReadKey();
        }

        private static char[,] maze;

        private static int targetRow = 50;

        private static int targetCol = 50;

        private static List<Tuple<int, int>> path = new List<Tuple<int, int>>();

        private static bool isPathClear = false;

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

            if (isPathClear)
            {
                return;
            }

            if (row == targetRow && col == targetCol)
            {
                Console.WriteLine("Found a clear path");
                isPathClear = true;
                return;
            }

            if (maze[row, col] != 0)
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
    }
}

namespace Problem_13.Maze
{
    using System;
    using System.Collections.Generic;

    public class Matrix
    {
        private static string[,] matrix = 
        { 
            { "0", "0", "0", "x", "0", "x" },
            { "0", "x", "0", "x", "0", "x" },
            { "0", "*", "x", "0", "x", "0" },
            { "0", "x", "0", "0", "0", "0" },
            { "0", "0", "0", "x", "x", "0" },
            { "0", "0", "0", "x", "0", "x" } 
        };

        private static int startPointRow = 2;

        private static int startPointCol = 1;

        static void Main()
        {
            Run();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "  ");
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }

        private static void Run()
        {
            var currentRow = 0;
            var currentCol = 0;
            var pointsToCheck = new Stack<int[]>();
            var currentNumber = 0;
            pointsToCheck.Push(new int[3] { startPointRow, startPointCol, 0 });

            while (pointsToCheck.Count != 0)
            {
                var currentPoint = pointsToCheck.Pop();
                currentRow = currentPoint[0];
                currentCol = currentPoint[1];
                currentNumber = currentPoint[2];
                var temp = 0;

                matrix[currentRow, currentCol] = currentNumber++.ToString(); 

                temp = currentCol;
                temp++;
                if (CanMoveCol(temp))
                {
                    if (IsPathClear(currentRow, temp))
                    {
                        pointsToCheck.Push(new int[] { currentRow, currentCol + 1, currentNumber });
                    }

                }

                temp = currentCol;
                temp--;
                if (CanMoveCol(temp))
                {
                    if (IsPathClear(currentRow, temp))
                    {
                        pointsToCheck.Push(new int[] { currentRow, currentCol - 1, currentNumber });
                    }

                }

                temp = currentRow;
                temp++;
                if (CanMoveRow(temp))
                {
                    if (IsPathClear(temp, currentCol))
                    {

                        pointsToCheck.Push(new int[] { currentRow + 1, currentCol, currentNumber });
                    }

                }

                temp = currentRow;
                temp--;
                if (CanMoveRow(temp))
                {
                    if (IsPathClear(temp, currentCol))
                    {

                        pointsToCheck.Push(new int[] { currentRow - 1, currentCol, currentNumber });
                    }

                }
            }
        }

        private static bool IsPathClear(int row, int col)
        {
            return matrix[row, col] == "0";
        }

        private static bool CanMoveCol(int index)
        {
            if (index < 0)
            {
                return false;
            }
            else if (index > matrix.GetLength(1) - 1)
            {
                return false;
            }
            return true;
        }

        private static bool CanMoveRow(int index)
        {
            if (index < 0)
            {
                return false;
            }
            else if (index > matrix.GetLength(0) - 1)
            {
                return false;
            }
            return true;
        }
    }
}
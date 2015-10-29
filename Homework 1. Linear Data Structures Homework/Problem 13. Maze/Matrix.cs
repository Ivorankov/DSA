using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Problem_13.Maze
{
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

        static void Main()
        {
            Run();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
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
            pointsToCheck.Push(new int[3] { 2, 1, 1 });

            while (pointsToCheck.Count != 0)
            {
                var currentPoint = pointsToCheck.Pop();
                currentRow = currentPoint[0];
                currentCol = currentPoint[1];
                currentNumber = currentPoint[2];
                var temp = 0;
                var hasMoved = false;

                temp = currentCol;
                temp++;
                if (CanMoveCol(temp))
                {
                    if (IsPathClear(currentRow, temp))
                    {
                        matrix[currentRow, currentCol] = currentNumber++.ToString();
                        currentCol++;
                        pointsToCheck.Push(new int[] { currentRow, currentCol, currentNumber });
                    }

                    hasMoved = true;
                }

                temp = currentCol;
                temp--;
                if (CanMoveCol(temp))
                {
                    if (IsPathClear(currentRow, temp))
                    {
                        matrix[currentRow, currentCol] = currentNumber++.ToString();
                        currentCol--;
                        pointsToCheck.Push(new int[] { currentRow, currentCol, currentNumber });
                    }

                    hasMoved = true;
                }

                temp = currentRow;
                temp++;
                if (CanMoveRow(temp))
                {
                    if (IsPathClear(temp, currentCol))
                    {
                        matrix[currentRow, currentCol] = currentNumber++.ToString();
                        currentRow++;
                        pointsToCheck.Push(new int[] { currentRow, currentCol, currentNumber });
                    }

                    hasMoved = true;
                }

                temp = currentRow;
                temp--;
                if (CanMoveRow(temp))
                {
                    if (IsPathClear(temp, currentCol))
                    {
                        matrix[currentRow, currentCol] = currentNumber++.ToString();
                        currentRow--;
                        pointsToCheck.Push(new int[] { currentRow, currentCol, currentNumber });
                    }

                    hasMoved = true;
                }

                if (hasMoved)
                {
                    matrix[currentRow, currentCol] = currentNumber.ToString(); ;
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

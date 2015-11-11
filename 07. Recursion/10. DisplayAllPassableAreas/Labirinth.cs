﻿namespace DisplayAllPassableAreas
{
    using System;
    using System.Collections.Generic;

    public class Labirinth
    {
        private const char NotPassable = 'x';
        private const char Visited = 'o';
        private const char Passable = '*';
        private const char Exit = 'E';
        private const char Start = 's';
        private char[,] matrix;
        private char[,] displayedPassableCells;
        private int lastDisplayedCellsCounter = 0;
        private int displayedCellsCounter = 0;
        private List<char> directions = new List<char>();

        public Labirinth(char[,] matrix)
        {
            this.matrix = matrix;
            this.displayedPassableCells = new char[this.matrix.GetLength(0), this.matrix.GetLength(1)];
            long copiedCells = this.matrix.GetLength(0) * this.matrix.GetLength(1);
            Array.Copy(this.matrix, this.displayedPassableCells, copiedCells);
        }

        public void FindConnectedAreas()
        {
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    this.TraverseAreaFromPosition(i, j);
                    if (this.lastDisplayedCellsCounter != this.displayedCellsCounter)
                    {
                        int displayeAreaCellsCounter = this.displayedCellsCounter - this.lastDisplayedCellsCounter;
                        Console.WriteLine("\nElements contained: {0}\n", displayeAreaCellsCounter);
                        this.PrintArea();
                    }

                    this.lastDisplayedCellsCounter = this.displayedCellsCounter;
                }
            }
        }

        public bool FindPaths(int row, int col, int endRow, int endCol, char direction)
        {
            if (!this.CheckRowAndCol(row, col))
            {
                return false;
            }

            if (this.matrix[row, col] == NotPassable ||
                    this.matrix[row, col] == Visited)
            {
                return false;
            }

            this.directions.Add(direction);
            if (row == endRow && col == endCol)
            {
                return true;
            }

            this.MarkCurrent(row, col);

            // up
            if (this.FindPaths(row - 1, col + 0, endRow, endCol, 'U'))
            {
                return true;
            }

            // right
            if (this.FindPaths(row + 0, col + 1, endRow, endCol, 'R'))
            {
                return true;
            }

            // down
            if (this.FindPaths(row + 1, col + 0, endRow, endCol, 'D'))
            {
                return true;
            }

            // left
            if (this.FindPaths(row + 0, col - 1, endRow, endCol, 'L'))
            {
                return true;
            }

            return false;
        }

        private void TraverseAreaFromPosition(int row, int col)
        {
            if (!this.CheckRowAndCol(row, col))
            {
                return;
            }

            if (this.matrix[row, col] == NotPassable ||
                    this.matrix[row, col] == Visited)
            {
                return;
            }

            this.matrix[row, col] = Visited;
            this.displayedCellsCounter++;

            this.TraverseAreaFromPosition(row - 1, col + 0); // up
            this.TraverseAreaFromPosition(row + 0, col + 1); // right
            this.TraverseAreaFromPosition(row + 1, col + 0); // down
            this.TraverseAreaFromPosition(row + 0, col - 1); // left
        }

        private void PrintArea()
        {
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                Console.Write("{0} ", row.ToString().PadLeft(2, '0'));
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    if (this.matrix[row, col] == Visited && this.displayedPassableCells[row, col] != Visited)
                    {
                        this.displayedPassableCells[row, col] = Visited;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(this.matrix[row, col]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (this.matrix[row, col] != Visited)
                    {
                        Console.Write(this.matrix[row, col]);
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private bool CheckRowAndCol(int row, int col)
        {
            bool isRowCorrect = 0 <= row && row < this.matrix.GetLength(0);
            bool isColCorrect = 0 <= col && col < this.matrix.GetLength(1);
            if (!isRowCorrect || !isColCorrect)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void UnmarkCurrent(int row, int col)
        {
            this.matrix[row, col] = Passable;
        }

        private void MarkCurrent(int row, int col)
        {
            this.matrix[row, col] = Visited;
        }

        private void PrintPath()
        {
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    Console.Write(" " + this.matrix[row, col]);
                }

                Console.WriteLine();
            }

            Console.WriteLine(string.Join(">", this.directions));
        }
    }
}

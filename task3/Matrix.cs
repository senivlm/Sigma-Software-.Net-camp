using System;
using System.Collections.Generic;
using System.Text;

namespace task2
{
    class Matrix
    {
        public enum StartAngle { Right,Down}
        int[,] matrix;
        int rowCount;
        public int Rows
        {
            get { return rowCount; }
            set { _ = value > 0 ? rowCount = value : rowCount = 0; }
        }
        int colCount;
        public int Columns
        {
            get { return colCount; }
            set { _ = value > 0 ? colCount = value : colCount = 0; }
        }
        public Matrix(int n,int m)
        {
            Rows = n;
            Columns = m;
            matrix = new int[n, m];
        }
        public void Input()
        {
            Console.WriteLine("Введіть кількість рядків матриці");
            Rows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть кількість стовпців матриці ");
            Columns = Convert.ToInt32(Console.ReadLine());
            matrix = new int[Rows, Columns];
        }
        public void FillVerticalSnake()
        {
            int number = 1;
            for (int column = 0; column < Columns; column++)
            {
                if (column % 2 == 0)
                {
                    int i1 = 0, j1 = column;
                    for (int i = 0; i < Rows; i++)
                    {
                        matrix[i1, j1] = number++;
                        i1++;
                    }
                }
                else
                {
                    int i1 = Rows-1, j1 = column;
                    for (int i = 0; i < Rows; i++)
                    {
                        matrix[i1, j1] = number++;
                        i1--;
                    }
                }
            }
        }
        public void FillDiagonalSnake()
        {
            if (Rows == Columns)
            {
                int number = 1;
                for (int line = 0; line < Rows; line++)
                {
                    if (line % 2 == 0)
                    {
                        int i1 = line, j1 = 0;
                        for (int i = 0; i < line + 1; i++)
                        {
                            matrix[i1, j1] = number++;
                            matrix[Rows - i1 - 1, Rows - j1 - 1] = (Rows * Rows - number + 2);
                            i1--;
                            j1++;
                        }
                    }
                    else
                    {
                        int i1 = 0, j1 = line;
                        for (int i = 0; i < line + 1; i++)
                        {
                            matrix[i1, j1] = number++;
                            matrix[Rows - i1 - 1, Rows - j1 - 1] = (Rows * Rows - number + 2);
                            j1--;
                            i1++;
                        }
                    }
                }
            }
        }
        public void FillDiagonalSnake(StartAngle angle=StartAngle.Right)
        {
            if (angle == StartAngle.Right)
                FillDiagonalSnake();
           
            else if(angle == StartAngle.Down)
            {
                if (Rows == Columns)
                {
                    int number = 1;
                    for (int line = 0; line < Rows; line++)
                    {
                        if (line % 2 == 0)
                        {
                            int i1 = line, j1 = 0;
                            for (int i = 0; i < line + 1; i++)
                            {
                                matrix[j1, i1] = number++;
                                matrix[Rows - i1 - 1, Rows - j1 - 1] = (Rows * Rows - number + 2);
                                i1--;
                                j1++;
                            }
                        }
                        else
                        {
                            int i1 = 0, j1 = line;
                            for (int i = 0; i < line + 1; i++)
                            {
                                matrix[j1, i1] = number++;
                                matrix[Rows - i1 - 1, Rows - j1 - 1] = (Rows * Rows - number + 2);
                                j1--;
                                i1++;
                            }
                        }
                    }
                }
            }
        }
        public void FillSpiralSnake()
        {
            int number = 1;
            int col_up = Columns;
            int col_lower = 0;
            int row_up = Rows;
            int row_lower = 0;
            while (row_lower < row_up)
            {
                 
                for(int i = row_lower;i<row_up-1;i++)
                {
                    matrix[i, col_lower] = number++;
                }
                row_up--;
                for (int i = col_lower; i < col_up-1; i++)
                {
                    matrix[row_up, i] = number++;
                }
                col_up--;
                for (int i = row_up; i > row_lower-1; i--)
                {
                    matrix[i,col_up] = number++;
                }
                col_lower++;
                for (int i = col_up-1; i > col_lower-1; i--)
                {
                    matrix[row_lower,i] = number++;
                }
                row_lower++;
            }
        }
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < Rows; ++i)
            {
                for (int j = 0; j < Columns; ++j)
                {
                    res += String.Format("{0,3}", matrix[i, j].ToString());
                }
                res += '\n';
            }
            return res;
        }
    }
}

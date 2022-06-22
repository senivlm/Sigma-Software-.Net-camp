using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10.quest2
{
    internal class MatrixEnumerator : IEnumerator<int>
    {

        int[,] matrix;
        int row = 0;
        int column = -1;

        public MatrixEnumerator(int[,] matrix)
        {
            this.matrix = matrix;
        }

        public int Current
        {
            get
            {
                if (row == -1 || row >= matrix.GetLength(0) || column == -1 || column >= matrix.GetLength(1))
                    throw new ArgumentException();
                return matrix[row, column];
            }
        }
        object IEnumerator.Current => throw new NotImplementedException();
        public bool MoveNext()
        {
            if (row < matrix.GetLength(0) - 1 || column < matrix.GetLength(1) - 1)
            {

                if (row % 2 == 0 )
                {
                    if (column < matrix.GetLength(1) - 1)
                    {
                        column++;
                        return true;
                    }
                }
                else
                {
                    if (column > 0)
                    {
                        column--;
                        return true;
                    }
                }
                if (column >= matrix.GetLength(1)-1 || column <= 0)
                    row++;

                return true;
            }
            else
                return false;
        }
        public void Reset()
        { 
            row = 0; column = -1;
        }
        public void Dispose() { }
    }
    
}

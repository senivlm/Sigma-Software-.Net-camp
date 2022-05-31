using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Vector
    {
        #region base
        int[] arr;

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < arr.Length)
                {
                    return arr[index];
                }
                else
                {
                    throw new Exception("Index out of range array");
                }
            }
            set
            {
                arr[index] = value;
            }
        }

        public Vector(int[] arr)
        {
            this.arr = arr;
        }

        public Vector(int n)
        {
            arr = new int[n];
        }

        public Vector() { }

        public void RandomInitialization(int a, int b)
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(a, b);
            }
        }

        public void RandomInitialization()
        {

            Random random = new Random();
            int x;
            for (int i = 0; i < arr.Length; i++)
            {
                while (arr[i] == 0)
                {
                    x = random.Next(1, arr.Length + 1);
                    bool isExist = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (x == arr[j])
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if (!isExist)
                    {
                        arr[i] = x;
                        break;
                    }
                }
            }
        }

        public Pair[] CalculateFreq()
        {

            Pair[] pairs = new Pair[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                pairs[i] = new Pair(0, 0);

            }
            int countDifference = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDifference; j++)
                {
                    if (arr[i] == pairs[j].Number)
                    {
                        pairs[j].Freq++;
                        isElement = true;
                        break;
                    }
                }
                if (!isElement)
                {
                    pairs[countDifference].Freq++;
                    pairs[countDifference].Number = arr[i];
                    countDifference++;
                }
            }

            Pair[] result = new Pair[countDifference];
            for (int i = 0; i < countDifference; i++)
            {
                result[i] = pairs[i];
            }

            return result;
        }
        #endregion base
        #region task3
        public bool IsPalindrome()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != arr[arr.Length - i - 1])
                    return false;
            }
            return true;
        }
        public void ReverseFromScratch()
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                int temp = arr[i];
                arr[i] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = temp;
            }
        }
        public void ReverseBuiltIn()
        {
            Array.Reverse(arr);
        }
        public Vector FindSubsequence()
        {
            int count = 0, number = 0, maxCount = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] != arr[i - 1])
                    count = 0;

                count++;

                if (count > maxCount)
                {
                    maxCount = count;
                    number = arr[i];
                }
            }
            Vector res = new Vector(maxCount);
            for (int i = 0; i < maxCount; i++)
            {
                res.arr[i] = number;
            }
            return res;
        }
        #endregion task3
        #region sort
        private void Swap(int v1, int v2)
        {
            int temp = arr[v1];
            arr[v1] = arr[v2];
            arr[v2] = temp;
        }
        public Vector BubbleSort()
        {
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = 0; j < arr.Length - i - 1; j++)
                    if (arr[j + 1] > arr[j])
                        Swap(j + 1, j);
            return new Vector(arr);
        }
        #region task4
        public enum Pivot { First, Last, Mid }
        public Vector QuickSort(int low, int high, Pivot pivot)
        {

            if (low < high)
            {
                int pivotIndex;
                pivotIndex = Partition(low, high, pivot);
                QuickSort(low, pivotIndex - 1, pivot);
                QuickSort(pivotIndex + 1, high, pivot);
            }

            return new Vector(arr);
        }
        private int Partition(int low, int high, Pivot p)
        {
            int pivot;
            int i = low;
            int j = high;

            if (p == Pivot.First)
                pivot = arr[low];
            else if (p == Pivot.Last)
                pivot = arr[high];
            else
                pivot = arr[(high+low)/2];
            
            while(true)
            {
                while (arr[i] < pivot) i++;
                while (arr[j] > pivot) j--;
                if (i >= j) return j;
                Swap(i, j);
            }
        }
        #endregion task4

        private void SplitMergeSort(int start, int end)
        {
            if (end - start <= 1)
                return;
            int mid = (end + start) / 2;
            SplitMergeSort(start, mid);
            SplitMergeSort(mid, end);
            Merge(start, end, mid);

        }
        public void SplitMergeSort()
        {
            SplitMergeSort(0, arr.Length);

        }
        private void Merge(int start, int mid, int end)
        {
            int i = start, j = end;
            int[] temp = new int[mid - start];
            int k = 0;
            while (i < end && j < mid)
            {
                if (arr[i] < arr[j])
                    temp[k] = arr[i++];
                else
                    temp[k] = arr[j++];

                k++;
            }
            if (i == end)
                for (int m = j; m < mid; m++)
                    temp[k++] = arr[m];
            else
                while (i < end)
                {
                    temp[k] = arr[i];
                    i++;
                    k++;
                }
            for (int n = 0; n < temp.Length; n++)
                this.arr[n + start] = temp[n];
        }

        #region task5
        int n;
        void ReadFromFile(string filename, int start = 0)
        {
            StreamReader reader = new StreamReader("..\\..\\..\\" + filename);
            string line = reader.ReadLine();
            var strArray = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            n = strArray.Length;
            this.arr = new int[n / 2];
            for (int i = start; start == 0 ? i < n / 2 : i < n; i++)
                arr[i - start] = Convert.ToInt32(strArray[i]);
            reader.Close();
        }
        void SortHalfAndSaveToFile(string filename, int start)
        {
            ReadFromFile(filename, start);
            SplitMergeSort();
            string t = "";
            StreamWriter writer = new StreamWriter("..\\..\\..\\" + "sorted"+(start == 0 ? "FirstHalf" : "SecondHalf")+".txt");
            foreach (var item in arr)
                t += item.ToString()+" ";
           
            writer.WriteLine(t);
            writer.Close();
        }
        public void ExternalMergeSort(string filename)
        {
            SortHalfAndSaveToFile(filename, 0);
            SortHalfAndSaveToFile(filename, n / 2);

            this.arr = new int[0];

            StreamReader first = new StreamReader("..\\..\\..\\" + "sortedFirstHalf.txt");
            StreamReader second = new StreamReader("..\\..\\..\\" + "sortedSecondHalf.txt");
            string line1 = first.ReadLine();
            string line2 = second.ReadLine();
            var firstStrArray = line1.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var secondStrArray = line2.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            first.Close();
            second.Close();

            int[] L = new int[n/2];
            int[] R = new int[n/2];
            for (int m = 0; m < n / 2; m++)
            {
                L[m] = Convert.ToInt32(firstStrArray[m]);
                R[m] = Convert.ToInt32(secondStrArray[m]);
            }
           
            int i = 0;
            int j = 0;
            int k = 0;
            string result = "";
            while (i < n && j < n/2)
            {
                if (L[i] <= R[j])
                {
                    result += L[i].ToString() + " ";
                    i++;
                }
                else
                {
                    result  += R[j].ToString() + " "; 
                    j++;
                }
                k++;
            }
            while (i < n/2)
            {
                result += L[i].ToString() + " ";
                i++;
                k++;
            }
            while (j < n/2)
            {
                result += R[j].ToString() + " ";
                j++;
                k++;
            }

            StreamWriter writer = new StreamWriter("..\\..\\..\\" + "sortedAll.txt");
            writer.WriteLine(result);
            writer.Close();
        }

        private int CreatePyramid(int i, int N)
        {
            int imax;
            if ((2 * i + 1) < N)
            {
                if (arr[2 * i] < arr[2 * i + 1])
                    imax = 2 * i + 1;
                else
                    imax = 2 * i;
            }
            else
                imax = 2 * i;
            if (imax >= N)
                return i;
            if (arr[i] < arr[imax])
            {
                Swap(i, imax);
                if (imax < N / 2)
                    i = imax;
            }
            return i;
        }
        public void PyramidSort()
        {
            int len = arr.Length;
            for (int i = len / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = CreatePyramid( i, len);
                if (prev_i != i) ++i;
            }
            for (int k = len - 1; k > 0; --k)
            {
                Swap(0, k);
                int i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = CreatePyramid(i, k);
                }
            }
        }
        #endregion task5
        #endregion sort


        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i] + " ";
            }
            return str;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Vector
    {
        int[] arr;


        public int this[int index]
        {
            get
            { 
                if(index >= 0 && index < arr.Length)
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
                while(arr[i] == 0)
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
                pairs[i] = new Pair(0,0);

            }
            int countDifference = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDifference; j++)
                {
                    if(arr[i] == pairs[j].Number)
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

        public bool IsPalindrome()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != arr[arr.Length - i-1])
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
            int count = 0,number = 0,maxCount = 0;
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
        public Vector BubbleSort()
        {
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = 0; j < arr.Length- i- 1; j++)
                    if (arr[j + 1] > arr[j])
                        Swap(j + 1,j);
            return new Vector(arr);
        }
        public enum Pivot{ First,Last,Mid}
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
        private int Partition(int low, int high)
        {
            int pivot = arr[low];
            int swapIndex = low;
            for (int i = low ; i <= high; i++)
            {
                if (arr[i] < pivot)
                {
                    swapIndex++;
                    Swap(i, swapIndex);
                }
            }
            Swap(low, swapIndex);
            return swapIndex;
        }
      
        private int PartitionLast(int low, int high)
        {
            int pivot = arr[high];
            int swapIndex = low-1;
            for (int i = low ; i < high; i++)
            {
                if (arr[i] < pivot)
                {
                    swapIndex++;
                    Swap(i, swapIndex);

                }
            }
            Swap(swapIndex+1, high);
            return swapIndex+1;
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
        private void Swap(int v1, int v2)
        {
            int temp = arr[v1];
            arr[v1] = arr[v2];
            arr[v2] = temp;
        }

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

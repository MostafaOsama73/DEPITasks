using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08.Part02
{
    public static class Sorter
    {
        public static void SelectionSort(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j] < numbers[minIdx])
                    {
                        minIdx = j;
                    }
                }
                // Swap
                int temp = numbers[minIdx];
                numbers[minIdx] = numbers[i];
                numbers[i] = temp;
            }
        }
    }
}

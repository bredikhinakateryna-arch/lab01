using System;

namespace Lab01SortPerformance.Algorithms;

public class InsertionSort : ISortingAlgorithm
{
    public string Name => "Insertion sort";

    public SortingResult Sort(int[] array)
    {
        var comparisons = 0;
        var swaps = 0;

        int[] arr = (int[])array.Clone();

        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0)
            {
                comparisons++;
                if (arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    swaps++;
                    j--;
                }
                else
                {
                    break;
                }
            }
            arr[j + 1] = key;
        }

        Array.Copy(arr, array, arr.Length);

        return new SortingResult
        {
            Array = array,
            Comparisons = comparisons,
            Swaps = swaps
        };
    }
}
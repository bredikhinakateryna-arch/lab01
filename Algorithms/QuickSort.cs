using System;

namespace Lab01SortPerformance.Algorithms;

public class QuickSort : ISortingAlgorithm
{
    public string Name => "Quick Sort";

    private int comparisons = 0;
    private int swaps = 0;

    public SortingResult Sort(int[] array)
    {
        comparisons = 0;
        swaps = 0;

        int[] arr = (int[])array.Clone();

        IterativeQuickSort(arr, 0, arr.Length - 1);

        Array.Copy(arr, array, arr.Length);

        return new SortingResult
        {
            Array = array,
            Comparisons = comparisons,
            Swaps = swaps
        };
    }

    private void IterativeQuickSort(int[] arr, int low, int high)
    {
        int[] stack = new int[high - low + 1];
        int top = -1;

        stack[++top] = low;
        stack[++top] = high;

        while (top >= 0)
        {
            high = stack[top--];
            low = stack[top--];

            int p = Partition(arr, low, high);

            if (p - 1 > low)
            {
                stack[++top] = low;
                stack[++top] = p - 1;
            }

            if (p + 1 < high)
            {
                stack[++top] = p + 1;
                stack[++top] = high;
            }
        }
    }

    private int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            comparisons++;
            if (arr[j] <= pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, high);
        return i + 1;
    }

    private void Swap(int[] arr, int i, int j)
    {
        if (i != j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            swaps++;
        }
    }
}
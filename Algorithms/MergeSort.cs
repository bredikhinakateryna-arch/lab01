using System;

namespace Lab01SortPerformance.Algorithms;

public class MergeSort : ISortingAlgorithm
{
    public string Name => "Merge Sort";

    private int comparisons = 0;
    private int swaps = 0;

    public SortingResult Sort(int[] array)
    {
        comparisons = 0;
        swaps = 0;

        int[] arr = (int[])array.Clone();

        MergeSortAlgorithm(arr, 0, arr.Length - 1);

        Array.Copy(arr, array, arr.Length);

        return new SortingResult
        {
            Array = array,
            Comparisons = comparisons,
            Swaps = swaps
        };
    }

    private void MergeSortAlgorithm(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;

            MergeSortAlgorithm(arr, left, mid);
            MergeSortAlgorithm(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }
    }

    private void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] leftArr = new int[n1];
        int[] rightArr = new int[n2];

        for (int x = 0; x < n1; x++)
        {
            leftArr[x] = arr[left + x];
            swaps++;
        }
        for (int x = 0; x < n2; x++)
        {
            rightArr[x] = arr[mid + 1 + x];
            swaps++;
        }

        int i = 0, j = 0, k = left;

        while (i < n1 && j < n2)
        {
            comparisons++;
            if (leftArr[i] <= rightArr[j])
            {
                arr[k] = leftArr[i];
                i++;
            }
            else
            {
                arr[k] = rightArr[j];
                j++;
            }
            swaps++;
            k++;
        }

        while (i < n1)
        {
            arr[k] = leftArr[i];
            i++;
            k++;
            swaps++;
        }

        while (j < n2)
        {
            arr[k] = rightArr[j];
            j++;
            k++;
            swaps++;
        }
    }
}
using System;

namespace Lab01SortPerformance.Testing;

public static class ArrayGenerator
{
    private static readonly Random random = new Random(42);

    public static int[] GenerateReverseSortedArray(int size)
    {
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = size - i;
        }
        return array;
    }

    public static int[] GenerateSortedArray(int size)
    {
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = i + 1;
        }
        return array;
    }

    public static int[] GenerateRandomlySortedArray(int size)
    {
        int[] array = GenerateSortedArray(size);

        for (int i = size - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);

            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        return array;
    }

    public static bool IsSorted(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[i - 1])
                return false;
        }
        return true;
    }
}
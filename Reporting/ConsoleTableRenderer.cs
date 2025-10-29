using System;
using System.Collections.Generic;
using System.Linq;
using Lab01SortPerformance.Models;

namespace Lab01SortPerformance.Reporting;

public class ConsoleTableRenderer : ITableRenderer
{
    public void RenderPerformanceTable(List<ComplexityMeasurement> measurements)
    {
        Console.WriteLine("");
        Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                              PERFORMANCE COMPARISON TABLE                         ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════╝");
        Console.WriteLine();

        var allResults = measurements
            .SelectMany(m => m.Results)
            .OrderBy(r => r.TestCase)
            .ThenBy(r => r.AlgorithmName)
            .ThenBy(r => r.ArraySize)
            .ToList();

        const int algWidth = 15;
        const int sizeWidth = 12;
        const int caseWidth = 16;
        const int timeWidth = 10;
        const int compWidth = 15;
        const int swapsWidth = 12;

        Console.WriteLine("┌" + new string('─', algWidth + 2) + "┬" + new string('─', sizeWidth + 2) +
                         "┬" + new string('─', caseWidth + 2) + "┬" + new string('─', timeWidth + 2) +
                         "┬" + new string('─', compWidth + 2) + "┬" + new string('─', swapsWidth + 2) + "┐");

        Console.WriteLine($"│ {"Algorithm",-algWidth} │ {"Array Size",sizeWidth} │ {"Case",-caseWidth} │ {"Time(ms)",timeWidth} │ {"Comparisons",compWidth} │ {"Swaps",swapsWidth} │");

        Console.WriteLine("├" + new string('─', algWidth + 2) + "┼" + new string('─', sizeWidth + 2) +
                         "┼" + new string('─', caseWidth + 2) + "┼" + new string('─', timeWidth + 2) +
                         "┼" + new string('─', compWidth + 2) + "┼" + new string('─', swapsWidth + 2) + "┤");

        foreach (var result in allResults)
        {
            string algorithm = TruncateAndPad(result.AlgorithmName, algWidth);
            string size = TruncateAndPad(result.ArraySize.ToString("N0"), sizeWidth, true);
            string testCase = TruncateAndPad(result.TestCase.ToString(), caseWidth);
            string time = TruncateAndPad(result.ExecutionTimeMs.ToString(), timeWidth, true);
            string comparisons = TruncateAndPad(result.Comparisons.ToString("N0"), compWidth, true);
            string swaps = TruncateAndPad(result.Swaps.ToString("N0"), swapsWidth, true);

            Console.WriteLine($"│ {algorithm} │ {size} │ {testCase} │ {time} │ {comparisons} │ {swaps} │");
        }

        Console.WriteLine("└" + new string('─', algWidth + 2) + "┴" + new string('─', sizeWidth + 2) +
                         "┴" + new string('─', caseWidth + 2) + "┴" + new string('─', timeWidth + 2) +
                         "┴" + new string('─', compWidth + 2) + "┴" + new string('─', swapsWidth + 2) + "┘");

        Console.WriteLine();
        Console.WriteLine("Note: All times in milliseconds, comparisons and swaps counted during sorting.");
    }

    private string TruncateAndPad(string text, int width, bool rightAlign = false)
    {
        if (text.Length > width)
            text = text.Substring(0, width);

        return rightAlign ? text.PadLeft(width) : text.PadRight(width);
    }
}
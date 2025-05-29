using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'plusMinus' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void plusMinus(List<int> arr)
    {
        // Write your code here
        int positiveCount = 0;
        int negativeCount = 0;
        int zeroCount = 0;

        foreach (int number in arr)
        {
            if (number > 0)
            {
                positiveCount++;
            }
            else if (number < 0)
            {
                negativeCount++;
            }
            else
            {
                zeroCount++;
            }
        }

        int totalCount = arr.Count;

        Console.WriteLine($"{(double)positiveCount / totalCount:F6}");
        Console.WriteLine($"{(double)negativeCount / totalCount:F6}");
        Console.WriteLine($"{(double)zeroCount / totalCount:F6}");

        Console.ReadLine();
        
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        // int n = Convert.ToInt32(Console.ReadLine().Trim());

        // List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
        
        //Result.plusMinus(arr);
        Result.plusMinus([1, 2, 0, -1, -2,-3, 4, 5, 6,74, 45, 5, 5,3,23]);
    }
}

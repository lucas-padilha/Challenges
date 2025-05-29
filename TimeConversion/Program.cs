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
    public static void timeConversion(string s)
    {
        var arr = s.Split(":");
        bool ismorning = arr[2].Contains("AM");

        int hour = Convert.ToInt32(arr[0]);
        if (!ismorning && hour < 12)
            hour += 12;
        else if (ismorning && hour == 12)
            hour -= 12;

        int min = Convert.ToInt32(arr[1]);
        int sec = Convert.ToInt32(arr[2].Substring(0, 2));

        TimeSpan ts = new TimeSpan(hour, min, sec);

        System.Console.WriteLine(ts);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //Result.miniMaxSum([256741038, 623958417, 467905213, 714532089, 938071625]);
        Result.timeConversion("07:05:45PM");      
        Result.timeConversion("12:01:00PM");      
        Result.timeConversion("12:01:00AM");      

        // Result.miniMaxSum([1, 2, 0, 5, 10]);
        Console.ReadLine();
    }
}

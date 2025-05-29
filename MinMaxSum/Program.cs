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
    public static void miniMaxSum(List<int> arr)
    {
        arr.Sort();
        var maiores =  arr.Slice(1, 4).Sum(item => { return (long)item; });
        var menores = arr.Slice(0, 4).Sum(item => { return (long)item; });

        System.Console.WriteLine($"{menores} {maiores}");        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //Result.miniMaxSum([256741038, 623958417, 467905213, 714532089, 938071625]);
        Result.miniMaxSum([7, 69, 2, 221, 8974]);      
        
        // Result.miniMaxSum([1, 2, 0, 5, 10]);
    }
}

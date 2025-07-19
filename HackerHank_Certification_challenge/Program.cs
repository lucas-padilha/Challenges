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


    public static int diagonalDifference(List<List<int>> arr)
    {
        return 0;
    }

    public static bool ehPar(int num)
    {
        var a = (num & 1);
        return (num & 1) == 0;
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        Console.WriteLine(Result.ehPar(5));
        Console.WriteLine(Result.ehPar(6));
    }
}

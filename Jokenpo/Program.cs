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
using System.ComponentModel.Design;

class Result
{
    public static string playGame(string escolhaJogador1, string escolhaJogador2)
    {
        string vencedor = "jogador 1";
        Dictionary<string, HashSet<string>> results = new Dictionary<string, HashSet<string>>
        {
            {"pedra", new HashSet<string> { "tesoura", "lagarto" }},
            {"tesoura",  new HashSet<string>{"papel", "lagarto"} },
            {"papel", new HashSet<string>{"pedra", "spock" } },
            {"lagarto",  new HashSet<string> {"spock", "papel"} },
            {"spock",  new HashSet<string> {"pedra", "tesoura" } }
        };
        
        if (!results[escolhaJogador1].Contains(escolhaJogador2)){
            vencedor = "jogador 2";
        }
        Console.WriteLine($"Vencedor {vencedor}");
        return vencedor;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        Result.playGame("pedra", "papel");
        Result.playGame("papel", "papel");
        Result.playGame("tesoura", "papel");
        Result.playGame("spock", "papel");
        Result.playGame("lagarto", "papel");
    }
}

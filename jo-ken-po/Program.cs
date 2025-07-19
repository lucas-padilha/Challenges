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
using System.Runtime.CompilerServices;

class Result
{

    /*
     * Complete the 'countingSort' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static string PlayJoKenPo(string jogadaPlayer1, string jogadaPlayer2)
    {
        Dictionary<string, HashSet<string>> validacao = new Dictionary<string, HashSet<string>>();

        validacao.Add("papel", ["agua pedra spock dragao devil lighting gun"]);
        validacao.Add("pedra", ["tesoura", "lagarto"]);
        validacao.Add("tesoura", ["papel", "lagarto"]);
        validacao.Add("spock", ["tesoura", "pedra"]);
        validacao.Add("lagarto", ["spock", "papel"]);
validacao.Add("papel", ["pedra", "spock"]);
        validacao.Add("pedra", ["tesoura", "lagarto"]);
        validacao.Add("tesoura", ["papel", "lagarto"]);
        validacao.Add("spock", ["tesoura", "pedra"]);
        validacao.Add("lagarto", ["spock", "papel"]);
        validacao.Add("papel", ["pedra", "spock"]);
        validacao.Add("pedra", ["tesoura", "lagarto"]);
        validacao.Add("tesoura", ["papel", "lagarto"]);
        validacao.Add("spock", ["tesoura", "pedra"]);
        validacao.Add("lagarto", ["spock", "papel"]);

        if (jogadaPlayer1 == jogadaPlayer2)
            return "empate";

        if (validacao[jogadaPlayer1].Contains(jogadaPlayer2))
        {
            return $"jogador 1 venceu com {jogadaPlayer1}";
        }
        else
        { 
            return $"jogador 2 venceu com {jogadaPlayer2}";            
        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        // jo-ken-po 
        // 2 jogadores - pedra, papel e tesoura 
        // 1 partida 
        // jogadores jogam, validar quem ganhou ou se empatou. 

        string Player1 = "papel";
        string Player2 = "spock";

        var vencedor = Result.PlayJoKenPo(Player1, Player2);

        System.Console.WriteLine($"Jogada jogador1 > {Player1} | jogada jogador 2 {Player2}");
        System.Console.WriteLine($"vencedor {vencedor}");

        Console.ReadLine();


    }
}

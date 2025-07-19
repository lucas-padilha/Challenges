// /*
// You are given an array of words `["cat", "bob", "foo", "baby", "car"]` 
// and an array of random strings `["zDWaeecjpot", "atrfbnoaoqoqob", "bbbewqway", "efwecarqwef", 
// "aikpakfnvmaob"]`.
// Write a function that takes two arguments, word (string) and random (string), 
// and returns whether random contains the letters of `word` in any order.

// Example:
// `zDWaeecjpot`-> contains `cat`
// `atrfbnoaoqoqob` -> contains `foo` and `bob`
// `bbbewqway` -> contains `baby`
// `efwecarqwef` -> contains `car`
// Ω
// **Note:** the random string should contain all instances of word characters, for example for "bob", the random string must have 2x the letter "b", **in any order.**
// */

using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

class Problem
{
    static void Main()
    {
        string[] words = { "cat", "bob", "foo", "baby", "car" };
        string[] rand = { "zDWaeecjpot", "atrfbnoaoqoqob", "bbbewqway", "efwecarqwef", "wsjjrtgrybay" };

        foreach (string word in words)
        {
            Console.WriteLine($"{word}:");

            foreach (string s in rand)
            {
                Console.WriteLine(Contains(word, s));
            }
        }       
    }
    
    static bool Contains(string word = "", string random = "")
    {   
        var listRandom = random.ToList();
        foreach (var item in word)
        {
            bool removed = listRandom.Remove(item);
            if (!removed)
            {
                return false;
            }
        }
        return true;
    }
}
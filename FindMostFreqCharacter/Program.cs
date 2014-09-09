using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FindMostFreqCharacter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type a string, any string, and hit Enter!");
            FindMostFreqCharacter(Console.ReadLine());

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Would you like to play again?");
                Console.WriteLine("Enter another string or type 'exit' to quit");
                var input = Console.ReadLine();

                if (input == "exit")
                    Environment.Exit(0);
                else
                    FindMostFreqCharacter(input);
            }
        }

        static void FindMostFreqCharacter(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("This string is null or empty.");
                return;
            }

            var stopWatch = Stopwatch.StartNew();
            var listCharacters = new List<KeyValuePair<char, int>>(); // Key = character, Value = frequency count

            foreach (char c in str)
            {
                var ch = listCharacters.FirstOrDefault(x => x.Key == c);
                if (ch.Key == c)
                {
                    listCharacters.Remove(ch);
                    listCharacters.Add(new KeyValuePair<char, int>(ch.Key, ch.Value + 1));
                }
                else
                {
                    listCharacters.Add(new KeyValuePair<char, int>(c, 1));
                }
            }

            if (listCharacters.Any())
            {
                int maxVal = listCharacters.Max(v => v.Value);
                var chars = listCharacters.Where(k => k.Value.Equals(maxVal));

                if (chars.Count() == 1)
                {
                    Console.WriteLine("The character '{0}' appears the most frequently in this string.", chars.First().Key);
                }
                else if (chars.Count() > 1)
                {
                    var keys = chars.Select(x => x.Key).ToList();
                    Console.WriteLine("The characters '{0}' all appear with the same amount of frequency.", string.Join(", ", keys));
                }
            }

            stopWatch.Stop();

            Console.WriteLine("<<This operation took {0} milliseconds to execute>>", stopWatch.Elapsed.TotalMilliseconds);
        }
    }
}
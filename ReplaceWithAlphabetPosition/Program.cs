using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReplaceWithAlphabetPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AlphabetPosition("The sunset sets at twelve o' clock."));
            Console.ReadKey();
        }

        public static string AlphabetPosition(string text)
        {
            string result = "";
            var dictionary = new Dictionary<char, int>();
            Console.WriteLine(text);
            dictionary.Add('A', 1); dictionary.Add('G', 7); dictionary.Add('M', 13); dictionary.Add('S', 19); dictionary.Add('Y', 25);
            dictionary.Add('a', 1); dictionary.Add('g', 7); dictionary.Add('m', 13); dictionary.Add('s', 19); dictionary.Add('y', 25);
            dictionary.Add('B', 2); dictionary.Add('H', 8); dictionary.Add('N', 14); dictionary.Add('T', 20); dictionary.Add('Z', 26);
            dictionary.Add('b', 2); dictionary.Add('h', 8); dictionary.Add('n', 14); dictionary.Add('t', 20); dictionary.Add('z', 26);
            dictionary.Add('C', 3); dictionary.Add('I', 9); dictionary.Add('O', 15); dictionary.Add('U', 21);
            dictionary.Add('c', 3); dictionary.Add('i', 9); dictionary.Add('o', 15); dictionary.Add('u', 21);
            dictionary.Add('D', 4); dictionary.Add('J', 10); dictionary.Add('P', 16); dictionary.Add('V', 22);
            dictionary.Add('d', 4); dictionary.Add('j', 10); dictionary.Add('p', 16); dictionary.Add('v', 22);
            dictionary.Add('E', 5); dictionary.Add('K', 11); dictionary.Add('Q', 17); dictionary.Add('W', 23);
            dictionary.Add('e', 5); dictionary.Add('k', 11); dictionary.Add('q', 17); dictionary.Add('w', 23);
            dictionary.Add('F', 6); dictionary.Add('L', 12); dictionary.Add('R', 18); dictionary.Add('X', 24);
            dictionary.Add('f', 6); dictionary.Add('l', 12); dictionary.Add('r', 18); dictionary.Add('x', 24);
            var reg = Regex.Replace(text, "[\\W^ ]", "").ToCharArray();
            if (reg.Length==0)
            {
                return "";
            }
            //foreach(var item in dictionary.Values)
            //    Console.WriteLine(item);
            foreach (char sym in reg)
            {
                foreach(var item in dictionary)
                {
                    if (sym==item.Key)
                    {
                        result += item.Value+" ";
                    }
                }
            }

            Console.WriteLine(result);
            
            return result.Remove(result.Length-1);
        }


        public static string AlphabetPosition1(string text)
        {
            return string.Join(" ", text.ToLower().Where(char.IsLetter).Select(x => x - 'a' + 1));
        }

        public static string AlphabetPosition2(string text)
        {
            return string.Join(" ", text.ToLower()
                                                  .Where(c => char.IsLetter(c))
                                                  .Select(c => "abcdefghijklmnopqrstuvwxyz".IndexOf(c) + 1)
                                                  .ToArray());
        }


        public static string AlphabetPosition3(string text)
        {
            StringBuilder sb = new StringBuilder(text.Length * 3);
            foreach (char ch in text.ToLower())
            {
                if (ch < 'a' || ch > 'z') continue;
                sb.Append(ch - '`');
                sb.Append(' ');
            }
            return sb.ToString().Trim();
        }
    }
}

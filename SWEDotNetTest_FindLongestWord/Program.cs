using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LongestWordFromWords
{
    internal class Program
    {
        public static string FindLongestWords(IEnumerable<string> listOfWords)
        {
            if (listOfWords == null) throw new ArgumentException("listOfWords");
            var sortedWords = listOfWords.OrderByDescending(word => word.Length);
            var dict = new HashSet<String>(sortedWords);
            return sortedWords.FirstOrDefault(word => isMadeOfWords(word, dict));
        }

        private static bool isMadeOfWords(string word, HashSet<string> dict)
        {
            if (String.IsNullOrEmpty(word)) return false;
            if (word.Length == 1)
            {
                return dict.Contains(word);
            }
            foreach (var pair in generatePairs(word).Where(pair => dict.Contains(pair.Item1)))
            {
                return dict.Contains(pair.Item2) || isMadeOfWords(pair.Item2, dict);
            }
            return false;
        }

        private static List<Tuple<string, string>> generatePairs(string word)
        {
            var output = new List<Tuple<string, string>>();
            for (int i = 1; i < word.Length; i++)
            {
                output.Add(Tuple.Create(word.Substring(0, i), word.Substring(i)));
            }
            return output;
        }

        private static List<string> filterlongest(List<string> lsinitial, List<string> exclusionlist, int currentlength)
        {
            string retVal1 = FindLongestWords(lsinitial.Where(p => !exclusionlist.Contains(p)).ToList());

            if (retVal1 != null)
            {
                if (currentlength == 0 || currentlength == retVal1.Length)
                {
                    exclusionlist.Add(retVal1);
                    filterlongest(lsinitial, exclusionlist, retVal1.Length);
                }
                else
                {
                    return exclusionlist;
                }
            }

            return exclusionlist;
        }

        private static void Main(string[] args)
        {
            try
            {
                List<string> lstlongestwords = new List<string>();
                List<string> lst2ndlongestwords = new List<string>();

                List<string> lstwords = File.ReadAllLines("input.txt").ToList();
                lstlongestwords = filterlongest(lstwords, new List<string>(), 0);
                foreach (string s in lstlongestwords)
                {
                    Console.WriteLine("longest word :" + s + " :" + s.Length.ToString());
                }
                string seclong = FindLongestWords(lstwords.Where(p => !lstlongestwords.Contains(p)).ToList());
                if (seclong == null)
                {
                    Console.WriteLine("There is no 2nd longest word from the list ");

                }
                else
                {
                    Console.WriteLine("2nd longest word :" + seclong + " :" + seclong.Length.ToString());
                }


                Console.ReadKey();



            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
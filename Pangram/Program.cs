using System;
using System.Linq;

namespace Pangram
{
    class Program
    {
        static void Main(string[] args)
        {
            Pangram p = new Pangram();
            Console.WriteLine(p.IsPangram("The quick brown fox jumps over the lazy dog"));
            Console.WriteLine(p.IsPangram("I am programmer"));

            Console.WriteLine(p.IsPangramLinq("The quick brown fox jumps over the lazy dog"));
            Console.WriteLine(p.IsPangramLinq("I am programmer"));
        }
        public class Pangram
        {
            string allLetters = "qwertyuiopasdfghjklzxcvbnm";
            public bool IsPangram(string sentence)
              {
                int count = 0;
                bool ans = true;
                sentence = sentence.ToLower();           
                if (sentence.Length > 1000)
                {
                    sentence = sentence.Substring(0, 1000);
                }

                foreach (var item in allLetters)
                {
                    foreach (var item2 in sentence)
                    {
                        if (item != item2)
                            count++;
                        else
                            break;
                    }
                    if (count == sentence.Length)
                    {
                        ans = false;
                        break;
                    }
                    else
                        count = 0;
                }
                return ans;
            }

            public bool IsPangramLinq(string sentence)
            {
                return "qwertyuiopasdfghjklzxcvbnm".Where(x => sentence.ToLower().Contains(x)).Count() == 26 ? true : false;
            }
        }
    }
}

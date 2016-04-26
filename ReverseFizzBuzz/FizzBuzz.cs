using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ReverseFizzBuzz
{
    class FizzBuzzReversal
    {
        int max;
        Dictionary<string, int> occurences;
        List<string> input;

        public FizzBuzzReversal (string FileName)
        {
            StreamReader sr = new StreamReader(FileName);

            input = new List<string>();
            string temp = sr.ReadLine();
            string[] split = temp.Split(' ');
            max = int.Parse(split[1]);
            occurences = new Dictionary<string, int>();
            

            while (!sr.EndOfStream)
            {
                temp = sr.ReadLine();
                split = temp.Split(' ');
                foreach (string st in split)
                {
                    input.Add(st);
                }
            }
            
            CountWords();
        }

        private String WordValue(string st)
        {
            int temp = max / occurences[st];
            return (temp.ToString());
        }




        public override string ToString()
        {
            string temp = "";
            foreach (KeyValuePair<string, int> kvp in occurences)
            {
                temp += kvp.Key + " = " + WordValue(kvp.Key) + '\n';
            }

            return temp;
        }

        private void CountWords()
        {
            foreach (string st in input)
            {
                if (!occurences.Keys.Contains(st))
                {
                    occurences[st] = 0;
                }
                occurences[st] = occurences[st] + 1;
            }
        }

        static void Main(string[] args)
        {
            string fileName;
            FizzBuzzReversal game;

            Console.WriteLine("Enter the name of the file: ");
            fileName = Console.In.ReadLine();

            game = new FizzBuzzReversal(fileName);

            Console.WriteLine(game.ToString());



            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }



    }
}

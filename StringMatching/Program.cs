using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace StringMathcing
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\해리포터와 죽음의 성물.txt";
            string textValue = System.IO.File.ReadAllText(path, Encoding.Default);


            SimpleStringMatch(textValue, "해리");
            StlStringMatch(textValue, "해리");

        }

        static void SimpleStringMatch(string content, string pattern)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int tempI = 0;

            bool match = false;
            int matchCount = 0;
            for (int i = 0; i < content.Length; i++)
            {
                tempI = i;

                match = false;

                for (int j = 0; j < pattern.Length; j++)
                {
                    if (content[tempI] == pattern[j])
                    {
                        match = true;
                        tempI++;
                        continue;
                    }
                    else
                    {
                        match = false;
                        break;
                    }
                }

                if (match == true)
                {
                    matchCount++;
                    //Console.Write("매칭 ");
                }
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms   " + matchCount.ToString() + "번");
        }

        static void StlStringMatch(string content, string pattern)
        {
            int matchPos = 0;
            int matchCount = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            while (true)
            {
                matchPos = content.IndexOf(pattern, matchPos + pattern.Length);

                if (matchPos == -1)
                {
                    break;
                }
                //Console.Write(matchPos + " " );
                matchCount++;
            }

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms   " + matchCount.ToString() + "번");
        }
    }
}

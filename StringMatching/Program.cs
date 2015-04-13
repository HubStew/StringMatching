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
            SearchProcess();

        }

        static private void SearchProcess()
        {
            string path = @"c:\해리포터와 죽음의 성물.txt";
            string textValue = System.IO.File.ReadAllText(path, Encoding.Default);

            string input;

            Console.Write("검색할 문자열 입력 : ");
            input = Console.ReadLine();

            SimpleStringMatch(textValue, input);
            StlStringMatch(textValue, input);
            KMPAlgorithm(textValue, input);

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
    
        static void KMPAlgorithm(string content, string pattern)
        {
            int[] failArr = new int[pattern.Length + 1];

            Stopwatch sw = new Stopwatch();
            sw.Start();

            KMPFindFail(pattern.Length, pattern, failArr);

            int i = 0;
            int j = 0;

            int matchCount = 0;

            while (i < content.Length)
            {
                if (j == -1 || content[i] == pattern[j])
                {
                    i++;
                    j++;
                }
                else
                    j = failArr[j];

                if (j == pattern.Length)
                {
                    matchCount++;
                    j = failArr[j];
                }

               
            }
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms   " + matchCount + "번");
        }

        static void KMPFindFail(int size, string pattern, params int[] failArr)
        {
            int i = 0;
            int j = -1;

            failArr[0] = -1;

            while(i < size)
            {
                if (j == -1 || pattern[i] == pattern[j])
                {
                    i++;
                    j++;
                    failArr[i] = j;
                }
                else
                    j = failArr[j];
            }
        }


    }
}

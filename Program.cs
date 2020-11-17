using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FindFalseLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];

            if (System.IO.File.Exists(path)) {
                string[] lines = System.IO.File.ReadAllLines(path);
                Regex rx = new Regex(@"(([\d]+([ ]+)?)\|([\d]+([ ]+)?)\|(([\d]{5})|([\d]{3}))([ ]+)?\|([\d]+([ ]+)?)\|([\d]+([ ]+)?)\|([\d]+([ ]+)?))",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

                int lineNumber = 0;
                List<int> results = new List<int>();

                foreach (string line in lines)
                {
                    if (!rx.IsMatch(line) )
                    {
                       results.Add(lineNumber + 1);
                    }

                    lineNumber++;
                }

                foreach (int result in results)
                {
                    System.Console.WriteLine("Problem in line " + result);
                }
            } else
            {
                System.Console.WriteLine("No results");
            }
            
        }
    }
}

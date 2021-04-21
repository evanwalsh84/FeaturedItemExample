using System;
using System.Collections.Generic;
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


namespace featureditem
{
    
    class Program
    {
        public static string CalcMissing(List<string> items)
        {
            string tester1 = "Null";
            string tester2 = "Null";
            int counter1, counter2;
            counter1 = 0;
            counter2 = 0;
            foreach (string word in items)
            {
                tester1 = word;
                counter2 = 1;
                foreach(string word2 in items)
                {
                    if(tester1 == word2)
                    {
                        counter2++;
                        if(counter2>counter1)
                        {
                            tester2 = tester1;
                            counter1 = counter2;
                        }
                    }
                }
            }
            return tester2;
        }
        static void Main(string[] args)
        {
            
            var items = new List<String>();
            items.Add("Item2");
            items.Add("Item2");
            items.Add("Item1");
            items.Add("Item1");
            items.Add("Item1");
            items.Add("Item3");
            Console.WriteLine(CalcMissing(items));
        }
    }
}
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
            //tester1 and tester2 hold both the currently most reoccurring word and the current word being counted. Tester2 always currently most reoccuring word.
            string tester1 = "Null";
            string tester2 = "Null";
            //counter1 and counter 2 track occurences of the current most reoccurring word and current word being counted.
            //word checker used to track which word being compared is shorter. If both words are alphabetically identical but differ in length returns the shortest word.
            int counter1, counter2, lengthtocheck, wordchecker;
            //alphabettest used to compare individual letters for alphabetical order of words.
            char alphabettest1, alphabettest2;
            counter1 = 0;
            counter2 = 0;
            wordchecker = 1;
            //loop grabs word to count.
            foreach (string word in items)
            {
                tester1 = word;
                counter2 = 0;
                //takes word from previous loop to count its occurences. Slight redudancy can be simplified for faster execution.
                foreach (string word2 in items)
                {
                    if (tester1 == word2)
                    {
                        counter2++;
                        //triggers alphabetical check if occurrences of both current highest word and word being counted are the same.
                        if (counter2 == counter1 && tester2 != tester1)
                        {
                            alphabettest1 = Char.ToLower(tester1[0]);
                            alphabettest2 = Char.ToLower(tester2[0]);

                            if(tester1.Length < tester2.Length)
                            {
                                lengthtocheck = tester1.Length;
                            }
                            else
                            {
                                lengthtocheck = tester2.Length;
                                wordchecker = 2;
                            }
                            for (int i = 0; alphabettest1 == alphabettest2 && i < lengthtocheck; i++)
                            {
                                alphabettest1 = Char.ToLower(tester1[i]);
                                alphabettest2 = Char.ToLower(tester2[i]);
                                int a = alphabettest1.CompareTo(alphabettest2);
                               if ( a < 0)
                                    {
                                    tester2 = tester1;
                                }
                               else if(i+1 == lengthtocheck && wordchecker == 1)
                                {
                                    tester2 = tester1;
                                }
                            }
                        }
                        if (counter2 > counter1)
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
            //Example of linked list for execution purposes, can be replaced with any linked list in function call.

            var items = new List<String>();
            items.Add("Itema12");
            items.Add("Itema12");
            items.Add("Itema1");
            items.Add("Itema1");
            items.Add("Itema1");
            items.Add("Item3");
            items.Add("Itema12");
            Console.WriteLine(CalcMissing(items));
        }
    }
}
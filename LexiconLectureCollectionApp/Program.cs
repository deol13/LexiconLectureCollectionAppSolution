using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconLectureCollectionApp
{
    class Program
    {
        /*
            bool y = "Ulf" == "Ulf" //Wrong, only compares memory addresses not what they contain
            bool x = Ulf.Equals("Ulf") //Correct
        */

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\n");
            // Console.WriteLine("Int was: " + GetIntFromUser());
            //Console.WriteLine("Double was: " + GetDoubleFromUser());
            //MultiTable();
            //WorkingWithList();
            //StringBuilderTest();
            //StringThings();
            //DictionaryThings();
            //RandomThings();


        } // End of main method

        /// <summary>
        /// Primitive values liuke int/double are sent as copies.
        /// Objects are sent as a reference (will remember changes inside of them)
        /// </summary>
        static void PrimitiveVsObject()
        {
            string test = "test";
            canIModefieString(test);
            Console.WriteLine(test);


            StringBuilder test2 = new StringBuilder("test2");
            canIModefieStringBuilder(test2);
            Console.WriteLine(test2);
        }

        static void canIModefieString(string original)
        {
            original = original + "mod";
        }
        static void canIModefieStringBuilder(StringBuilder original)
        {
            original.Append("mod");
        }

        static void RandomThings()
        {
            Random rng = new Random();
            //Random rng2 = new Random();   //Uses time as a seed to get a table of random numbers to use. Changes each millisecond


            for (int i = 0; i < 15; i++)
            {
                //Console.WriteLine(rng.Next());
                //Console.WriteLine(rng.Next(10)); // 0 to 9 max is exclusive
                Console.WriteLine(rng.Next(10, 20)); // 10 to 19 max is exclusive but min is inclusive
                Console.WriteLine(rng.Next(10, 20)); // 10 to 19 max is exclusive but min is inclusive
            }

        }

        static void DictionaryThings()
        {
            Dictionary<int, string> willBankVault = new Dictionary<int, string>();

            willBankVault.Add(666, "The Devil");
            willBankVault.Add(999, "The Arch Devil");

            foreach (KeyValuePair<int, string> item in willBankVault)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }

        static void StringThings()
        {
            StringBuilder stringBuilderEx = new StringBuilder("Test");
            string testString = stringBuilderEx.ToString();
            string testUppper = "Test";

            Console.WriteLine(testString);
            Console.WriteLine(testString[2]);
            Console.WriteLine(testString.ToUpper());

            Console.WriteLine("... " + testString.Equals(testUppper));
            Console.WriteLine("... " + testString.Equals(testUppper, StringComparison.OrdinalIgnoreCase));
        }

        static void StringBuilderTest()
        {
            string resultString = "";

            DateTime stringStart = DateTime.Now;

            for (int i = 0; i < 10000; i++)
            {
                resultString = resultString + "*";
            }

            DateTime stringEnd = DateTime.Now;

            TimeSpan stringTime = stringEnd.Subtract(stringStart);

            //------------------------------------------------------------------------

            StringBuilder resultSB = new StringBuilder("");

            DateTime stringSBStart = DateTime.Now;

            for (int i = 0; i < 10000; i++)
            {
                resultSB = resultSB.Append("*");
            }

            DateTime stringSBEnd = DateTime.Now;

            TimeSpan sBTime = stringSBEnd.Subtract(stringSBStart);

            //-----------------------------------------------------------------------

            Console.WriteLine("String time: " + stringTime);
            Console.WriteLine("StringBuilder time: " + sBTime);
        }

        static void WorkingWithList()
        {
            List<string> firstName = new List<string>();

            firstName.Add("Ulf");

            Console.Write("Enter a first name that is not Ulf: ");
            firstName.Add(Console.ReadLine());

            PrintList(firstName, "First names");

            List<string> lastName = new List<string> { "Andersson", "Bengtsson", "Svensson" };

            PrintList(lastName, "Last names");

            Console.WriteLine("Does first name contains Ulf?:" + firstName.Contains(firstName[0]));

            Console.WriteLine("List uses count to say how many are in the list: " + firstName.Count);
            Console.WriteLine("List uses Capacity to say how many can be in the list befire ut expands: " + firstName.Capacity);
        }

        static void PrintList(List<string> stringList, string nameOfList)
        {
            Console.WriteLine($"----------- {nameOfList} list -----------");
            foreach (string item in stringList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"----------- End of {nameOfList} list -----------\n");
        }

        static void MultiTable()
        {
            //2D array
            // GetLength                    0   1
            int[,] multi_10_table = new int[10, 10];

            //mutli_10_table.length gets you the entire size of the array which is 100
            //We want the size of each dimension so getLength(0) where 0 is the first dimension
            for (int y = 0; y < multi_10_table.GetLength(0); y++)
            {
                //Multi dimensional arrays are symmetrical at start so you can't array[j].length to get the length of the array inside the array
                //multi_10_table.GetLength(1) here is the second dimension
                for (int x = 0; x < multi_10_table.GetLength(1); x++)
                {
                    multi_10_table[y, x] = (y + 1) * (x + 1);
                    //Console.Write(multi_10_table[y, x] + "\t");

                    //{0,5}, multi_10_table =
                    //{index in String.Format: What we should format which in this case is multi_10_table,
                    //room between each item in the first argument aka multi_10_table}
                    string currentNumber = String.Format("{0,5}", multi_10_table[y, x].ToString());
                    Console.Write(currentNumber);
                }
                Console.WriteLine();
            }

            //for (int y = 0; y < multi_10_table.GetLength(0); y++)
            //{
            //    for (int x = 0; x < multi_10_table.GetLength(1); x++)
            //    {
            //        Console.Write(multi_10_table[y, x] + "\t");
            //    }
            //    Console.WriteLine();
            //}


            //If we used '' instead of "" the program would convert the inside to its ascii value thus adding to the number
            //So '\t' ascii is 9 thus number becomes 9 instead of 0 and no tabs are made
            //foreach (int number in multi_10_table)
            //{
            //    Console.Write(number + "\t");
            //}
        }

        static int GetIntFromUser()
        {
            int number = 0;
            bool wasNotNumber = true;

            do
            {
                //Only catch exceptions you can do something about, exceptions you can't do something about might be catched somewhere else
                //were it can be fixed
                try
                {
                    number = int.Parse(Console.ReadLine());
                    wasNotNumber = false;
                }
                catch (ArgumentException) //Start with the most specific and work towards the mot generic
                {
                    //Even if the user doesn't input anything, you still get an empty string so this doesn't trigger
                    Console.WriteLine("Must enter something!");
                    throw;
                }
                catch (FormatException e) //If parse can't parse it
                {
                    Console.WriteLine("Was unable to read your number: " + e.Message);
                }
                catch (OverflowException e) //If it's to large a number
                {
                    Console.WriteLine("The number was too big: " + e.Message);
                }
            } while (wasNotNumber);

            return number;
        }

        static double GetDoubleFromUser()
        {
            double number = 0;
            bool wasNotNumber = true;

            do
            {
                try
                {
                    //number = double.Parse(Console.ReadLine());
                    number = Convert.ToDouble(Console.ReadLine());
                    wasNotNumber = false;
                }
                catch (ArgumentException) //Start with the most specific and work towards the mot generic
                {
                    //Even if the user doesn't input anything, you still get an empty string so this doesn't trigger
                    Console.WriteLine("Must enter something!");
                    throw;
                }
                catch (FormatException e) //If parse can't parse it
                {
                    Console.WriteLine("Was unable to read your number: " + e.Message);
                }
                catch (OverflowException e) //If it's to large a number
                {
                    Console.WriteLine("The number was too big: " + e.Message);
                }
            } while (wasNotNumber);

            return number;
        }
    }
}

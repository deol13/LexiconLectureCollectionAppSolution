using System;

namespace LexiconLectureCollectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Console.WriteLine("Int was: " + GetIntFromUser());
            //Console.WriteLine("Double was: " + GetDoubleFromUser());

            MultiTable();
        } // End of main method

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

using System;

namespace LexiconLectureCollectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
           // Console.WriteLine("Int was: " + GetIntFromUser());
            Console.WriteLine("Double was: " + GetDoubleFromUser());


        } // End of main method

        static int GetIntFromUser()
        {
            int number = 0;
            bool wasNotNumber = true;

            do
            {
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

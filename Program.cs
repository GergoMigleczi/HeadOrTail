using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HeadOrTail
{
    //fej vagy iras = head or tail
    class HeadOrTail
    {
        //Generate a random head or tail outcome
        static void Task1()
        {
            Console.WriteLine("Task 1");

            Random rd = new Random();
            int num = rd.Next(0, 2);

            if (num == 0)
            {
                Console.WriteLine("Result: Tail");
            }
            else
            {
                Console.WriteLine("Result: Head");
            }
        }

        //Let the user guess
        //Check if the user was right or not
        static void Task2()
        {
            Console.WriteLine("Task 2");

            Console.Write("Take a guess= ");
            string guess = Console.ReadLine().ToUpper();

            string HeadOrTail = "";
            Random rd = new Random();
            int num = rd.Next(0, 2);

            if (num == 0)
            {
                HeadOrTail = "HEAD";
            }
            else
            {
                HeadOrTail = "TAIL";
            }
            Console.WriteLine($"The guess was {guess}, the result is {HeadOrTail}.");
            if (guess == HeadOrTail)
            {
                Console.WriteLine("You guessed it");
            }
            else
            {
                Console.WriteLine("Better luck next time");
            }
        }

        //Read the data of the kiserlet.txt but do not store it in the code(kiserlet=experiment)
        //Count how many experiments were in the file
        static int counter = 0; //later on the number of experiments is needed
        static void Task3()
        {
            Console.WriteLine("Task 3");

            StreamReader sr = new StreamReader("kiserlet.txt");

            counter = 0;
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                counter++;
            }
            sr.Close();

            Console.WriteLine($"There was {counter} flips in the experiment.");
        }

        //Calculate how many times was the result head, and print the percentage of it
        static void Task4()
        {
            Console.WriteLine("Task 4");

            StreamReader sr = new StreamReader("kiserlet.txt");

            int Head = 0;
            while (!sr.EndOfStream)
            {
                if (sr.ReadLine() == "F") //(F = Fej = Head)
                {
                    Head++;
                }
            }
            sr.Close();

            Console.WriteLine($"The experiments' {Math.Round((double)Head / counter * 100, 2)}% was head.");
        }

        //Calculate how many times there are EXACTLY two heads in a row
        static void Task5()
        {
            Console.WriteLine("Task 5ketfej");

            StreamReader sr = new StreamReader("kiserlet.txt");
            int NumberOfTwoHeadsInARow = 0;
            string currentFlip = "";
            string previousFlip = "";
            string previous_previousFlip = "";
            string FlipBefore_previous_previousFlip = "";
            while (!sr.EndOfStream)
            {
                currentFlip = sr.ReadLine();
                if (currentFlip == "I" && previousFlip == "F" && previous_previousFlip == "F" && FlipBefore_previous_previousFlip == "I")
                {
                    NumberOfTwoHeadsInARow++;
                }


                FlipBefore_previous_previousFlip = previous_previousFlip;
                previous_previousFlip = previousFlip;
                previousFlip = currentFlip;
            }
            sr.Close();
            Console.WriteLine($"The number of two heads in a row: {NumberOfTwoHeadsInARow}");
        }

        //Print how long was the longest head streak, and when it started
        static void Task6()
        {
            Console.WriteLine("Task 6");

            StreamReader sr = new StreamReader("kiserlet.txt");
            int longest = 0;
            int length = 0;
            int serialNumberOfTheFlip = 0;
            int startOfTheStreak = 0;

            string sor = "";
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine();
                serialNumberOfTheFlip++;
                if (sor == "F")
                {
                    length++;
                    if (length > longest)
                    {
                        longest = length;
                    }
                }
                else
                {
                    if (length == longest)
                        startOfTheStreak = serialNumberOfTheFlip - length;
                    length = 0;
                }
            }
            sr.Close();
            Console.WriteLine($"The longest head streak was {longest} long, and started with the {startOfTheStreak}th throw");
        }

        //Generate 1000 times 4 flips
        //Count how many times followed a head three heads, and how many times followed a tail three heads
        static void Task7()
        {
            List<string> flips = new List<string>();

            int HHHH = 0;
            int HHHT = 0;
            Random rd = new Random();

            for (int i = 0; i < 1000; i++)
            {
                string fourFlips = "";
                char[] ch = new char[4];
                for (int j = 0; j < 4; j++)
                {

                    int num = rd.Next(0, 2);

                    if (num == 0)
                    {
                        ch[j] = 'H';
                    }
                    else
                    {
                        ch[j] = 'T';
                    }
                }
                fourFlips = new string(ch);
                bool Head = true;
                bool Tail = true;
                for (int k = 0; k < 4; k++)
                {

                    if (k < 3 && fourFlips[k] == 'T')
                    {
                        Head = false;
                        Tail = false;
                    }
                    else if (fourFlips[3] == 'T')
                    {
                        Tail = true;
                        Head = false;
                    }
                    else if (fourFlips[3] == 'H')
                    {
                        Head = true;
                        Tail = false;
                    }

                }

                if (Head)
                    HHHH++;
                if (Tail)
                    HHHT++;

                flips.Add(fourFlips);

            }

            StreamWriter sw = new StreamWriter("dobasok.txt");

            sw.WriteLine($"HHHH: {HHHH}, HHHT: {HHHT}");
            for (int i = 0; i < 1000; i++)
            {

                sw.Write($"{flips[i]} ");
            }

            sw.Flush();
            sw.Close();
        }
        static void Main(string[] args)
        {
            Task1();

            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
            Task7();
            Console.ReadKey();
        }
    }
}

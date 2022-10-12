using System;
namespace Lab3
{
    public class Lab3Driver
    {
        private static double[] grades;
        public static void Main(String[] args)
        {
            Console.WriteLine("Welcome to Lab 3: Arrays and Lists\n" +
                "We'll be storing grades in first an array and then a list.\n" +
                "How many grades would you like to be able to store in the array?");

            //request user input and create new array of the length specified
            //Will throw exception if a non-integer is entered or if integer is negative
            //(or exceeds the max value of a signed int but why would you do that)
            int originalSize = int.Parse(Console.ReadLine());
            grades = new double[originalSize];

            InputGrades();

            Console.WriteLine("These are the values you entered:");

            OutputGrades();

            Console.WriteLine("We're going to expand the array. How much longer do you want it to be?");

            //create new array
            int size = int.Parse(Console.ReadLine()) + grades.Length;
            double[] tempName;

            tempName = CopyArray(size);

            //make grades point to the new array
            grades = tempName;

            Console.WriteLine("Time to populate the empty slots.");

            InputGrades(originalSize);

            OutputGrades();

            Console.WriteLine("Give an index to delete:");
            grades[int.Parse(Console.ReadLine())] = 0;

            Console.WriteLine("Now enter an index to overwrite:");
            grades[int.Parse(Console.ReadLine())] = 1000;
        }

        private static void InputGrades()
        {
            for (int i = 0; i < grades.Length; i++)
            {
                Console.WriteLine("Enter a grade to be stored.");

                //throws an exception if an invalid double is chosen
                grades[i] = Double.Parse(Console.ReadLine());
            }
        }

        private static void InputGrades(int startIndex)
        {
            for (int i = startIndex; i < grades.Length; i++)
            {
                Console.WriteLine("Enter a grade to be stored.");

                //throws an exception if an invalid double is chosen
                grades[i] = Double.Parse(Console.ReadLine());
            }
        }

        private static void OutputGrades()
        {
            foreach (double grade in grades)
            {
                Console.WriteLine(grade);
            }
        }

        private static double[] CopyArray(int size)
        {
            double[] tempName = new double[size];
            for(int i = 0; i < grades.Length; i++)
            {
                tempName[i] = grades[i];
            }
            return tempName;
        }
    }
}
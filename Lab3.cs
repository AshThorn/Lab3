﻿using System;
using System.Xml.Schema;

namespace Lab3
{
    public class Lab3Driver
    {
        private static double[] grades;
        public static List<double> gradeList;
        public static void Main(String[] args)
        {
            Console.WriteLine("Welcome to Lab 3: Arrays and Lists\n" +
                "Would you like to make an array or a list? (Enter a number to choose.)" +
                "\t1)\tAn Array" +
                "\t2)\tA List");
            int choice = int.Parse(Console.ReadLine());

            if(choice == 1)
            {
                ArrayVersion();
            }

            else if(choice == 2)
            {
                ListVersion();
            }

            else
            {
                Console.WriteLine("That is not a valid option.");
            }
        }

        private static void ArrayVersion()
        {
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

            Console.WriteLine("Here are the modified grades:");
            OutputGrades();
        }

        private static void ListVersion()
        {
            gradeList = new List<double>();

            int option = 0;
            while (option != 3)
            {
                option = ListMenu();
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter a grade:");
                        gradeList.Add(double.Parse(Console.ReadLine()));
                        break;
                    case 2:
                        OutputGradeList();
                        break;
                    case 3:
                        Console.WriteLine("Exiting.");
                        break;
                    default:
                        Console.WriteLine("Invalid entry.");
                        break;
                }
            }

            Console.WriteLine("Now, enter an index to remove a grade from.");
            gradeList.RemoveAt(int.Parse(Console.ReadLine()));

            OutputGradeList();

            Console.WriteLine("Enter an index to overwrite.");
            gradeList[int.Parse(Console.ReadLine())] = 1000;

            OutputGradeList();

            Console.WriteLine("Enter an index to insert a value at.");
            gradeList.Insert(int.Parse(Console.ReadLine()), 2000);

            OutputGradeList();
        }

        private static void InputGrades()
        {
            for (int i = 0; i < grades.Length; i++)
            {
                Console.WriteLine("Enter a grade to be stored.");

                //throws an exception if an invalid double is chosen
                grades[i] = double.Parse(Console.ReadLine());
            }
        }

        private static void InputGrades(int startIndex)
        {
            for (int i = startIndex; i < grades.Length; i++)
            {
                Console.WriteLine("Enter a grade to be stored.");

                //throws an exception if an invalid double is chosen
                grades[i] = double.Parse(Console.ReadLine());
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

        private static int ListMenu()
        {
            Console.WriteLine(
                "What would you like to do? (enter a number to choose)\n\n" +
                "\t1)\tAdd a grade\n" +
                "\t2)\tDisplay grades\n" +
                "\t3)\tExit menu");
            return int.Parse(Console.ReadLine());
        }

        private static void OutputGradeList()
        {
            Console.WriteLine("Displaying grades:");
            foreach(double grade in gradeList)
            {
                Console.WriteLine(grade);
            }
        }
    }
}
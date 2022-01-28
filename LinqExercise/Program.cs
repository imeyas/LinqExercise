using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers

            var sum = numbers.Sum();
            var average = numbers.Average();
            Console.WriteLine($"Sum = {sum}\n");
            Console.WriteLine($"Average = {average}\n");

            //Order numbers in ascending order and decsending order. Print each to console.

            var ascend = numbers.OrderBy(x => x).ToList();
            var descend = numbers.OrderByDescending(x => x).ToList();

            Console.WriteLine($"In ascending order:\n");

            foreach(var x in ascend)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine($"\nIn descending order:\n");

            foreach(var y in descend)
            {
                Console.WriteLine(y);
            }

            //Print to the console only the numbers greater than 6

            var greaterThanSix = numbers.Where(x => x > 6).ToList();
            Console.WriteLine($"\nNumbers greater than six:\n");
            foreach (var x in greaterThanSix)
            {
                Console.WriteLine(x);
            }
            


            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            var anyOrder = numbers.OrderBy(x => x).Where(x => x < 4).ToList();
            Console.WriteLine("\nIn ascending order but only printing four numbers out of the array:\n");
            foreach (var x in anyOrder)
            {
                Console.WriteLine(x);
            }


            //Change the value at index 4 to your age, then print the numbers in decsending order

            numbers[4] = 34;

            var changeIndex = numbers.OrderByDescending(x => x);

            Console.WriteLine($"\nChanged number at index 4 to age and then ordered by descending:\n");
            foreach (var y in changeIndex)
            {
                Console.WriteLine(y);
            }

                // List of employees ***Do not remove this***

                var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            var filtered = employees.Where(person => person.FirstName.ToLower()[0] == 'c' || person.FirstName.ToLower()[0] == 's');

            Console.WriteLine($"\nEmployees names containing the letter C or S:\n");
            foreach (var person in filtered.OrderBy(x => x.FirstName))
            {
                Console.WriteLine(person.FullName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            var employee = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);

            Console.WriteLine($"\nEmployees over 26 years of age:\n");
            foreach (var person in employees)
            {
                Console.WriteLine($"\n Name: {person.FullName}, Age: {person.Age}");
            }

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            var yearsOfExperience = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);

            Console.WriteLine($"\nSum of years of experience: {yearsOfExperience.Sum(x => x.YearsOfExperience)}\n");
            Console.WriteLine($"Average years of experience: {yearsOfExperience.Average(x => x.YearsOfExperience)}");

            //Add an employee to the end of the list without using employees.Add()

            var addedEmployee = employees.Append(new Employee("Eric", "Vines", 45, 17)).ToList();
            Console.WriteLine($"\nAdded new employee:\n");

            foreach(var person in addedEmployee)
            {
                Console.WriteLine(person.FullName);
            }

            
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}

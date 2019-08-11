using System;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Exerc_LinqLambda.Entities;

namespace Exerc_LinqLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> listEmployee = new List<Employee>();

            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();            
            
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] linhas = sr.ReadLine().Split(",");
                        listEmployee.Add(new Employee(linhas[0], linhas[1], double.Parse(linhas[2])));
                    }
                }

                Console.Write("Enter Salary: ");
                double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                var result1 = listEmployee.Where(p => p.Salary > value).OrderBy(p => p.Email).ThenBy(p => p.Name).Select(p => p.Email);

                Console.WriteLine("Email of people whose salary is more than: " + value + "\n");

                foreach (var r1 in result1)
                {
                    Console.WriteLine(r1);
                }
                
                Console.Write("\nInsert one character: ");
                char ch = char.Parse(Console.ReadLine().ToUpper());

                var result2 = listEmployee.Where(p => p.Name[0] == ch).Select(p => p.Salary).DefaultIfEmpty(0.0).Average();

                Console.WriteLine(result2.ToString("f2", CultureInfo.InvariantCulture));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

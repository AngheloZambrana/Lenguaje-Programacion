using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeraAplicacion
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            integers.Add(12);
            integers.Add(14);
            integers.Add(16);

            IEnumerable<int> evenNumbers = integers.Where(number => number % 2 == 0);

            int sum = evenNumbers.Aggregate(0, (acc, number) => acc + number);
            int mult = evenNumbers.Aggregate(0, (acc, number) => acc * number); 

            double average = evenNumbers.Aggregate(
                new { Sum = 0, Count = 0 },
                (acc, number) => new { Sum = acc.Sum + number, Count = acc.Count + 1 },
                acc => acc.Sum / (double)acc.Count
            );
            int max = evenNumbers.Aggregate(int.MinValue, (acc, number) => number > acc ? number : acc);

            int min = evenNumbers.Aggregate(int.MaxValue, (acc, number) => number < acc ? number : acc);

            Console.WriteLine("Números pares:");
            foreach (int number in evenNumbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Suma de los números pares:");
            Console.WriteLine(sum);
            Console.WriteLine("Multiplicacion de los números pares:");
            Console.WriteLine(mult);
            Console.WriteLine("Promedio de los números pares:");
            Console.WriteLine(average);
            Console.WriteLine("Máximo de los números pares:");
            Console.WriteLine(max);
            Console.WriteLine("Mínimo de los números pares:");
            Console.WriteLine(min);
        }
    }
}

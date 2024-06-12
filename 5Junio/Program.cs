using System;
using System.Collections.Generic;

namespace PrimeraAplicacion
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> numbers = Test.GetNumbers();
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            IEnumerable<string> strings = Test.GetStrings();
            IEnumerator<string> stringEnumerator = strings.GetEnumerator();

            Console.WriteLine(strings.GetEnumerator().Current == null);

            while (stringEnumerator.MoveNext())
            {
                Console.WriteLine(stringEnumerator.Current);
            }

            IEnumerable<int> evenNumbers = Test.GetEven();
            foreach (var even in evenNumbers)
            {
                Console.WriteLine(even);
            }

            IEnumerable<int> lessThanSevenEvenNumbers = Test.LessSeven();
            foreach (var number in lessThanSevenEvenNumbers)
            {
                Console.WriteLine(number);
            }
        }

        public static class Test
        {
            public static IEnumerable<string> GetStrings()
            {
                int x = 0;
                yield return "Hola";
                Console.WriteLine("x = " + x);
                yield return "Mundo";
                Console.WriteLine("x = " + ++x);
                yield return string.Empty;
            }

            public static IEnumerable<int> GetEven()
            {
                foreach (int number in GetNumbers())
                {
                    if (number % 2 == 0)
                    {
                        yield return number;
                    }
                }
            }

            public static IEnumerable<int> LessSeven()
            {
                foreach (int number in GetEven())
                {
                    if (number < 7)
                    {
                        yield return number;
                    }
                    else
                    {
                        yield break;
                    }
                }
            }

            public static IEnumerable<int> GetNumbers()
            {
                yield return 1;
                yield return 2;
                yield return 3;
                yield return 4;
                yield return 5;
                yield return 6;
                yield return 7;
                yield return 8;
                yield return 9;
                yield return 10;
            }
        }
    }
}

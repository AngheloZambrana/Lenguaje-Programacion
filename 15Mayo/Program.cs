using System;

namespace PrimeraAplicacion
{
    public static class ExtensionMethods
    {
        public static bool IsOdd(this int number)
        {
            return number % 2 != 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int number = 13;
            bool esImpar = number.IsOdd();
            Console.WriteLine(esImpar); 
        }
    }
}

using System;

namespace PrimeraAplicacion
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = -50;
            int y = 3;

            Console.WriteLine($"Antes del swap: x = {x}, y = {y}");
            Swap(ref x, ref y);
            Console.WriteLine($"Después del swap: x = {x}, y = {y}");
        }

        public static void Swap(ref int a, ref int b)
        {
            a = a + b; 
            b = a - b; 
            a = a - b; 
        }
    }
}

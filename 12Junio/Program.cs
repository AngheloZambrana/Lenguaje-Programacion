using System;

namespace PrimeraAplicacion
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "\0\0\0\0a";
            string s = "Hol" + a;
            Console.WriteLine(a);
            Console.WriteLine(a.Length);
            Console.WriteLine(s);
            Console.WriteLine(s.Length);
        }
    }
}
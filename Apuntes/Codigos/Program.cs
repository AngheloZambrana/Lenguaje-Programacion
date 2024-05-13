using System;

namespace PrimeraAplicacion
{
    class Program
    {
        static void Main(string[] args)
        {
            float floatValue = 3.14f;
            int intValue = BitConverter.SingleToInt32Bits(floatValue);
            Console.WriteLine("Binary representation of {0}: {1}", floatValue, Convert.ToString(intValue, 2));
        }
    }
}
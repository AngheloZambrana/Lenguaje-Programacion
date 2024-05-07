using System;

namespace PrimeraAplicacion
{
    class Program
    {
        struct Coordenada
        {
            public int X;
            public int Y;
        }

        static void Main(string[] args)
        {
            // Uso de la estructura Coordenada
            Coordenada punto = new Coordenada();
            punto.X = 10;
            punto.Y = 20;
            Console.WriteLine("Coordenadas: ({0}, {1})", punto.X, punto.Y);

            // Ejemplo de IEEE 754
            float floatValue = 3.14f;
            int intValue = BitConverter.SingleToInt32Bits(floatValue);
            Console.WriteLine("Binary representation of {0}: {1}", floatValue, Convert.ToString(intValue, 2));
        }
    }
}

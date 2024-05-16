using System;

namespace PrimeraAplicacion
{
    class Program
    {
        static void Main(string[] args)
        {
            MostrarFizzBuzz();
            Console.WriteLine(EsMultiplo(21, 7));
            Console.WriteLine(EsMultiplo(7, 21));
            Console.WriteLine(Suma(7, 21) == 28);
            Console.WriteLine(Suma(7, 5, 4) == 16);
            Console.WriteLine(Suma(4, 2, 1, 5, 8) == 20);  
            Console.WriteLine(Substraction(-1, 4, 2, -1, -10) == 4);   
            int product;
            Multiply(out product, 4, 2);
            Console.WriteLine(product == 8);
            Multiply(out product, -2, 5);
            Console.WriteLine(product == -10);
            Multiply(out product, -2, -5);
            Console.WriteLine(product == 10);
            Multiply(out product, 2, -5);
            Console.WriteLine(product == -10);

            Tuple<int, int> tuple = new Tuple<int, int>(0, 0);
            Divition(ref tuple, 10, -3);
            Console.WriteLine(tuple.Item1 == -3);
            Console.WriteLine(tuple.Item2 == 1);
            Divition(ref tuple, -10, 3);
            Console.WriteLine(tuple.Item1 == -3);
            Console.WriteLine(tuple.Item2 == -1);
            Divition(ref tuple, -10, -3);
            Console.WriteLine(tuple.Item1 == 3);
            Console.WriteLine(tuple.Item2 == -1);
            Divition(ref tuple, 10, 3);
            Console.WriteLine(tuple.Item1 == 3);
            Console.WriteLine(tuple.Item2 == 1);
        }

        static void MostrarFizzBuzz()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz " + i);
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz: " + i);
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz: " + i);
                }
            }
        }

        static bool EsMultiplo(int numero1, int numero2)
        {
            return numero1 % numero2 == 0;
        }

        static int Suma(params int[] numeros) 
        {
            int suma = 0;
            for (int i = 0; i < numeros.Length; i++)
            {
                suma += numeros[i];
            }
            return suma;
        }

        static int Substraction(params int[] numeros)
        {
            int resultado = numeros[0];
            for (int i = 1; i < numeros.Length; i = Suma(i, 1)) 
            {
                resultado = Suma(resultado, -numeros[i]);
            }
            return resultado;
        }

        static void Multiply(out int product, int factorX, int factorY)
        {
            product = 0;
            if (factorX < 0 && factorY < 0)
            {
                int factorPositivoX = -factorX;
                int factorPositivoY = -factorY;
                product = factorPositivoX * factorPositivoY;
            }
            else
            {
                if (factorX < factorY)
                {
                    for (int i = 0; i < factorY; i = Suma(i, 1))
                    {
                        product = Suma(product, factorX);
                    }
                }
                else
                {
                    for (int i = 0; i < factorX; i = Suma(i, 1))
                    {
                        product = Suma(product, factorY);
                    }
                }
            }
        }

        static void Divition(ref Tuple<int, int> n, int a, int b)
        {
            int cociente = 0;
            int positivoA = a < 0 ? Suma(~a, 1) : a;
            int positivoB = b < 0 ? Suma(~b, 1) : b;

            while (positivoA >= positivoB)
            {
                positivoA = Suma(positivoA, ~positivoB, 1);
                cociente = Suma(cociente, 1);
            }

            int residuo = a < 0 ? Suma(~positivoA, 1) : positivoA;
            if (a < 0 != b < 0)
            {
                cociente = Suma(~cociente, 1);
            }

            n = new Tuple<int, int>(cociente, residuo);
        }
    }
}

using System;

namespace PrimeraAplicacion
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Sum(2, 3) == 5);
            Console.WriteLine(Sum(2, 3, 7) == 12);
            Console.WriteLine(Sum(1, 2, 3, 4, 7) == 17);
            Console.WriteLine(Sum(-5, 6) == 1);
            Console.WriteLine(Sum(1, -7) == -6);
            Console.WriteLine(Sum(-2, -6) == -8);
            Console.WriteLine(Sum(5, -3, 8, -10) == 0);

            Console.WriteLine(Subtract(5, 3) == 2);
            Console.WriteLine(Subtract(5, -3) == 8);
            Console.WriteLine(Subtract(-5, 3) == -8);
            Console.WriteLine(Subtract(-5, -3) == -2);

            int product = 0;
            Multiply(ref product, 7, 3);
            Console.WriteLine(product == 21);
            Multiply(ref product, 5, 2, 3, 4);
            Console.WriteLine(product == 120);
            Multiply(ref product, 5, 0);
            Console.WriteLine(product == 0);

            Tuple<int, int> result;
            Divide(out result, 7, 2);
            Console.WriteLine(result.Item1 == 3 && result.Item2 == 1);
            Divide(out result, 10, 3);
            Console.WriteLine(result.Item1 == 3 && result.Item2 == 1);
        }

        static int Sum(params int[] numeros) 
        {
            int suma = 0;
            for (int i = 0; i < numeros.Length; i++)
            {
                suma += numeros[i];
            }
            return suma;
        }

        static int Subtract(params int[] numeros)
        {
            int resultado = numeros[0];
            for (int i = 1; i < numeros.Length; i = Sum(i, 1)) 
            {
                resultado = Sum(resultado, -numeros[i]);
            }
            return resultado;
        }

        static void Multiply(ref int product, params int[] factors)
        {
            product = 1;
            for (int i = 0; i < factors.Length; Sum(i, 1))
            {
                int currentFactor = factors[i];
                int tempProduct = 0;
                bool isNegative = currentFactor < 0;
                if (isNegative)
                {
                    currentFactor = -currentFactor;
                }
                for (int j = 0; j < currentFactor; j = Sum(j, 1))
                {
                    tempProduct = Sum(tempProduct, product);
                }
                if (isNegative)
                {
                    tempProduct = -tempProduct;
                }

                product = tempProduct;
            }
        }
        static void Divide(out Tuple<int, int> result, int dividend, int divisor)
        {
            int quotient = 0;
            int remainder = dividend;
            
            while (remainder >= divisor)
            {
                remainder = Subtract(remainder, divisor);
                quotient = Sum(quotient, 1);
            }

            result = new Tuple<int, int>(quotient, remainder);
        }
    }
}

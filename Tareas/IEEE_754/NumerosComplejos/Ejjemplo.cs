using System;

namespace PrimeraAplicacion
{
    struct NumeroComplejo
    {
        public double Real;
        public double Imaginario;

        public static NumeroComplejo operator +(NumeroComplejo a, NumeroComplejo b)
        {
            return new NumeroComplejo { Real = a.Real + b.Real, Imaginario = a.Imaginario + b.Imaginario };
        }

        public static NumeroComplejo operator -(NumeroComplejo a, NumeroComplejo b)
        {
            return new NumeroComplejo { Real = a.Real - b.Real, Imaginario = a.Imaginario - b.Imaginario };
        }

        public static bool operator ==(NumeroComplejo a, NumeroComplejo b)
        {
            return (a.Real == b.Real) && (a.Imaginario == b.Imaginario);
        }

        public static bool operator !=(NumeroComplejo a, NumeroComplejo b)
        {
            return !(a == b);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Ejemplo de uso de la estructura NumeroComplejo
            NumeroComplejo num1 = new NumeroComplejo { Real = 3, Imaginario = 2 };
            NumeroComplejo num2 = new NumeroComplejo { Real = 1, Imaginario = -1 };

            NumeroComplejo suma = num1 + num2;
            NumeroComplejo resta = num1 - num2;

            Console.WriteLine("Suma: {0} + {1}i", suma.Real, suma.Imaginario);
            Console.WriteLine("Resta: {0} + {1}i", resta.Real, resta.Imaginario);

            // Comparación de números complejos
            NumeroComplejo num3 = new NumeroComplejo { Real = 3, Imaginario = 2 };
            NumeroComplejo num4 = new NumeroComplejo { Real = 3, Imaginario = 2 };

            Console.WriteLine("¿Son iguales? " + (num3 == num4));
        }
    }
}

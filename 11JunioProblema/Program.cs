using System;

namespace EightQueens
{
    class Program
    {
        static int[] Tablero = new int[8];
        static bool SolucionEncontrada = false;

        static void PintarTablero()
        {
            Console.WriteLine();
            for (int Fila = 0; Fila < 8; Fila++)
            {
                for (int Columna = 0; Columna < 8; Columna++)
                {
                    if (Tablero[Columna] == Fila)
                        Console.Write("* ");
                    else
                        Console.Write("o ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static bool EsSeguro(int Columna, int Fila)
        {
            for (int i = 0; i < Columna; i++)
            {
                if (Tablero[i] == Fila || Math.Abs(i - Columna) == Math.Abs(Tablero[i] - Fila))
                    return false;
            }
            return true;
        }

        static void ColocarReina(int Columna)
        {
            if (Columna == 8 && !SolucionEncontrada)
            {
                PintarTablero();
                SolucionEncontrada = true;
                return;
            }

            for (int Fila = 0; Fila < 8; Fila++)
            {
                if (EsSeguro(Columna, Fila))
                {
                    Tablero[Columna] = Fila;
                    ColocarReina(Columna + 1);
                }
            }
        }

        static void Main(string[] args)
        {
            ColocarReina(0);
        }
    }
}

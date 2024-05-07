using System;

namespace PrimeraAplicacion
{
    class Program
    {
        static void RotateArray<T>(T[] arr, int shift)
        {
            int length = arr.Length;
            shift = shift % length;
            if (shift < 0)
            {
                shift = length + shift;
            }
            T[] temp = new T[length];
            for (int i = 0; i < length; i++)
            {
                temp[(i + shift) % length] = arr[i];
            }
            Array.Copy(temp, arr, length);
        }

        static void Main(string[] args)
        {
            // Uso de la función de rotación
            int[] array = { 1, 2, 3, 4, 5 };
            RotateArray(array, 2); // Rotar dos posiciones hacia la derecha
            Console.WriteLine(string.Join(", ", array)); // Output: 4, 5, 1, 2, 3
        }
    }
}

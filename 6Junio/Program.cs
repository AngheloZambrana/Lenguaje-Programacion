using System;
using System.Collections.Generic;

namespace PrimeraAplicacion
{
    class Program
    {
        public static class Test
        {
            public static IEnumerable<int> GetM()
            {
                return new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            }

            public static IEnumerable<int> GetN()
            {
                var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                foreach (var number in list)
                {
                    yield return number;
                }
            }

            // renamed this method to avoid naming conflict
            public static IEnumerable<int> GetNWithFor()
            {
                var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                for (int i = 0; i < list.Count; i++)
                {
                    yield return list[i];
                }
            }
        }

        public static void Main()
        {
            var ns = Test.GetN();
            var ens = ns.GetEnumerator();
            ens.MoveNext();
            Console.WriteLine(ens.Current);
            ens.MoveNext();
            Console.WriteLine(ens.Current);
            ens.Dispose();
            ens.MoveNext();
            Console.WriteLine(ens.Current);
            ens.MoveNext();
            Console.WriteLine(ens.Current);

            Console.WriteLine("\n");
            
            var ns2 = Test.GetNWithFor();
            var ens2 = ns2.GetEnumerator();
            ens2.MoveNext();
            Console.WriteLine(ens2.Current);
            ens2.MoveNext();
            Console.WriteLine(ens2.Current);
            ens2.Dispose();
            ens2.MoveNext();
            Console.WriteLine(ens2.Current);
            ens2.MoveNext();
            Console.WriteLine(ens2.Current);

        }
    }
}

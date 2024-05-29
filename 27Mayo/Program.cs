using System;

namespace PrimeraAplicacion
{
    class Program
    {
         static void Main(string[] args)
        {
            ClaseA claseA = new ClaseA();
            IInterface claseA2 = new ClaseA();
            claseA.Value = 1; // Setting the value property for claseA
            claseA2.Value = 6; // Setting the value property for claseA2
            Console.WriteLine(claseA.GetValue()); // Calling the method for claseA
            Console.WriteLine(claseA2.GetValue()); // Calling the method for claseA2
        }
        public class ClaseA : IInterface
        {
            /*public int _value;
            //Se crea una variable aparte, aguarra los descritores y los va a implementar
            public int Value {get => return _value; // {} => 10 esto es una funcion lambda que no recibe nada y devuelve 10
            set{_value = value}; } //{value} => {_value = value};;*/
            public int Value { get; set; }

            public int GetValue()
            {
                return this.Value;
            }
        }

        public interface IInterface
        {
            int Value { get; set; }
            int GetValue();
        }

        
    }
}
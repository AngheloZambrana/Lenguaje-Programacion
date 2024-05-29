namespace Functions
{
    public class Program
    {
        //Esto es un puntero a una funcion
        public delegate void Callback(string text);
        public static void Main(string[] args)
        {
            Callback callback = Greeting;

            //Greeting("hi") = INVOCAR
            //Greeting = Referencia
            callback("Hola");

            // Now we create a lambda function
            callback = text => { Console.WriteLine($"From lambda function: {text}"); };

            // Invoke the lambda function
            callback("Hola");

            //Ahora desde una clase
            var clase = new ClassA();
            callback = clase.Hi;
            callback("Hola");

             // Check the number of methods attached to the delegate
            Console.WriteLine(callback.GetInvocationList().Length == 1);

            // Remove the method from the delegate
            callback -= clase.Hi;

            // Check the delegate after removing the method
            Console.WriteLine(callback == null);

            callback += clase.Hi;
            callback += Greeting;
            callback += text => { Console.WriteLine($"From new lambda function: {text}"); };

            callback("Hi");

            //c# tiene dos delegados uno es Func, en el ejemplo este tipo de delegado solo devuelve un entero
            Func<int> function = () => 50;
            Console.WriteLine(function());

           //Puede recibir parametro(s) y el segundo siempre sera el parametro de salida
           Func<string, int, int, string> myFunc = ProcessData;
           Console.WriteLine($"Result of myFunc: {myFunc("Hi", 10, 20)}");

           //El otro tipo que tenemos en c# son los Actions
           Action action = () => {Console.WriteLine("SOy un procedure");}
           

        }
        public static void Greeting(string text)
        {
            Console.WriteLine($"From greeting funcition: {text}");

        }
        public static string ProcessData(string text, int value1, int value2)
        {
            // This method doesn't use the parameters but just returns a fixed string
            return "Hola Que tal";
        }
        
    }
    public class ClassA
        {
            public void Hi(string text)
            {
                Console.WriteLine($"From hi funcion {text}");
            }
        }
}
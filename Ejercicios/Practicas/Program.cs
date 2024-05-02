
// See https://aka.ms/new-console-template for more information


namespace PrimeraAplicacion
{
    class Program
    {
        static void Main(string[] args)
        {
            CondicionalesII();
        }

        public static void Condicionales()
        {
            int edad = 20;
            Console.WriteLine("Vamos a evaluar si eres mayor de edad");
            if (edad >= 18)
            {
                Console.WriteLine("Adelante, puedes pasar eres mayor de edad");
            }
        }

        public static void CondicionalesII()
        {
            Console.WriteLine("¿Cuantos años tienes?");
            int edad = Int32.Parse(Console.ReadLine());
            Console.WriteLine("¿Tienes Carnet?");
            string carnet = Console.ReadLine();
            if (edad >= 18 && carnet == "si")
                Console.WriteLine("Puede conducir vehiculos");
            else
                Console.WriteLine("No puede conducir");
        }
        
        
        
    }
}

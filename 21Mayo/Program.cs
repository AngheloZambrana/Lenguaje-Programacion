using System;
using System.Threading;

namespace PrimeraAplicacion
{
    class Program
    {
        static void Main(string[] args)
        {
            byte height = 4; 
            byte width = 4; 
            uint initialSpin = 0;

            Ecran ecran = new Ecran(width, height);
            Engine engine = new Engine(height, initialSpin);
            Control control = new Control();
            ElectronicEcran electronicEcran = new ElectronicEcran(ecran, engine, control);

            Console.WriteLine("Mostrando pantalla:");
            electronicEcran.ShowEcran();

            Console.WriteLine("\nEscondiendo pantalla:");
            electronicEcran.HideEcran();
            Console.WriteLine("\nProbando el indexador:");
            string primeraLinea = ecran[0];
            Console.WriteLine("Primera línea del Ecran:" + primeraLinea);
            string terceraLinea = ecran[2];
            Console.WriteLine("Tercera línea del Ecran: " + terceraLinea);
            string cuartaLinea = ecran[3];
            Console.WriteLine("Cuarta línea del Ecran: " + cuartaLinea);
        }
    }

    enum Options
    {
        UP,
        STOP,
        DOWN
    }

    class Control
    {
        private Options options;
        public Options GetOptions()
        {
            return options;
        }
        public void SetOptions(Options options)
        {
            this.options = options;
        }
    }

   class Ecran
    {
        private byte width;
        private byte height;
        private string[] ecranDisplay;

        public byte Height
        {
            get { return height; }
        }

        public Ecran(byte width, byte height)
        {
            this.width = width;
            this.height = height;
            this.ecranDisplay = new string[height];
            for (int i = 0; i < height; i++)
            {
                if (i == 0 || i == height - 1)
                {
                    ecranDisplay[i] = new string('*', width);
                }
                else
                {
                    ecranDisplay[i] = '*' + new string(' ', width - 2) + '*';
                }
            }
        }

        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= height)
                {
                    throw new IndexOutOfRangeException("Índice fuera de rango");
                }
                return ecranDisplay[index];
            }
        }
    }



    class Engine
    {
        public uint spinLimit;
        public uint currentSpin;
        public uint initialSpin;
        public Engine(byte height, uint initialSpin)
        {
            this.spinLimit = (uint)(height);
            this.initialSpin = initialSpin;
            this.currentSpin = initialSpin;
        }
        public void SpinUp()
        {
            if (currentSpin < spinLimit)
            {
                currentSpin++;
                ApplyDelay();
            }
        }
        public void SpinDown()
        {
            if (currentSpin > 0)
            {
                currentSpin--;
                ApplyDelay();
            }
        }
        private void ApplyDelay()
        {
            Thread.Sleep(1000);  
        }
        public bool IsInitial()
        {
            return currentSpin == initialSpin;
        }
        public bool IsFinal()
        {
            return currentSpin == spinLimit;
        }
    }

        class ElectronicEcran
    {
        private Ecran ecran;
        private Engine engine;
        private Control control;
        public ElectronicEcran(Ecran ecran, Engine engine, Control control)
        {
            this.ecran = ecran;
            this.engine = engine;
            this.control = control;
        }
        public void ShowEcran()
        {
            while (engine.currentSpin < engine.spinLimit)
            {
                engine.SpinUp();
                Console.Clear();
                Console.WriteLine($"Vuelta {engine.currentSpin}");
                for (int i = (int)(engine.spinLimit - engine.currentSpin); i < ecran.Height; i++)          
                {
                    Console.WriteLine(ecran[i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Límite Alcanzado");
        }
        public void HideEcran()
        {
            while (engine.currentSpin > engine.initialSpin)
            {
                engine.SpinDown();
                Console.Clear();
                Console.WriteLine($"De vuelta {engine.currentSpin}");
                for (int i = (int)(engine.spinLimit - engine.currentSpin); i < ecran.Height; i++)
                {
                    Console.WriteLine(ecran[i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Se escondió completamente");
        }
    }
}
using System;

namespace PrimeraAplicacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Ecran ecran = new Ecran(5, 3);
            Engine engine = new Engine(10, 1);
            Control control = new Control();

            ElectronicEcan electronicEcan = new ElectronicEcan(ecran, engine, control);

            electronicEcan.ShowEcran();

            engine.spinUp();
            control.SetOptions(Options.UP);
            Console.WriteLine($"Current Spin: {engine.currentSpin}");  
            Console.WriteLine($"Control Option: {control.GetOption()}");

           

            electronicEcan.HideEcran();
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

        public Options GetOption()
        {
            return options;
        }

        public void SetOptions(Options option)
        {
            options = option;
        }
    }

    class Ecran
    {
        private byte width;
        private byte height;

        public Ecran(byte width, byte height)
        {
            this.width = width;
            this.height = height;
        }

        public string[] GetEcran()
        {
            string[] ecranDisplay = new string[height];
            for (int i = 0; i < height; i++)
            {
                ecranDisplay[i] = new string('*', width);
            }
            return ecranDisplay;
        }
    }

    class Engine
    {
        public uint spinLimit;
        public uint currentSpin; 
        public uint initialSpin;

        public Engine(uint spinLimit, uint initialSpin)
        {
            this.spinLimit = spinLimit;
            this.initialSpin = initialSpin;
            this.currentSpin = initialSpin;
        }

        public void spinUp()
        {
            if (currentSpin < spinLimit)
            {
                currentSpin++;
            }
        }

        public void spinDown()
        {
            if (currentSpin > 0)
            {
                currentSpin--;
            }
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

    class ElectronicEcan
    {
        private Ecran ecran;
        private Engine engine;
        private Control control;

        public ElectronicEcan(Ecran ecran, Engine engine, Control control)
        {
            this.ecran = ecran;
            this.engine = engine;
            this.control = control;
        }

        public void ShowEcran()
        {
            string[] ecranDisplay = ecran.GetEcran();
            foreach (string line in ecranDisplay)
            {
                Console.WriteLine(line);
            }
        }

        public void HideEcran()
        {
            Console.Clear();
        }
    }
}

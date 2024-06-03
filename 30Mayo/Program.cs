using System;
using System.Timers;

namespace FunctionalTamagochi
{
    public class Program
    {
        public delegate TOut Getter<out TOut>();
        public delegate void Setter<in TIn>(TIn value);
        public delegate void Action();
        public delegate void Tick();

        public static (Getter<int> getLife, Setter<int> setLife, Getter<string> getLastAction, Setter<string> setLastAction) Tamagochi(int initialLife)
        {   
            int life = initialLife;
            string lastAction = string.Empty;

            Getter<int> getLife = () => life;
            Setter<int> setLife = value => { life = value; };

            Getter<string> getLastAction = () => lastAction;
            Setter<string> setLastAction = value => { lastAction = value; };

            return (getLife, setLife, getLastAction, setLastAction);
        }

        public static Action Alimentar((Getter<int> getLife, Setter<int> setLife, Getter<string> getLastAction, Setter<string> setLastAction) tamagochi)
        {
            return () =>
            {
                int life = tamagochi.getLife();
                string lastAction = tamagochi.getLastAction();

                if (lastAction == "Alimentar")
                {
                    life -= 1;
                }
                else
                {
                    life += 1;
                }

                tamagochi.setLife(life);
                tamagochi.setLastAction("Alimentar");
            };
        }

        public static Action Cuidar((Getter<int> getLife, Setter<int> setLife, Getter<string> getLastAction, Setter<string> setLastAction) tamagochi)
        {
            return () =>
            {
                int life = tamagochi.getLife();
                life += 2;

                tamagochi.setLife(life);
                tamagochi.setLastAction("Cuidar");
            };
        }

        public static Action Entretener((Getter<int> getLife, Setter<int> setLife, Getter<string> getLastAction, Setter<string> setLastAction) tamagochi)
        {
            return () =>
            {
                int life = tamagochi.getLife();
                string lastAction = tamagochi.getLastAction();

                if (lastAction == "Entretener")
                {
                    life -= 2;
                }
                else
                {
                    life += 1;
                }

                tamagochi.setLife(life);
                tamagochi.setLastAction("Entretener");
            };
        }

        public static Tick CrearTick((Getter<int> getLife, Setter<int> setLife, Getter<string> getLastAction, Setter<string> setLastAction) tamagochi)
        {
            return () =>
            {
                int life = tamagochi.getLife();
                life -= 1;

                tamagochi.setLife(life);

                Console.WriteLine($"Vida actual: {life}");

                if (life <= 0 || life >= 30)
                {
                    Console.WriteLine("Tamagochi ha muerto.");
                    Environment.Exit(0);
                }
            };
        }

        public static void Main()
        {
            var tamagochi = Tamagochi(10);
            var alimentar = Alimentar(tamagochi);
            var cuidar = Cuidar(tamagochi);
            var entretener = Entretener(tamagochi);
            var tick = CrearTick(tamagochi);

            System.Timers.Timer timer = new System.Timers.Timer(1000); 
            timer.Elapsed += (sender, e) => tick();
            timer.Start();

            Random random = new Random();

            while (true)
            {
                int action = random.Next(1, 4);
                switch (action)
                {
                    case 1:
                        alimentar();
                        break;
                    case 2:
                        cuidar();
                        break;
                    case 3:
                        entretener();
                        break;
                }

                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}

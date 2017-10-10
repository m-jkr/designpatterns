using INSADesignPattern.InputStrategies;
using INSADesignPattern.Observables;
using INSADesignPattern.Contexte;
using INSADesignPattern.Observer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern
{
    class Program
    {
        public static Observer.Observer UserInputObserver;

        public static Observer.ObserverCompos CompositObserver;

        private static HelloObservable helloObservable;
        private static AlreadyObservable alreadyObservable;

        public static string UserName = "<User>";

        public static Context context;


        private static int countHellos = 0;

        public static void UserSaidHello()
        {
            countHellos++;
            Debug.WriteLine(countHellos);
            switch (countHellos)
            {
                case 5:
                    helloObservable.SetInputStrategy(new LastHelloStrategy());
                    break;
                case 1:
                    helloObservable.SetInputStrategy(new SecondHelloStrategy());
                    break;
            }
        }

        static void Main(string[] args)
        {
            UserInputObserver = new Observer.Observer();
            helloObservable = new HelloObservable();
            alreadyObservable = new AlreadyObservable();
            SmileyObservable smileyObservable = new SmileyObservable();
            helloObservable.SetInputStrategy(new FirstHelloStrategy());

            //Définition observerComposite
            CompositObserver = new Observer.ObserverCompos();



            //Définition du contexte
            context = new Context();

            string line = "";
            Console.WriteLine("");
            Console.WriteLine("     __   __     __  ________  _____");
            Console.WriteLine("    /  / /  |  /  / /  _____/ /  _  |");
            Console.WriteLine("   /  / /   | /  / /  /____  /  /_| |");
            Console.WriteLine("  /  / /    |/  / /____   / /  ___  |");
            Console.WriteLine(" /  / /  /|    / _____/  / /  /   | |");
            Console.WriteLine("/__/ /__/ |___/ /_______/ /__/    |_|");
            Console.WriteLine("Desing Patterns - Anthony Maudry amaudry@gmail.com");
            //Console.WriteLine("Hello,");

            //Il faut maintenant initialiser l'arbre

            Composite.Composite menu = new Composite.Composite("Menu", "menu", new CompositeObservable());
            Composite.Composite partieR = new Composite.Composite("Partie Rapide", "jouer", new CompositeObservable());
            Composite.Composite typeP = new Composite.Composite("Type", "type", new CompositeObservable());
            Composite.Composite chrono = new Composite.Composite("Chronométrée", "timed", new CompositeObservable());
            Composite.Composite infini = new Composite.Composite("Infinie", "infinite", new CompositeObservable());
            Composite.Composite objec = new Composite.Composite("Objectif", "points", new CompositeObservable());
            Composite.Composite score = new Composite.Composite("Score", "score", new CompositeObservable());


            //On fabrique l'arbre, en attribuant les fils là où il faut
            menu.AddChild(partieR);
            menu.AddChild(typeP);
            menu.AddChild(score);

            typeP.AddChild(chrono);
            typeP.AddChild(infini);
            typeP.AddChild(objec);

            //Lien parents
            partieR.Parent = menu;
            typeP.Parent = menu;
            score.Parent = menu;

            chrono.Parent = typeP;
            infini.Parent = typeP;
            objec.Parent = typeP;


            Console.Write("Menu < menu >");
            CompositObserver.Register(menu.GetKeyWord(), menu.GetObservable());

            context.CurrentComposite = menu;

            Dictionary<string, Composite.Composite> bindDic = new Dictionary<string, Composite.Composite>();
            bindDic.Add(menu.GetKeyWord(), menu);
            bindDic.Add(partieR.GetKeyWord(), partieR);
            bindDic.Add(typeP.GetKeyWord(), typeP);
            bindDic.Add(chrono.GetKeyWord(), chrono);
            bindDic.Add(infini.GetKeyWord(), infini);
            bindDic.Add(objec.GetKeyWord(), objec);
            bindDic.Add(score.GetKeyWord(), score);

            while ((line = Console.ReadLine()) != "exit")
            {
               
                //Il faut tester que si on est déjà dans la section, on reste dans la section
               if(context.CurrentComposite.GetChildren().Exists(p => p.GetKeyWord().Equals(line)) || (context.CurrentComposite.GetKeyWord() == line))
                {
                    context.CurrentComposite = bindDic[line];
                    CompositObserver.Trigger(line);
                    CompositObserver.Register(line, alreadyObservable);
                }
                
                /*else
                {
                    Console.WriteLine($"You wrote {line}");
                }*/
            }



            //dictionnaire mot clé composite



            /*
            UserInputObserver.Register("hello", smileyObservable);
            UserInputObserver.Register("hello", helloObservable);
            do
            {
                if (line != "" && !UserInputObserver.Trigger(line))
                    Console.WriteLine($"You wrote {line}");

                Console.WriteLine($"{UserName}, write something or type 'exit' to exit the program.");
            } while ((line = Console.ReadLine()) != "exit");
            */

            Console.WriteLine("Goodbye.");
        }
    }
}

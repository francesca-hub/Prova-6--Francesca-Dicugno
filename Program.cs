using System;

namespace Prova_6__Francesca_Dicugno
{
    //Risposte domande:
    //1) a, e, g
    //2) b,d
    //3) c

    class Program
    {
        static void Main(string[] args)
        {
            // manager = new DbManagerConnectedMode();

            
           
           do
            {
                Console.WriteLine("------------------Menù-----------------");
                Console.WriteLine("Premi 1 - Mostrare tutti gli agenti di polizia");
                Console.WriteLine("Premi 2- Scegliere un'area geografica e mostrare gli agenti assegnati a quell'area");
                Console.WriteLine("Premi 3- Scegliere gli anni di servizio e mostrare gli agenti con anni di servizio maggiori o uguali alla scelta");
                Console.WriteLine("Premi 4- Inserire un nuovo agente");
                Console.WriteLine("Premi 0- Exit");

                string scelta = Console.ReadLine();
                switch (scelta)
                {
                    case "1":

                        Gestore.MostraAgenti();

                        break;

                    case "2":
                        Gestore.MostraAgentiperArea();
                        break;

                    case "3":
                        //agenti per anni servizio
                        break;

                    case "4":
                        Gestore.InserisciAgente();
                        break;

                    case "0":
                        return;

                }
            } while (true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova_6__Francesca_Dicugno
{
    static class Gestore
    {
        internal static void MostraAgenti()
        {
            List<Agente> Agenti = DbManagerConnectedMode.GetAllAgenti();


            foreach (var agenti in Agenti)
            {
                Console.WriteLine(agenti.StampaAgente());
            }

        }

        internal static void MostraAgentiperArea()
        {
            MostraAgenti();
            Console.WriteLine();
            Console.WriteLine("Inserisci area geografica");
            string area = Console.ReadLine();
           //dovrei verificare che l'aria sia esistente
            List<Agente> agente1 = DbManagerConnectedMode.GetAgenteperArea(area);

            foreach (var agenti in agente1)
            {
                Console.WriteLine(agenti.StampaAgente());
            }

        }

        internal static void InserisciAgente()
        {
            Console.WriteLine("Inserisci nome nuovo agente");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci cognome");
            string cognome = Console.ReadLine();
            Console.WriteLine("Inserisci Codice Fiscale");
            string codicefiscale = Console.ReadLine();
            Console.WriteLine();

            Agente agente= DbManagerConnectedMode.VerificaEsistenzaAgente(codicefiscale);
            
                if (codicefiscale == null)
                {
                
                    Console.WriteLine("Inserisci area geografica di servizio");
                    string area = Console.ReadLine();
                    Console.WriteLine("Inserisci l'anno di inizio servizio");
                    int annoinizio = Convert.ToInt32(Console.ReadLine());
                    agente = new Agente(nome, cognome, codicefiscale, area, annoinizio);
                    DbManagerConnectedMode.AddAgente(agente);
                }
                else
                {
                    Console.WriteLine("L'agente esiste già");
                }

            }
        }

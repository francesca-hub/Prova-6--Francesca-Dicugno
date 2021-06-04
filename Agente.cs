using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova_6__Francesca_Dicugno
{
 public class Agente: Persona
    {
        public  string AreaGeografica { get; set; }
        public int AnnoInizioServizio { get; set; }

        public  Agente(string nome, string cognome, string codicefiscale, string area, int annoinizio)
            :base(nome, cognome, codicefiscale)
        {
            AreaGeografica = area;
            AnnoInizioServizio = annoinizio;
        }



        public int AnniServizio()
        {
            int a;
            a = 2021 - AnnoInizioServizio;
            return a;
        }

        public string StampaAgente()
        {
            return $"Nome: {Nome} - Cognome : {Cognome} - Anni di servizio: {AnniServizio()}";
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova_6__Francesca_Dicugno
{
   public  class Persona
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }

        public Persona(string nome, string cognome, string codicefiscale)
        {
            Nome = nome;
            Cognome = cognome;
            CodiceFiscale = codicefiscale;

        }
    }
}

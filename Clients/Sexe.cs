using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio
{
    public class Sexe
    {
        public int IdSexe { get; set; }
        public string Nom { get; set; }

        public Sexe(Sexes sexe)
        {
            if (sexe == Sexes.Masculin)
            {
                Nom = "Masculin";
            }
            else if (sexe == Sexes.Feminin)
            {
                Nom = "Feminin";
            }
        }
    }
}

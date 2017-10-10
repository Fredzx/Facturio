using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio
{
    public class Sexe
    {
        public virtual int? IdSexe { get; set; } = null;
        public virtual string Nom { get; set; } = string.Empty;

        public Sexe() { }

        public Sexe(Sexes sexe)
        {
            switch (sexe)
            {
                case Sexes.Masculin: Nom = "Masculin"; break;
                case Sexes.Feminin: Nom = "Féminin"; break;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Sexe s = obj as Sexe;

            if (s == null)
            {
                return false;
            }

            return this.IdSexe == s.IdSexe;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}

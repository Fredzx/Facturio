using Facturio.Enums;

namespace Facturio.Clients
{
    public class Sexe
    {
        public int? IdSexe { get; set; } = null;
        public string Nom { get; set; } = string.Empty;

        public Sexe() {}

        public Sexe(Sexes sexe)
        {
            switch (sexe)
            {
                case Sexes.Masculin: Nom = "Masculin"; break;
                case Sexes.Feminin: Nom = "Féminin"; break;
            }
        }
    }
}

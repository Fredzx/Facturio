using Facturio.Enums;

namespace Facturio
{
    public class Province
    {
        public virtual int? IdProvince { get; set; } = null;
        public virtual string Nom { get; set; } = string.Empty;

        public Province() { }

        public Province(Provinces province)
        {
            switch (province)
            {
                case Provinces.Alberta:                 Nom = "Alberta"; break;
                case Provinces.ColombieBritannique:     Nom = "Columbien-Britannique"; break;
                case Provinces.IleDuPrinceEdouard:      Nom = "Île-du-Prince-Édouard"; break;
                case Provinces.Manitoba:                Nom = "Manitoba"; break;
                case Provinces.NouveauBrunswick:        Nom = "Nouveau-Brunswick"; break;
                case Provinces.NouvelleEcosse:          Nom = "Nouvelle-Écosse"; break;
                case Provinces.Ontario:                 Nom = "Ontario"; break;
                case Provinces.Quebec:                  Nom = "Québec"; break;
                case Provinces.Saskatchewan:            Nom = "Saskatchewan"; break;
                case Provinces.TerreNeuveEtLabrador:    Nom = "Terre-Neuve-et-Labrador"; break;
                case Provinces.Nunavut:                 Nom = "Nunavut"; break;
                case Provinces.TerritoiresDuNordOuest:  Nom = "Territoires de Nord-Ouest"; break;
                case Provinces.Yukon:                   Nom = "Yukon"; break;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Province p = obj as Province;

            if (p == null)
            {
                return false;
            }

            return IdProvince == p.IdProvince;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}

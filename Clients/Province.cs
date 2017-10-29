using Facturio.Enums;

namespace Facturio.Clients
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
                case Provinces.ColombieBritannique:     Nom = "Colombie-Britannique"; break;
                case Provinces.IleDuPrinceEdouard:      Nom = "île-du-Prince-Edouar"; break;
                case Provinces.Manitoba:                Nom = "Manitoba"; break;
                case Provinces.NouveauBrunswick:        Nom = "Nouveau-Brunswick"; break;
                case Provinces.NouvelleEcosse:          Nom = "Nouvelle-Ecosse"; break;
                case Provinces.Nunavut:                 Nom = "Nunavut"; break;
                case Provinces.Ontario:                 Nom = "Ontario"; break;
                case Provinces.Quebec:                  Nom = "Québec"; break;
                case Provinces.Saskatchewan:            Nom = "Saskatchewan"; break;
                case Provinces.TerreNeuveEtLabrador:    Nom = "Terre-Neuve-et-Labra"; break;                
                case Provinces.TerritoiresDuNordOuest:  Nom = "Territoires du Nord-"; break;
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

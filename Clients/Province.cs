using Facturio.Enums;

namespace Facturio.Clients
{
    public class Province
    {
        public int? IdProvince { get; set; } = null;
        public string Nom { get; set; } = string.Empty;

        public Province() {}

        public Province(Provinces province)
        {
            switch (province)
            {
                case Provinces.Alberta: Nom = "Alberta"; break;
                case Provinces.ColombieBritannique: Nom = "Columbien-Britannique"; break;
                case Provinces.IleDuPrinceEdouard: Nom = "Île-du-Prince-Édouard"; break;
                case Provinces.Manitoba: Nom = "Manitoba"; break;
                case Provinces.NouveauBrunswick: Nom = "Nouveau-Brunswick"; break;
                case Provinces.NouvelleEcosse: Nom = "Nouvelle-Écosse"; break;
                case Provinces.Ontario: Nom = "Ontario"; break;
                case Provinces.Quebec: Nom = "Québec"; break;
                case Provinces.Saskatchewan: Nom = "Saskatchewan"; break;
                case Provinces.TerreNeuveEtLabrador: Nom = "Terre-Neuve-et-Labrador"; break;
                case Provinces.Nunavut: Nom = "Nunavut"; break;
                case Provinces.TerritoiresDuNordOuest: Nom = "Territoires de Nord-Ouest"; break;
                case Provinces.Yukon: Nom = "Yukon"; break;
            }
        }
    }
}

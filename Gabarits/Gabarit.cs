namespace Facturio.Gabarits
{
    public class Gabarit
    {
        public virtual string TitreGabarit { get; set; }

        public virtual int Id { get; set; } = 0;
        public virtual int CodeProduit { get; set; } = 0;
        public virtual int NomProduit { get; set; } = 0;
        public virtual int Description { get; set; } = 0;
        public virtual int Prix { get; set; } = 0;
        public virtual int Quantite { get; set; } = 0;
        public virtual int PrenomClient { get; set; } = 0;
        public virtual int NomClient { get; set; } = 0;
        public virtual int AdresseClient { get; set; } = 0;
        public virtual int CodePostalClient { get; set; } = 0;
        public virtual int Escompte { get; set; } = 0;
        public virtual int CritereLibre { get; set; } = 0;
        public virtual int NombreHeures { get; set; } = 0;
        public virtual int TauxHoraire { get; set; } = 0;

        public Gabarit() {}

        public Gabarit(string titreGabarit, int codeProduit, int nomProduit, int description,
                       int prix, int quantite, int prenomClient, int nomClient,
                       int adresseClient, int codePostalClient, int escompte, int critereLibre,
                       int nombreHeures, int tauxHoraire)
        {
            TitreGabarit = titreGabarit;
            CodeProduit = codeProduit;
            NomProduit = nomProduit;
            Description = description;
            Prix = prix;
            Quantite = quantite;
            PrenomClient = prenomClient;
            NomClient = nomClient;
            AdresseClient = adresseClient;
            CodePostalClient = codePostalClient;
            Escompte = escompte;
            CritereLibre = critereLibre;
            NombreHeures = nombreHeures;
            TauxHoraire = tauxHoraire;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Gabarit gabarit = obj as Gabarit;

            return Id == gabarit?.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

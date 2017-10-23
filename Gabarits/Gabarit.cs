using System;

namespace Facturio.Gabarits
{
    public class Gabarit
    {
        public virtual string TitreGabarit { get; set; }

        public virtual int Id { get; set; }
        public virtual DateTime DateCreation { get; set; }
        public virtual int CodeProduit { get; set; }
        public virtual int NomProduit { get; set; }
        public virtual int Description { get; set; }
        public virtual int Prix { get; set; }
        public virtual int Quantite { get; set; }
        public virtual int PrenomClient { get; set; }
        public virtual int NomClient { get; set; }
        public virtual int AdresseClient { get; set; }
        public virtual int CodePostalClient { get; set; }
        public virtual int Escompte { get; set; }
        public virtual int CritereLibre { get; set; }
        public virtual int NombreHeures { get; set; }
        public virtual int TauxHoraire { get; set; }

        public Gabarit() {}

        public Gabarit(string titreGabarit, DateTime dateCreation, int codeProduit, int nomProduit,
                       int description, int prix, int quantite, int prenomClient, int nomClient,
                       int adresseClient, int codePostalClient, int escompte, int critereLibre,
                       int nombreHeures, int tauxHoraire)
        {
            TitreGabarit = titreGabarit;
            DateCreation = dateCreation;
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
            Gabarit gabarit = obj as Gabarit;

            return Id == gabarit?.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

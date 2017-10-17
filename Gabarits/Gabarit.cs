namespace Facturio.Gabarits
{
    public class Gabarit
    {
        public string Titre { get; set; }

        public virtual int Id { get; set; } = 0;
        public virtual int PrenomClient { get; set; } = 0;
        public virtual int NomClient { get; set; } = 0;
        public virtual int Quantite { get; set; } = 0;
        public virtual int Prix { get; set; } = 0;
        public virtual int Description { get; set; } = 0;
        public virtual int AdresseClient { get; set; } = 0;
        public virtual int CodePostalClient { get; set; } = 0;
        public virtual int Escompte { get; set; } = 0;
        public virtual int CritereLibre { get; set; } = 0;
        public virtual int NombreHeures { get; set; } = 0;
        public virtual int TauxHoraire { get; set; } = 0;

        public Gabarit() {}
    }
}

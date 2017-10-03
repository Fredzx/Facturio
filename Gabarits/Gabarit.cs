namespace Facturio.Gabarits
{
    public class Gabarit
    {
        private readonly uint idGabarit;

        public uint PrenomClient { get; set; }
        public uint NomClient { get; set; }
        public uint Quantite { get; set; }
        public uint Prix { get; set; }
        public uint Description { get; set; }
        public uint AdresseClient { get; set; }
        public uint CodePostalClient { get; set; }
        public uint Escompte { get; set; }
        public uint CritereLibre { get; set; }
        public uint NombreHeures { get; set; }
        public uint TauxHoraire { get; set; }
    }
}

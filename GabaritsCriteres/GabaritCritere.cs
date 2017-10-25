using Facturio.Gabarits;
using Facturio.Criteres;

namespace Facturio.GabaritsCriteres
{
    public class GabaritCritere
    {
        public virtual int Id { get; set; }
        public virtual Gabarit Gabarit { get; set; }
        public virtual Critere Critere { get; set; }
        public virtual int Position { get; set; }
        public virtual int Largeur { get; set; }
        public virtual bool EstUtilise { get; set; }

        public GabaritCritere() {}

        public GabaritCritere(Gabarit gabarit, Critere critere,
                              int position, int largeur,
                              bool estUtilise)
        {
            Gabarit = gabarit;
            Critere = critere;
            Position = position;
            Largeur = largeur;
            EstUtilise = estUtilise;
        }

        public override bool Equals(object obj)
        {
            GabaritCritere gabaritCritere = obj as GabaritCritere;

            return Gabarit?.Id == gabaritCritere?.Gabarit?.Id && Critere?.Id == gabaritCritere?.Critere?.Id;
            // return Id == gabaritCritere?.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

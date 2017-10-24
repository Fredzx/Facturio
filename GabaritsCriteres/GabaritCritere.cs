namespace Facturio.GabaritsCriteres
{
    public class GabaritCritere
    {
        public virtual int Id { get; set; }
        public virtual int IdGabarit { get; set; }
        public virtual int IdCritere { get; set; }
        public virtual int Position { get; set; }
        public virtual int Largeur { get; set; }
        public virtual bool EstUtilise { get; set; }

        public GabaritCritere() {}

        public GabaritCritere(int idGabarit, int idCritere,
                              int position, int largeur,
                              bool estUtilise)
        {
            IdGabarit = idGabarit;
            IdCritere = idCritere;
            Position = position;
            Largeur = largeur;
            EstUtilise = estUtilise;
        }

        public override bool Equals(object obj)
        {
            GabaritCritere gabaritCritere = obj as GabaritCritere;

            return Id == gabaritCritere?.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

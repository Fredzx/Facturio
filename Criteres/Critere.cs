namespace Facturio.Criteres
{
    public class Critere
    {
        public virtual int Id { get; set; }
        public virtual string Titre { get; set; }

        public Critere() {}

        public Critere(string titre)
        {
            Titre = titre;
        }

        public override bool Equals(object obj)
        {
            Critere critere = obj as Critere;

            return Id == critere?.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

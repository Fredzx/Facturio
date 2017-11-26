namespace Facturio.GabaritsCriteres
{
    public class TypeCritere
    {
        public virtual int Id { get; set; }
        public virtual string TypeDuCritere { get; set; }
        public virtual string Nom { get; set; }

        public TypeCritere() {}

        public TypeCritere(string typeDuCritere, string nom)
        {
            TypeDuCritere = typeDuCritere;
            Nom = nom;
        }

        public override bool Equals(object obj)
        {
            TypeCritere typeCritere = obj as TypeCritere;

            return Id == typeCritere?.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
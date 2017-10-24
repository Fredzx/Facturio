using Facturio.GabaritsCriteres;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Facturio.Criteres
{
    public class Critere
    {
        public virtual int Id { get; set; }
        public virtual string Titre { get; set; }
        public virtual ISet<GabaritCritere> Gabarits { get; set; }

        public Critere() {}

        public Critere(string titre)
        {
            Titre = titre;
            Gabarits = new HashSet<GabaritCritere>();
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

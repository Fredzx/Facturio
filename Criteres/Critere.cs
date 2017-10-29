using System.Collections.Generic;
using System.Collections.ObjectModel;
using Facturio.GabaritsCriteres;

namespace Facturio.Criteres
{
    public class Critere
    {
        #region Propriétés

        public virtual int Id { get; set; }
        public virtual TypeCritere TypeCritere { get; set; }
        public virtual string Titre { get; set; }
        public virtual ICollection<GabaritCritere> Gabarits { get; set; }

        #endregion

        #region Constructeurs

        public Critere() {}

        public Critere(string titre, TypeCritere typeCritere)
        {
            Titre = titre;
            TypeCritere = typeCritere;
            Gabarits = new ObservableCollection<GabaritCritere>();
        }

        #endregion

        #region Méthodes

        public override bool Equals(object obj)
        {
            Critere critere = obj as Critere;

            return Id == critere?.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}

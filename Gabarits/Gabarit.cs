using System;
using System.Collections.Generic;
using Facturio.GabaritsCriteres;
using Facturio.Base;

namespace Facturio.Gabarits
{
    public class Gabarit
    {
        #region Propriétés

        public virtual int Id { get; set; }
        public virtual string TitreGabarit { get; set; }
        public virtual DateTime DateCreation { get; set; }
        public virtual ISet<GabaritCritere> Criteres { get; set; }

        #endregion

        #region Constructeurs

        public Gabarit() {}

        public Gabarit(string titreGabarit, DateTime dateCreation)
        {
            TitreGabarit = titreGabarit;
            DateCreation = dateCreation;
            Criteres = new ObservableHashSet<GabaritCritere>();
            // Criteres = new HashSet<GabaritCritere>();
        }

        #endregion

        #region Méthodes

        public override bool Equals(object obj)
        {
            Gabarit gabarit = obj as Gabarit;

            return Id == gabarit?.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}

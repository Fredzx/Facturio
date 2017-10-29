using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Facturio.GabaritsCriteres;

namespace Facturio.Gabarits
{
    public class Gabarit
    {
        #region Propriétés

        public virtual int Id { get; set; }
        public virtual string TitreGabarit { get; set; }
        public virtual DateTime DateCreation { get; set; }
        public virtual ICollection<GabaritCritere> GabaritCriteres { get; set; }

        #endregion

        #region Constructeurs

        public Gabarit() {}

        public Gabarit(string titreGabarit, DateTime dateCreation)
        {
            TitreGabarit = titreGabarit;
            DateCreation = dateCreation;
            GabaritCriteres = new ObservableCollection<GabaritCritere>();
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

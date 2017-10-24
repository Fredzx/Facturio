using System;
using System.Collections.Generic;
using Facturio.Factures;
using System.Collections.ObjectModel;

namespace Facturio.Rapports
{
    /// <summary>
    /// Rapport permet de compiler des factures afin d'exercer des calculs
    /// et d'obtenir des résultats
    /// </summary>
    public class Rapport
    {

        // virtual pcq Nhibernate l'oblige
        public virtual int? IdRapport { get; set; } = null;
        public virtual DateTime? Date { get; set; } = null;
        public virtual IList<Facture> LstFacture { get; set; }
        
        public Rapport() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateRapport">Date de sortie du rapport</param>
        public Rapport(DateTime dateRapport)
        {
            Date = dateRapport;
            LstFacture = new List<Facture>();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Rapport r = obj as Rapport;

            if (r == null)
            {
                return false;
            }

            return this.IdRapport == r.IdRapport;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}

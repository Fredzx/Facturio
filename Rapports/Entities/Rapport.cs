using System;
using System.Collections.Generic;
using Facturio.Factures;
using System.Collections.ObjectModel;
using Facturio.RapportsFactures;

namespace Facturio.Rapports.Entities
{
    /// <summary>
    /// Rapport permet de compiler des factures afin d'exercer des calculs
    /// et d'obtenir des résultats
    /// </summary>
    public class Rapport
    {
        // virtual pcq Nhibernate l'oblige
        public virtual int? IdRapport { get; set; } = null;
        public virtual DateTime Date { get; set; } = DateTime.MinValue;
        public virtual IList<RapportFacture> LstRapportFacture { get; set; }

        public virtual string Objet { get { return GetObject(); } set { Objet = value; } }

        public virtual string TypeRapport { get{ return GetTypeRapport();} set{ TypeRapport = value; }}
        public Rapport() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateRapport">Date de sortie du rapport</param>
        public Rapport(DateTime dateRapport)
        {
            Date = dateRapport;
            LstRapportFacture = new List<RapportFacture>();
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

        public virtual string GetTypeRapport()
        {
            return "Rapport";
        }

        public virtual string GetObject()
        {
            return "Aucun objet";
        }
    }
}

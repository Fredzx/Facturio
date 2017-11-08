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
        public virtual IList<RapportFacture> LstFacture { get; set; }

        //temporaire
        //public virtual string Client { get; set; }
        //public virtual string TypeRapport { get; set; }

        public Rapport() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateRapport">Date de sortie du rapport</param>
        public Rapport(DateTime dateRapport)
        {
            Date = dateRapport;
            LstFacture = new List<RapportFacture>();
        }
        // Ce constructeur est temporaire, seulement pour la version 0.5
        //public Rapport(string client, DateTime date, List<Facture> lstFacture, string typeRapport)
        //{
        //    Client = client;
        //    Date = date;
        //    LstFacture = new List<Facture>(lstFacture);
        //    TypeRapport = typeRapport;
        //}

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

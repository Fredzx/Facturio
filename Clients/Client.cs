using Facturio.Enums;

namespace Facturio.Clients
{
    public class Client
    {
        public virtual int? IdClient { get; set; } = null;
        public virtual string NoClient { get; set; } = string.Empty;
        public virtual string Prenom { get; set; } = string.Empty;
        public virtual string Nom { get; set; } = string.Empty;
        public virtual string Description { get; set; } = string.Empty;
        public virtual Sexe Sexe { get; set; }
        public virtual string Adresse { get; set; } = string.Empty;
        public virtual string CodePostal { get; set; } = string.Empty;
        public virtual string Telephone { get; set; } = string.Empty;
        public virtual Rang Rang { get; set; }
        public virtual Province Province { get; set; }
        public virtual bool EstActif { get; set; } = true;

        public Client() {}

        public Client(string prenom, string nom, string description,
                      Sexe sexe, string adresse, string codePostal,
                      string telephone, Rang rang, Province province, bool estActif)
        {            
            Prenom = prenom;
            Nom = nom;
            Description = description;
            Sexe = sexe;
            Adresse = adresse;
            CodePostal = codePostal;
            Telephone = telephone;
            Rang = rang;
            Province = province;
            EstActif = estActif;

            // Ici, affecter un UUID au NoClient (pas trop long le UUID, résonable)
        }


        // Pour utiliser NHibernate, il faut surcharger Equals et GetHashCode.
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Client c = obj as Client;

            if (c == null)
            {
                return false;
            }

            return this.IdClient == c.IdClient;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}

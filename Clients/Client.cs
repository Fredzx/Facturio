namespace Facturio.Clients
{

    public class Client
    {
        public int IdClient { get; set; }
        public string Adresse { get; set; }
        public string NoClient { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public Sexe Sexe { get; set; }
        public string Telephone { get; set; }
        public string Description { get; set; }
        public Rang Rang { get; set; }

        public Client(string prenom, string adresse, string nom, Sexe sexe, 
                      string telephone, string noClient, string description)
        {
            Adresse = adresse;
            NoClient = noClient;
            Prenom = prenom;
            Nom = nom;
            Telephone = telephone;
            Sexe = sexe;
            Description = description;
        }
    }
}

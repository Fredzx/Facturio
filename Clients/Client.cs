namespace Facturio.Clients
{

    public class Client
    {
        public int IdClient { get; set; }
        public string Adresse { get; set; }
        public string NoClient { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Sexe { get; set; }
        public string Telephone { get; set; }
        public string Description { get; set; }
        public string CodePostal { get; set; }
        public int Rang { get; set; }

        public Client(string prenom,    string adresse,  string nom, string sexe, 
                      string telephone, string description,
                      string codePostal, int rang)
        {
            Adresse = adresse;
           // NoClient = noClient;
            Prenom = prenom;
            Nom = nom;
            Telephone = telephone;
            Sexe = sexe;
            Description = description;
            Rang = rang;
            CodePostal = codePostal;
        }
    }
}

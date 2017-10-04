namespace Facturio.Clients
{

    public class Client
    {
        public int? IdClient { get; set; } = null;
        public string NoClient { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Sexe Sexe { get; set; } = new Sexe(Sexes.Masculin);
        public string Adresse { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public Rang Rang { get; set; } = new Rang();
        public Province Province { get; set; } = new Province();

        public Client() {}

        public Client(string prenom, string nom, string description,
                      Sexe sexe, string adresse, string telephone, Rang rang)
        {
            Prenom = prenom;
            Nom = nom;
            Description = description;
            Sexe = sexe;
            Adresse = adresse;
            Telephone = telephone;
            Rang = rang;

            // Ici, affecter un UUID au NoClient (pas trop long le UUID, résonable)
        }
    }
}

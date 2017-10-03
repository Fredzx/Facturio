using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Facturio.Clients
{
    
    public class Client
    {
        public string Adresse { get; set; }
        public string NoClient { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Sexe { get; set; }
        public string Telephone { get; set; }
        public string Description { get; set; }



        public Client(string prenom, string adresse, string nom, string sexe, 
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

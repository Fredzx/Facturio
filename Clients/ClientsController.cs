using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facturio.Base;

namespace Facturio.Clients
{
    public class ClientsController : BaseViewModel, IOngletViewModel
    {
        public static ObservableCollection<Client> LstObClients { get; set; } = new ObservableCollection<Client>();
        public static Client LeClient { get; set; }
        public string Titre { get; set; }
 

        public ClientsController()
        {
            Titre = "Clients";
           

            LstObClients = new ObservableCollection<Client>(HibernateClientService.RetrieveAll());

        }

        public static void ChargerListeClients()
        {
            LstObClients = new ObservableCollection<Client>(HibernateClientService.RetrieveAll());

        }

        public static void AjouterClient(Client client)
        {
            // Retrieve les infos (sexe, rang et province)
            client.Sexe.IdSexe = HibernateSexeService.RetrieveByName(client.Sexe.Nom)[0].IdSexe;

            client.Rang.IdRang = HibernateRangService.RetrieveByName(client.Rang.Nom)[0].IdRang;

            client.Province.IdProvince = HibernateProvinceClient.RetrieveByName(client.Province.Nom)[0].IdProvince;


            // Ajouter le client en BD.
            HibernateClientService.Create(client);

            // Ajouter le client à la liste.
            LstObClients.Add(client);
        }

        public static void SupprimerClient(Client client)
        {
            
            if(client != null)
            {
                HibernateClientService.Delete(client);
                LstObClients.Remove(client);

            }
            return; 
        }

        public static void AfficherClient()
        {
            // Afficher les infos
            AjoutModifUserControl.SetChampsModifier();
            
        }

        public static void ModifierClient(Sexe sexe, Province province, Rang rang)
        {

            // Setter les champs
            LeClient.Prenom = AjoutModifUserControl.TxtPrenom.Text.ToString();
            LeClient.Nom = AjoutModifUserControl.TxtNom.Text.ToString();
            LeClient.Description = AjoutModifUserControl.TxtDescription.Text.ToString();

            
            LeClient.Adresse = AjoutModifUserControl.TxtAdresse.Text.ToString();
            LeClient.CodePostal = AjoutModifUserControl.TxtCodePostal.Text.ToString();
            LeClient.Telephone = AjoutModifUserControl.TxtTelephone.Text.ToString();


            // Sexe
            Sexe s;
            s = HibernateSexeService.RetrieveByName(sexe.Nom)[0];
            LeClient.Sexe = s;

            // Rang
            Rang r;
            r = HibernateRangService.RetrieveByName(rang.Nom)[0];
            LeClient.Rang = r;

            // Province
            //LeClient.Province.Nom = province.Nom;
            Province p;
            p = HibernateProvinceClient.RetrieveByName(province.Nom)[0];
            LeClient.Province = p;           

            
            // Update en BD.
            HibernateClientService.Update(LeClient);

            // Update en liste
            LstObClients.Remove(LeClient);
            LstObClients.Add(LeClient);

           
        }

        public static string SetNoClient()
        {
            int no = LstObClients.Count;

            

            return no.ToString();
        }

        public static void AfficherOngletRechercher()
        {
            ClientsUserControl.TbcClientPublic.SelectedIndex = 0;
        }

        public static void LiveFiltering(string filter)
        {
            LstObClients = new ObservableCollection<Client>(HibernateClientService.RetrieveFilter(filter));
        }

        public static void RafraichirGrille()
        {
            LstObClients = new ObservableCollection<Client>(HibernateClientService.RetrieveAll());
            RechercherUserControl.DtgClients.ItemsSource = null;
            RechercherUserControl.DtgClients.ItemsSource = LstObClients;
        }
    }
}

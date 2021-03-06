﻿using System.Collections.ObjectModel;
using Facturio.Base;

namespace Facturio.Clients
{
    public class ClientsController : BaseViewModel, IOngletViewModel
    {
        #region Propriétés
        public static ObservableCollection<Client> LstObClients { get; set; } = new ObservableCollection<Client>();
        public static Client LeClient { get; set; }
        public string Titre { get; set; }
        #endregion

        public ClientsController()
        {
            Titre = "Clients";
            LstObClients = new ObservableCollection<Client>(HibernateClientService.RetrieveAll());
        }

        #region Méthodes
        public static void ChargerListeClients(int status)
        {
            switch (status)
            {
                case 0: LstObClients = new ObservableCollection<Client>(HibernateClientService.RetrieveActif());break;
                case 1: LstObClients = new ObservableCollection<Client>(HibernateClientService.RetrieveInactif()); break;
                case 2: LstObClients = new ObservableCollection<Client>(HibernateClientService.RetrieveAll()); break;
                default:
                    LstObClients = new ObservableCollection<Client>(HibernateClientService.RetrieveAll()); break;
            }
            RafraichirGrille(true);
        }
        public static void AjouterClient(Client client)
        {
            // Retrieve les infos (sexe, rang et province)
            client.Sexe.IdSexe = HibernateSexeService.RetrieveByName(client.Sexe.Nom)[0].IdSexe;

            client.Rang.IdRang = HibernateRangService.RetrieveByName(client.Rang.Nom)[0].IdRang;

            client.Province.IdProvince = HibernateProvinceClient.RetrieveByName(client.Province.Nom)[0].IdProvince;

            client.NoClient = SetNoClient(client);

            // Ajouter le client en BD.
            HibernateClientService.Create(client);

            // Ajouter le client à la liste.
            LstObClients.Add(client);
        }
        public static void SupprimerClient(Client client)
        {
            
            if(client != null)
            {
                client.EstActif = false;
                HibernateClientService.Update(client);
                ChargerListeClients(2);
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

            // Actif/Inactif

            LeClient.EstActif = (bool)AjoutModifUserControl.CbxActif.IsChecked;
        

            // Update en BD.
            HibernateClientService.Update(LeClient);

            // Update en liste
            LstObClients.Remove(LeClient);
            LstObClients.Add(LeClient);

           
        }
        public static string SetNoClient(Client client)
        {
            int no = LstObClients.Count + 1000;
            string noClient = no.ToString();
            noClient += "-";
            noClient += client.Nom[0].ToString().ToUpper();
            noClient += client.Nom[2].ToString().ToLower();

            //noClient += client.Prenom.ToString().ToLower()
            //noClient += client.Prenom[1].ToString().ToLower();
            //noClient += client.Prenom[0];
            noClient += client.Nom.GetHashCode();

            return noClient;
        }
        public static void AfficherOngletRechercher()
        {
            ClientsUserControl.TbcClientPublic.SelectedIndex = 0;           
        }
        public static void LiveFiltering(string filter, int status)
        {
            LstObClients = new ObservableCollection<Client>(HibernateClientService.RetrieveFilter(filter, status));
        }
        public static void RafraichirGrille(bool estFiltre)
        {
            if (!estFiltre)            
            LstObClients = new ObservableCollection<Client>(HibernateClientService.RetrieveAll());
            RechercherUserControl.DtgClients.ItemsSource = null;
            RechercherUserControl.DtgClients.ItemsSource = LstObClients;
        }
        #endregion
    }
}

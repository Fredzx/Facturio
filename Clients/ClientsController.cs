﻿using System;
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

        public string Titre { get; set; }
 

        public ClientsController()
        {
            Titre = "Clients";
            ChargerListeClients();

          
        }

        public static void ChargerListeClients()
        {
            List<Client> lstClient = new List<Client>(HibernateClientService.RetrieveAll());

            LstObClients.Clear();

            foreach (Client client in lstClient)
                LstObClients.Add(client);

            //LstClients.AddRange(HibernateClientService.RetrieveAll());

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

        public static void ModifierClient(Client client)
        {
            // Initialiser les champs de la fenêtre.         
            AjoutModifUserControl.TxtNom.Text = client.Nom;
            AjoutModifUserControl.TxtPrenom.Text = client.Prenom;
            AjoutModifUserControl.TxtAdresse.Text = client.Adresse;
            AjoutModifUserControl.CboProvince.SelectedIndex = (int)client.Province.IdProvince;
            AjoutModifUserControl.TxtCodePostal.Text = client.CodePostal;
            AjoutModifUserControl.TxtDescription.Text = client.Description;
            AjoutModifUserControl.TxtTelephone.Text = client.Telephone;
            AjoutModifUserControl.CboRang.SelectedIndex = (int)client.Rang.IdRang;

            if(client.Sexe.IdSexe == 1)
            {
                AjoutModifUserControl.RdbHomme.IsChecked = true;
            }
            else
            {
                AjoutModifUserControl.RdbFemme.IsChecked = true;
            }
        }
    }
}

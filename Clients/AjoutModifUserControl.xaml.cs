using Facturio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Facturio.Clients
{
    /// <summary>
    /// Logique d'interaction pour FormClientUserControl.xaml
    /// </summary>
    public partial class AjoutModifUserControl : UserControl
    {
        public bool Ajout { get; set; } = true;
        public static Label LblFormTitle { get; set; } = new Label();
        public static TextBox TxtNom { get; set; } = new TextBox();
        public static TextBox TxtPrenom { get; set; } = new TextBox();
        public static TextBox TxtAdresse { get; set; } = new TextBox();
        public static ComboBox CboProvince { get; set; } = new ComboBox();
        public static TextBox TxtCodePostal { get; set; } = new TextBox();
        public static TextBox TxtDescription { get; set; } = new TextBox();
        public static TextBox TxtTelephone { get; set; } = new TextBox();
        public static ComboBox CboRang { get; set; } = new ComboBox();
        public static RadioButton RdbHomme { get; set; } = new RadioButton();
        public static RadioButton RdbFemme { get; set; } = new RadioButton();
       

        public AjoutModifUserControl()
        {
            InitializeComponent();
            LblFormTitle = lblFormTitle;
            TxtNom = txtNom;
            TxtPrenom = txtPrenom;
            TxtAdresse = txtAdresse;
            CboProvince = cboProvince;
            TxtCodePostal = txtCodePostal;
            TxtDescription = txtDescription;
            TxtTelephone = txtTelephone;
            CboRang = cboRang;
            RdbHomme = rdbHomme;
            RdbFemme = rdbFemme;
        }

       

        private void btnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            // L'utilisateur veut enregistrer les informations du client.
            // Vérifier si on est en ajout ou en modification.
            if (LblFormTitle.Content.ToString() == "Ajouter un client")
            {
                // TODO : Validation des informations entrées.  
                if (ValiderInformationsClient())
                {
                    // Ajouter le client à la liste et en BD.
                    ClientsController.AjouterClient(new Client(ClientsController.SetNoClient(), txtPrenom.Text.ToString(), txtNom.Text.ToString()
                                                             , txtDescription.Text.ToString(), new Sexe(SetSex())
                                                             , txtAdresse.Text.ToString(), txtCodePostal.Text.ToString()
                                                             , txtTelephone.Text.ToString(), SetRang(), new Province(SetProvince())));

                    // TODO :  Afficher un message qui dit que le client a été ajouter.
                    MessageBox.Show("Client ajouter avec succès");
                }     
            }
            else
            {
                if (ValiderInformationsClient())
                {
                    ClientsController.ModifierClient(new Sexe(SetSex()), new Province(SetProvince()), SetRang());

                    // Afficher le message de succès.
                    MessageBox.Show("Client modifié avec succès");

                    // Changer d'onglet.
                    ClientsController.AfficherOngletRechercher();                    
                }
            }
        }
        
        public static void SetChampsModifier()
        {
            
            // Initialiser les champs de la fenêtre.         
            TxtNom.Text = ClientsController.LeClient.Nom;
            TxtPrenom.Text = ClientsController.LeClient.Prenom;
            TxtAdresse.Text = ClientsController.LeClient.Adresse;
            CboProvince.SelectedIndex = 0;
            CboProvince.SelectedIndex = (int)ClientsController.LeClient.Province.IdProvince - 1;
            TxtCodePostal.Text = ClientsController.LeClient.CodePostal;
            TxtDescription.Text = ClientsController.LeClient.Description;
            TxtTelephone.Text = ClientsController.LeClient.Telephone;
            CboRang.SelectedIndex = (int)ClientsController.LeClient.Rang.IdRang - 1;            
            
            if (ClientsController.LeClient.Sexe.IdSexe == 1)
            {
                AjoutModifUserControl.RdbHomme.IsChecked = true;
            }
            else
            {
                AjoutModifUserControl.RdbFemme.IsChecked = true;
            }
        }

        private Rang SetRang()
        {
            Rang rang = new Rang();

            switch (cboRang.SelectedIndex + 1)
            {
                
                case 1: rang.Nom = "Sans Rang"; break;
                case 2: rang.Nom = "Bronze"; break;
                case 3: rang.Nom = "Argent"; break;
                case 4: rang.Nom = "Or"; break;
                default: rang.Nom = "Sans Rang"; break;
            }
            return rang;
        }

        private Provinces SetProvince()
        {
            switch (cboProvince.SelectedIndex + 1)
            {
                case 1: return Provinces.Alberta;
                case 2: return Provinces.ColombieBritannique;
                case 3: return Provinces.IleDuPrinceEdouard;
                case 4: return Provinces.Manitoba;
                case 5: return Provinces.NouveauBrunswick;
                case 6: return Provinces.NouvelleEcosse;
                case 7: return Provinces.Ontario;
                case 8: return Provinces.Quebec;
                case 9: return Provinces.Saskatchewan;
                case 10: return Provinces.TerreNeuveEtLabrador;
                case 11: return Provinces.Nunavut;
                case 12: return Provinces.TerritoiresDuNordOuest;
                case 13: return Provinces.Yukon;
                default: return Provinces.Alberta;
            }

        }

     

        private Sexes SetSex()
        {
            if ((bool)rdbHomme.IsChecked)
            {
                return Sexes.Masculin;
            }
            else
            {
                return Sexes.Feminin;
            }
        }

        private bool ValiderInformationsClient()
        {
            if (txtNom.Text.ToString() != "")
            {
                if (txtPrenom.Text.ToString() != "")
                {
                    if(txtAdresse.Text.ToString() != "")
                    {
                        if(cboProvince.SelectedIndex != -1)
                        {
                            if(txtCodePostal.Text.ToString() != "" && txtCodePostal.Text.ToString().Length == 6 )
                            {
                                if(txtTelephone.Text.ToString() != "")
                                {
                                    if((bool)rdbFemme.IsChecked || (bool)rdbHomme.IsChecked)
                                    {
                                        return true;
                                    }
                                    MessageBox.Show("Veuillez cocher un sexe.");
                                    return false;
                                }
                                MessageBox.Show("Veuillez entrer un numéro de téléphone");
                                return false;
                            }
                            MessageBox.Show("Veuillez entrer un code postal.");
                            return false;
                        }
                        MessageBox.Show("Veuillez choisir une province.");
                        return false;
                    }
                    MessageBox.Show("Veuillez entrer une adresse.");
                    return false;
                }
                MessageBox.Show("Veuillez entrer un prénom.");
                return false;
            }
            MessageBox.Show("Veuillez entrer un nom");
            return false;
        }

       

        private void btnViderChamps_Click(object sender, RoutedEventArgs e)
        {
            txtNom.Clear();
            txtPrenom.Clear();
            txtAdresse.Clear();
            cboProvince.SelectedIndex = -1;
            txtCodePostal.Clear();
            txtDescription.Clear();
            txtTelephone.Clear();
            cboRang.SelectedIndex = 0;
            rdbFemme.IsChecked = false;
            rdbHomme.IsChecked = false;

        }


       
    }
}

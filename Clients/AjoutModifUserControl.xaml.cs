using Facturio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        const int NOM_PRENOM_MAX = 20;
        const int NOM_PRENOM_MIN = 3;
        const int ADRESSE_MAX = 50;
        const int ADRESSE_MIN = 5;

        public bool Ajout { get; set; } = true;
        public static Label LblTxtNoClient { get; set; } = new Label();
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
        public static Label LblInfo { get; set; } = new Label();



        public AjoutModifUserControl()
        {
            InitializeComponent();
            LblTxtNoClient = txtNoClient;
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
            LblInfo = lblInfo;
            
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
                    LblTxtNoClient.Content = "En cours de génération...";
                    // Ajouter le client à la liste et en BD.
                    ClientsController.AjouterClient(new Client(txtPrenom.Text.ToString(), txtNom.Text.ToString()
                                                             , txtDescription.Text.ToString(), new Sexe(SetSex())
                                                             , txtAdresse.Text.ToString(), txtCodePostal.Text.ToString()
                                                             , txtTelephone.Text.ToString(), SetRang(), new Province(SetProvince()), true));

                    ViderChamps();
                    AfficherSuccesAjout();
                }     
            }
            else
            {
                if (ValiderInformationsClient())
                {
                    ClientsController.ModifierClient(new Sexe(SetSex()), new Province(SetProvince()), SetRang());

                    

                    // Afficher le succès de la modification.
                    AfficherSuccesModif();
                }
            }
        }

        private void AfficherSuccesModif()
        {                    
            LblInfo.Foreground = Brushes.Green;
            LblInfo.Content = "Le client a été modifié avec succès !";
        }

        private void AfficherSuccesAjout()
        {
            LblInfo.Foreground = Brushes.Green;
            LblInfo.Content = "Le client a été ajouté avec succès !";
        }

        public static void SetChampsModifier()
        {

            // Initialiser les champs de la fenêtre.       
            LblTxtNoClient.Content = ClientsController.LeClient.NoClient;
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
                
                case 1: rang.Nom = "unranked"; break;
                case 2: rang.Nom = "Bronze"; break;
                case 3: rang.Nom = "Argent"; break;
                case 4: rang.Nom = "Or"; break;
                default: rang.Nom = "unranked"; break;
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
                case 7: return Provinces.Nunavut;
                case 8: return Provinces.Ontario;
                case 9: return Provinces.Quebec;
                case 10: return Provinces.Saskatchewan;
                case 11: return Provinces.TerreNeuveEtLabrador;                
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
            if (txtNom.Text.ToString() != "" && txtNom.Text.Length <= NOM_PRENOM_MAX && txtNom.Text.Length >= NOM_PRENOM_MIN)
            {
                if (txtPrenom.Text.ToString() != "" && txtPrenom.Text.Length <= NOM_PRENOM_MAX && txtPrenom.Text.Length >= NOM_PRENOM_MIN)
                {
                    if(txtAdresse.Text.ToString() != "" && txtAdresse.Text.Length <= ADRESSE_MAX && txtAdresse.Text.Length >= ADRESSE_MIN)
                    {
                        if(cboProvince.SelectedIndex != -1)
                        {
                            var regexPC = new Regex(@"^[A-Z]\d[A-Z]\d[A-Z]\d$");                           
                            if (regexPC.IsMatch(txtCodePostal.Text))
                            {
                                var regexNT = new Regex(@"^\d\d\d\d\d\d\d\d\d\d$");
                                if (regexNT.IsMatch(txtTelephone.Text))
                                {
                                    if((bool)rdbFemme.IsChecked || (bool)rdbHomme.IsChecked)
                                    {
                                        return true;
                                    }
                                    AfficherErreur(7);
                                    return false;
                                }
                                AfficherErreur(6);
                                return false;
                            }
                            AfficherErreur(5);
                            return false;
                        }
                        AfficherErreur(4);
                        return false;
                    }
                    AfficherErreur(3);
                    return false;
                }
                AfficherErreur(2);
                return false;
            }
            AfficherErreur(1);
            return false;
        }

        private void AfficherErreur(int noErr)
        {
            LblInfo.Foreground = Brushes.Red;

            switch (noErr)
            {
                case 1: LblInfo.Content = "Veuillez entrer un nom pour le client.\nMinimum " + NOM_PRENOM_MIN + " caractères.\nMaximum " + NOM_PRENOM_MAX + " caractères."      ; break;
                case 2: LblInfo.Content = "Veuillez entrer prénom pour le client.\nMinimum " + NOM_PRENOM_MIN + " caractères.\nMaximum " + NOM_PRENOM_MAX + " caractères."; break;
                case 3: LblInfo.Content = "Veuillez entrer une adresse pour le client.\nMinimum " + ADRESSE_MIN + " caractères.\nMaximum " + ADRESSE_MAX + " caractères."; break;
                case 4: LblInfo.Content = "Veuillez choisir une province pour le client."; break;
                case 5: LblInfo.Content = "Veuillez entrer un code postal valide pour le client.\n Voici un exemple de format valide : J5K8E6 "; break;
                case 6: LblInfo.Content = "Veuillez entrer un numéro de téléphone valide pour le client.\n Voici un exemple de format valide: 4504567891 "; break;
                case 7: LblInfo.Content = "Veuillez choisir le sexe pour le client."; break;
                default:
                    break;
            }
        }

       

        private void btnViderChamps_Click(object sender, RoutedEventArgs e)
        {
            ViderChamps();

        }

        public static void ViderChamps()
        {
            TxtNom.Clear();
            TxtPrenom.Clear();
            TxtAdresse.Clear();
            CboProvince.SelectedIndex = -1;            
            TxtCodePostal.Clear();
            TxtDescription.Clear();
            TxtTelephone.Clear();
            CboRang.SelectedIndex = 0;
            RdbFemme.IsChecked = false;
            RdbHomme.IsChecked = false;
        }

        private bool ValiderTelephone()
        {
            int valide = 0;
            if (txtTelephone.Text.Length == 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (txtTelephone.Text[i] >= '0' && txtTelephone.Text[i] <= '9')
                    {
                        valide++;
                        if (valide == 10)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            ClientsController.AfficherOngletRechercher();
        }
    }


   
}

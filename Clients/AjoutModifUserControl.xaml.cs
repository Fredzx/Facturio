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
        public AjoutModifUserControl()
        {
            InitializeComponent();
            LblFormTitle = lblFormTitle;

     

        }
       

        private void btnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            // L'utilisateur veut enregistrer les informations du client.
            // Vérifier si on est en ajout ou en modification.
            if (Ajout)
            {
                // TODO : Validation des informations entrées.  
                if (ValiderInformationsClient())
                {
                    // Ajouter le client à la liste et en BD.
                    ClientsController.AjouterClient(new Client(txtPrenom.Text.ToString(), txtNom.Text.ToString()
                                                             , txtDescription.Text.ToString(), new Sexe(SetSex())
                                                             , txtAdresse.Text.ToString(), txtCodePostal.Text.ToString()
                                                             , txtTelephone.Text.ToString(), SetRang(), new Province(SetProvince())));

                    // TODO :  Afficher un message qui dit que le client a été ajouter.
                    MessageBox.Show("Client ajouter avec succès");
                }     
            }    
        }

        private Rang SetRang()
        {
            Rang rang = new Rang();

            switch (cboRang.SelectedIndex)
            {
                case 1: rang.Nom = "Bronze"; break;
                case 2: rang.Nom = "Argent"; break;
                case 3: rang.Nom = "Or"; break;
                default: rang.Nom = "Sans Rang"; break;
            }
            return rang;
        }

        private Provinces SetProvince()
        {
            switch (cboProvince.SelectedIndex)
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
    }
}

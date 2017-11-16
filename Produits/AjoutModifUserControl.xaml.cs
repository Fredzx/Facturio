using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Facturio.Produits
{
    /// <summary>
    /// Logique d'interaction pour Ajouter_ModifierUserControl.xaml
    /// </summary>
    public partial class AjoutModifUserControl : UserControl
    {
        public static Label LblFormTitle { get; set; } = new Label();
        public static TextBox TxtNom { get; set; } = new TextBox();
       // public static TextBox TxtCode { get; set; } = new TextBox();
        public static TextBox TxtDescription { get; set; } = new TextBox();
        public static TextBox TxtPrix { get; set; } = new TextBox();
        public static TextBox TxtQuantite { get; set; } = new TextBox();
        public static Label LblInfo { get; set; } = new Label();
        public static Grid GrdTitre { get; set; } = new Grid();
        public static bool EstModif { get; set; }

        public AjoutModifUserControl()
        {
            InitializeComponent();
            LblFormTitle = lblFormTitle;
            TxtNom = txtNom;
            TxtPrix = txtPrix;
            TxtQuantite = txtQuantite;
            TxtDescription = txtDescription;
           // TxtCode = txtCode;
            LblInfo = lblInfo;
            GrdTitre = grdTitre;
        }

        public void RemplirChampsModif(Produit p)
        {
            TxtNom.Text = p.Nom;
           // TxtCode.Text = p.Code;
            TxtDescription.Text = p.Description;
            TxtPrix.Text = p.Prix.ToString();
            TxtQuantite.Text = p.Quantite.ToString();
            EstModif = true;
        }

        private void updateChampsProduit()
        {
              //  ProduitsController.Produit.Code = txtCode.Text;
                ProduitsController.Produit.Description = txtDescription.Text;
                ProduitsController.Produit.Nom = txtNom.Text;
                ProduitsController.Produit.Prix = Convert.ToDecimal(txtPrix.Text);
                ProduitsController.Produit.Quantite = Convert.ToDouble(txtQuantite.Text);
                ProduitsController.Produit.Code = ProduitsController.GenererCodeProduit();
            //ProduitsController.Produit.EstActif = true;
        }

        private void btnEnregister_Click(object sender, RoutedEventArgs e)
        {
            bool EstSucces = false;
            if (EstModif)
            {
                if (ProduitsController.ValiderModif())
                {
                    updateChampsProduit();
                    if (!ProduitsController.VerifierInactif())
                    {
                        ProduitsController.UpdateProduit();
                        ProduitsController.SuccesModif();
                    }
                    else
                    {
                        ProduitsController.DemanderSiModifAncienDelete();
                    }
                    EstSucces = true;
                }
            }
            else
            {
                if (ProduitsController.ValiderAjout())
                {
                    ProduitsController.Produit = new Produit(txtNom.Text, "", txtDescription.Text, Convert.ToDecimal(txtPrix.Text), Convert.ToDouble(txtQuantite.Text), true);
                    ProduitsController.Produit.Code = ProduitsController.GenererCodeProduit();
                    if (!ProduitsController.VerifierInactif())
                    {
                        ProduitsController.AjoutProduit();
                        ProduitsController.SuccesAjout();
                        viderChamps();
                        EstSucces = true;
                    }
                    else
                    {
                        ProduitsController.DemanderSiModifAncienDelete();
                    }
                }
            }
            if (EstSucces)
                ProduitsController.RafraichirGrille(false);
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            ProduitsController.reinitialiserOnglet();
            // Lorsqu'il clique sur Retour on veut : 
            // Que le usercontrol Produit change d'onglet > direction : onglet rechercher.
            ProduitsController.RafraichirGrille(false);
            ProduitUserControl.TbcProduitPublic.SelectedIndex = 0;
        }

        public static void viderChamps()
        {
            TxtNom.Text = "";
            //TxtCode.Text = "";
            TxtDescription.Text = "";
            TxtPrix.Text = "";
            TxtQuantite.Text = "";
        }
    }
}

using System.Collections.ObjectModel;
using System.Windows;
using Facturio.Base;

namespace Facturio.Gabarits.ViewModel
{
    public class ListeGabaritsViewModel : BaseViewModel
    {
        private ObservableCollection<Gabarit> _gabarits = new ObservableCollection<Gabarit>();

        public Gabarit SelectionCourante { get; set; }

        public ListeGabaritsViewModel()
        {

        }

        private void BtnNouveau_Click(object sender, RoutedEventArgs e)
        {
            //(Application.Current.MainWindow as FacturioPrincipale).tabMain.SelectedIndex = 1;
        }
    }
}

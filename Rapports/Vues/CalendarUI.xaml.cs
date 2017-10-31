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

namespace Facturio.Rapports.Vues
{
    /// <summary>
    /// Interaction logic for CalendarUI.xaml
    /// </summary>
    public partial class CalendarUI : UserControl
    {
        public static event EventHandler<DateEventArgs> ButtonClick;
        public static event EventHandler<CalendarDateChangedEventArgs> SelectionChanged;
        public void OnObtenirRapportClicked(DateEventArgs e)
        {
            ButtonClick?.Invoke(this, e);
        }

        public CalendarUI()
        {
            InitializeComponent();

            //btnObtenirRapport.IsEnabled = false;
            cldDateFin.SelectedDate = DateTime.Today;
            
        }

        private void btnRapportPDF_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObtenirRapport_Click(object sender, RoutedEventArgs e)
        {
            OnObtenirRapportClicked(new DateEventArgs(cldDateDebut.SelectedDate.Value, cldDateFin.SelectedDate.Value));


        }
    }

    public class DateEventArgs : EventArgs
    {
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public DateEventArgs(DateTime dateDebut, DateTime dateFin)
        {
            DateDebut = dateDebut;
            DateFin = dateFin;
        }
    }


    public class CalendarDateChangedEventArgs : EventArgs
    {

    }

}

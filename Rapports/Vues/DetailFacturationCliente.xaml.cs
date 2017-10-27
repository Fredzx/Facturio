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
using System.Windows.Shapes;

namespace Facturio.Rapports.Vues
{
    /// <summary>
    /// Logique d'interaction pour DetailFacturationCliente.xaml
    /// </summary>
    public partial class DetailFacturationCliente : Window
    {
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int IdClient { get; set; }
        public DetailFacturationCliente(DateTime dateDebut, DateTime dateFin, int id)
        {
            InitializeComponent();

            DateDebut = dateDebut;
            DateFin = dateFin;
            IdClient = id;
        }



    }
}

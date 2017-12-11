using System.Windows.Controls;

namespace Facturio.Aide
{
    public partial class AideView : UserControl
    {
        public AideView()
        {
            InitializeComponent();
            DataContext = new AideViewModel();
        }
    }
}

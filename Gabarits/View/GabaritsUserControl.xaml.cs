using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Facturio.Gabarits
{
    /// <summary>
    /// Logique d'interaction pour GabaritsUserControl.xaml
    /// </summary>
    public partial class GabaritsUserControl : UserControl
    {
        public List<Rectangle> Rectangles { get; set; } = new List<Rectangle>();
        public Rectangle RectangleSelectionne = null;

        public GabaritsUserControl()
        {
            InitializeComponent();

            GabaritsController.Charge();
            FaireGabarits();
            AfficheGabarits();
        }

        public void FaireGabarits()
        {
            /*
            foreach (Gabarit g in GabaritsController.Gabarits)
            {
                Rectangle rectangle = new Rectangle()
                {
                    Tag = g
                };

                Rectangles.Add(rectangle);
            }
            */
        }

        public void AfficheGabarits()
        {
            foreach (Rectangle r in Rectangles)
            {
                r.MouseLeftButtonUp += Rectangle_MouseLeftButtonUp;

                stpGabarits.Children.Add(r);
            }
        }

        private void Rectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // https://stackoverflow.com/a/593288
            Rectangle rectangleClique = (sender as Rectangle);

            Gabarit gabarit = rectangleClique.Tag as Gabarit;

            if (gabarit == null)
                return;

            foreach (Rectangle r in Rectangles)
                r.Stroke = null;

            if (rectangleClique == RectangleSelectionne)
            {
                RectangleSelectionne = null;
            }
            else
            {
                RectangleSelectionne = rectangleClique;
                rectangleClique.Stroke = Brushes.Black;
            }

            GabaritsController.UpdateSelection(gabarit);
        }
    }
}

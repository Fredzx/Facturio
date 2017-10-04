using System.Windows.Controls;

namespace Facturio
{
    public class Rang
    {
        public int? IdRang { get; set; } = null;
        public string Nom { get; set; } = string.Empty;
        public Image Image { get; set; } = new Image();

        public Rang() {}

        public Rang(string nom, Image image)
        {
            Nom = nom;
            Image = image;
        }
    }
}

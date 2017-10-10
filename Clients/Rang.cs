using System.Windows.Controls;

namespace Facturio
{
    public class Rang
    {
        public virtual int? IdRang { get; set; } = null;
        public virtual string Nom { get; set; } = string.Empty;
        public virtual Image Image { get; set; } = new Image();
        public virtual float? Escompte { get; set; } = null;

        public Rang() { }

        public Rang(string nom, Image image, float escompte)
        {
            Nom = nom;
            Image = image;
            Escompte = escompte;
        }
    }
}

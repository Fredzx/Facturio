using System.Windows.Controls;

namespace Facturio.Clients
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

        // Pour utiliser NHibernate, il faut surcharger Equals et GetHashCode.
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Rang r = obj as Rang;

            if (r == null)
            {
                return false;
            }

            return this.IdRang == r.IdRang;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}

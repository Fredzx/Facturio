using System.Collections.Generic;

namespace Facturio.Gabarits
{
    public static class GabaritsController
    {
        public static Gabarit SelectionCourante { get; set; }

        public static void Charge()
        {
            //Gabarits.Add(new Gabarit { Id = 1 });
        }

        public static void UpdateSelection(Gabarit gabarit)
        {
            if (gabarit == null)
                return;

            SelectionCourante = SelectionCourante == gabarit ? null : gabarit;
        }
    }
}

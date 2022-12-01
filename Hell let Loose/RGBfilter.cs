using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Hell_let_Loose
{
    internal static class RGBfilter
    {
        public static bool IsNotBackgroundNoice(System.Drawing.Color oldcolor, System.Drawing.Color newcolor,int acuracy)
        {
            
            if (oldcolor.R + acuracy < newcolor.R ||oldcolor.R- acuracy > newcolor.R) {
            return true;
            }
            if (oldcolor.G + acuracy < newcolor.G || oldcolor.G - acuracy > newcolor.G)
            {
                return true;
            }
            if (oldcolor.B + acuracy < newcolor.B || oldcolor.B - acuracy > newcolor.B)
            {
                return true;
            }



            return false;
        }
        public static bool IsAproximatlyCollor(System.Drawing.Color oldcolor, int collor, int acuracy)
        {

            if (oldcolor.R + acuracy < collor || oldcolor.R - acuracy > collor)
            {
                return true;
            }
            if (oldcolor.G + acuracy < collor || oldcolor.G - acuracy > collor)
            {
                return true;
            }
            if (oldcolor.B + acuracy < collor || oldcolor.B - acuracy > collor)
            {
                return true;
            }



            return false;
        }
    }
}

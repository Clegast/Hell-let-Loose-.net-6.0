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
        public static bool IsNotBackgroundNoice(System.Drawing.Color oldcolor, System.Drawing.Color newcolor)
        {
            int space = 25;
            if (oldcolor.R + space < newcolor.R ||oldcolor.R- space > newcolor.R) {
            return true;
            }
            if (oldcolor.G + space < newcolor.G || oldcolor.G - space > newcolor.G)
            {
                return true;
            }
            if (oldcolor.B + space < newcolor.B || oldcolor.B - space > newcolor.B)
            {
                return true;
            }



            return false;
        }
    }
}

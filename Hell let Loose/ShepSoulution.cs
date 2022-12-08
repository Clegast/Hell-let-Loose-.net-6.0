using Babel.Licensing;
using Main;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Action = Main.Action;

namespace Hell_let_Loose
{
    internal static class ShepSoulution
    {
        public static void AngelAlingh()
        {
            
            bool IsNotOnSpot = true;
            while (IsNotOnSpot)
            {
                Action.PressT();

                int x = ReadMarker();
                if (x >= 1920)
                {
                    Action.TurnRight();

                }
                else
                {
                    if (x > 1850)
                    {
                        IsNotOnSpot = false;
                    }
                    else
                    {
                        Action.TurnLeft();  
                    }
                }
                System.GC.Collect();
                Action.PressT();
            }
            
        }
        internal static int ReadMarker()
        {
            Bitmap Screenshot = Imgediting.CropScreenshot(new Coordinates(0, 360), 1920, 360);

            for (int i = 0; i < Screenshot.Height; i++)
            {
                for (int j = 0; j < Screenshot.Width; j++)
                {
                    if (Screenshot.GetPixel(j, i).R == 198&& Screenshot.GetPixel(j,i).G== 84 && Screenshot.GetPixel(j, i).B == 53)
                    {
                        return j;

                    }
                }
            }
            return 1921;

        }

    }
}

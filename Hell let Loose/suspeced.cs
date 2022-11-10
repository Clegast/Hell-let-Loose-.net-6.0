using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class Suspeced
    {
        Bitmap Normal = new Bitmap(16,16);//gröse nicht entgültig deffinirt
        Bitmap Sus = new Bitmap(16,16);
        int PicX , PicY,PosX,PosY;
        Coordinates Topleft;
        Coordinates Target;
        public Suspeced()
        {
            Topleft = new Coordinates(1, 1);
            Target = new Coordinates(1,1);

        }
        public  Suspeced(Bitmap nomal, Bitmap sus,int X, int Y)
        {
            Normal = nomal;
            Sus = sus;  
            PicX = X;
            PicY = Y;
            PosX = X+8;
            PosY = Y+16;
            Topleft = new Coordinates(PicX,PicY);
            Target = new Coordinates(PosX,PosY);


        }
        public Coordinates GetTargetCoordinates()
        {
            return Target;
        }

    }
    
    
}

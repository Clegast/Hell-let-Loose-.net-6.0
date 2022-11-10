using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Coordinates
    {
        public double xcordinate { get; set; } 
        public double ycordinate { get; set; }

        public Coordinates(int xcordinate, int ycordinate)
        {
            this.xcordinate = xcordinate;
            this.ycordinate = ycordinate;
        }
        private Coordinates()
        {
            xcordinate = 0; 
            ycordinate = 0; 
        }
        public double xpixeldifference(Coordinates aryposition)
        {
            return  xcordinate - aryposition.xcordinate;
            
        }
        public double ypixeldiffernece(Coordinates aryposition)
        {
            return ycordinate - aryposition.ycordinate;
        }
        public double xmetersdifference(Coordinates aryposition)
        {
            return (xcordinate- aryposition.xcordinate) / 88 * 200;
        }
        public double ymetersdifference(Coordinates aryposition)
        {
            return (ycordinate - aryposition.ycordinate) / 88 * 200;
        }
    }
}

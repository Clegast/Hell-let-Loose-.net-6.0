
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell_let_Loose
{
  internal class Temp
  {
    public static string getNumber(Bitmap Number)
    {
      Color ColorExpected = Color.White;

      if (RGBfilter.IsNotBackgroundNoice(ColorExpected, Number.GetPixel(0, 3), 10))
      {
        //number 9, 0, 6, 5 or 8
        if (RGBfilter.IsNotBackgroundNoice(ColorExpected, Number.GetPixel(2, 5), 10))
        {
          return "9";
        }
        else
        {
          //number 0, 6, 5 or 8
          if (RGBfilter.IsNotBackgroundNoice(ColorExpected, Number.GetPixel(3, 0), 10))
          {
            return "5";
          }
          else
          {
            if (RGBfilter.IsNotBackgroundNoice(ColorExpected, Number.GetPixel(3, 3), 10))
            {
              if (RGBfilter.IsNotBackgroundNoice(ColorExpected, Number.GetPixel(3, 4), 10))
              {
                return "0";
              }
              else
              {
                return "8";
              }
            }
            else
            {
              return "6";
            }
          }
        }
      }
      else
      {
        //numper 1, 2, 3, 4 or 7
      }


      return "";
    }

  }
}

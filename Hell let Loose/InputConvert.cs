using Hell_let_Loose;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal static class InputConvert
    {
        internal static int Convert(string input, int last)
        {
            input = input.Trim();

            for (int i = 0; i < 2; i++)
            {
                if (input.EndsWith("M") || input.EndsWith("L") || input.EndsWith("I")) {
                    input = input.Remove(input.Length - 1);
                }
            }

            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    StringBuilder imput = new StringBuilder("input");
                    char temp = input[i];
                    if (temp == 's' || temp == 'S')
                    {
                        imput[i] = '5';
                        input = imput.ToString();
                    }
                }

                if (int.TryParse(input, out result))
                {
                    return result;
                }
                else
                {
                    return last + 1;
                }
            }
        }
        internal static int AngleConverter(Coordinates coordinates, int Width, int Height, int last)
        {
           Bitmap Screenshot = Imgediting.CropScreenshot(coordinates, Width, Height);
            if (RGBfilter.IsAproximatlyCollor(Screenshot.GetPixel(6, 7), 210, 10)){
                string numberone =Temp.getNumber(Imgediting.Crop(new Coordinates(3, 3), 5, 10, Screenshot));
                string numberto = "";
                string numberthree = "";
                int minus = 0;
                if (numberone == "1")
                {
                    minus++;
                     
                }
                numberto = Temp.getNumber(Imgediting.Crop(new Coordinates(8 - minus, 3), 5, 10, Screenshot));
                if (numberto == "1")
                {
                    minus++;
                }                
                numberthree = Temp.getNumber(Imgediting.Crop(new Coordinates(13-minus, 3), 5, 10, Screenshot));
                
            };
            



            

        }
    }
}

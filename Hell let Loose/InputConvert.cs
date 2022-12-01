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
            if (RGBfilter.IsAproximatlyCollor(Screenshot.GetPixel(6, 7), 210, 15)){
                string numberone =Temp.getNumber(Imgediting.Crop(new Coordinates(3, 3), 5, 10, Screenshot));
                string numberto = "";
                string numberthree = "";
                int corection = 0;
                if (numberone == "1")
                {
                    corection++;
                     
                }
                if (numberone == "9" || numberone == "4" || numberone == "5" || numberone == "6" || numberone == "8" || numberone == "9")
                {
                    corection--;

                }
                numberto = Temp.getNumber(Imgediting.Crop(new Coordinates(8 - corection, 3), 5, 10, Screenshot));
                if (numberto == "1")
                {
                    corection++;
                }
                if (numberto == "9" || numberto == "4" || numberto == "5" || numberto == "6" || numberto == "8" || numberto == "9")
                {
                    corection--;

                }
                numberthree = Temp.getNumber(Imgediting.Crop(new Coordinates(13- corection, 3), 5, 10, Screenshot));
                if(numberone.Length <= 0||numberto.Length <=0||numberthree.Length <= 0)
                {
                    return last + 1;
                }
                else
                {
                    string temp = numberone + numberto + numberthree;
                    return Int32.Parse(temp);
                }
            }
            if (RGBfilter.IsAproximatlyCollor(Screenshot.GetPixel(8, 12), 210, 15) || RGBfilter.IsAproximatlyCollor(Screenshot.GetPixel(9, 12), 210, 15) || RGBfilter.IsAproximatlyCollor(Screenshot.GetPixel(10, 12), 210, 15))
            {
                string numberone = Temp.getNumber(Imgediting.Crop(new Coordinates(7, 3), 5, 10, Screenshot));
                string numberto = "";
                int corection = 0;
                if (numberone == "1")
                {
                    corection++;

                }
                if (numberone == "9" || numberone == "4" || numberone == "5" || numberone == "6" || numberone == "8" || numberone == "9")
                {
                    corection--;

                }
                numberto = Temp.getNumber(Imgediting.Crop(new Coordinates(12 - corection, 3), 5, 10, Screenshot));

                if (numberone.Length <= 0 || numberto.Length <= 0)
                {
                    return last + 1;
                }
                else
                {
                    string temp = numberone + numberto;
                    return Int32.Parse(temp);
                }

            }
            else
            {
                string numberone = Temp.getNumber(Imgediting.Crop(new Coordinates(9, 3), 5, 10, Screenshot));
                if (numberone.Length <= 0)
                {
                    return last + 1;
                }
                else
                {

                    return Int32.Parse(numberone);

                }

            ;




            }

        }
    }
}

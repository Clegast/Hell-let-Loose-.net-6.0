using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;



namespace Main
{
  internal static class Imgediting
  {
    //Function that takes a screenshot
    internal static Bitmap Screenshot()
    {
      var bmpScreenshot = new Bitmap(1920, 1080);
      using (var g = Graphics.FromImage(bmpScreenshot))
      {
        g.CopyFromScreen(0, 0, 0, 0,
        bmpScreenshot.Size, CopyPixelOperation.SourceCopy);
      }
      return bmpScreenshot;
    }

    public static Bitmap CropScreenshot(Coordinates coordinates, int Width, int Height)
    {
      //Bitmap bmpSource = Screenshot();
            
      return Crop(coordinates,Width,Height, Screenshot());
    }

    public static Bitmap Crop(Coordinates coordinates, int Width, int Height, Bitmap Source)
    {
            int x = (int)coordinates.xcordinate;
            int y = (int)coordinates.ycordinate;
      Bitmap Croped = new Bitmap(Width, Height);
      for(int Y = y; Y < Height + y - 1; Y++)
            {
                for(int X= x; X < Width + x - 1; X++)
                {
                    Color color = Source.GetPixel(X,Y);
                    Croped.SetPixel((X-x), (Y-y), color);
                }
            }

      
      return Croped;
    }

    public static Bitmap Grayscale(Bitmap collerd)
    {
      //create a blank bitmap the same size as original
      Bitmap newBitmap = new Bitmap(collerd.Width, collerd.Height);

      //get a graphics object from the new image
      using (Graphics g = Graphics.FromImage(newBitmap))
      {
        //create the grayscale ColorMatrix
        ColorMatrix colorMatrix = new ColorMatrix(
           new float[][]
           {
             new float[] {.3f, .3f, .3f, 0, 0},
             new float[] {.59f, .59f, .59f, 0, 0},
             new float[] {.11f, .11f, .11f, 0, 0},
             new float[] {0, 0, 0, 1, 0},
             new float[] {0, 0, 0, 0, 1}
           });
        //create some image attributes
        using (ImageAttributes attributes = new ImageAttributes())
        {
          //set the color matrix attribute
          attributes.SetColorMatrix(colorMatrix);
          //draw the original image on the new image
          //using the grayscale color matrix
          g.DrawImage(collerd, new Rectangle(0, 0, collerd.Width, collerd.Height),
                      0, 0, collerd.Width, collerd.Height, GraphicsUnit.Pixel, attributes);
        }
      }
      return newBitmap;
    }
  }
}

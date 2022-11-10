using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Main
{
  internal static class Imgediting
  {
    //Function that takes a screenshot
    internal static Bitmap Screenshot()
    {
      var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                     Screen.PrimaryScreen.Bounds.Height,
                                     PixelFormat.Format32bppArgb);

      var Screenshot = Graphics.FromImage(bmpScreenshot);

      Screenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                Screen.PrimaryScreen.Bounds.Y,
                                0,
                                0,
                                Screen.PrimaryScreen.Bounds.Size,
                                CopyPixelOperation.SourceCopy);

      return bmpScreenshot;
    }

    public static Bitmap CropScreenshot(int x, int y, int Width, int Height)
    {
      Bitmap bmpSource = Screenshot();
      return Crop(x,y,Width,Height,bmpSource);
    }

    public static Bitmap Crop(int x, int y, int Width, int Height, Bitmap bmpSource)
    {
      Bitmap bmpDestination = new Bitmap(Width, Height);
      Rectangle section = new Rectangle(x, y, Width, Height);

      using (Graphics g = Graphics.FromImage(bmpDestination))
      {
        g.DrawImage(bmpSource, 0, 0, section, GraphicsUnit.Pixel);
      }
      return bmpDestination;
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

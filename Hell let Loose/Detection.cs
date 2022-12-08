using System.Collections.Generic;
using System.Drawing;
using System.IO;
using IronOcr;
using System.Threading;
using System.Drawing.Imaging;
using System.Runtime.Intrinsics.X86;
using Hell_let_Loose;

namespace Main
{
  internal static class Detection
  {

    public static Coordinates setPosition(int cordx, int cordy)
    {
      Coordinates coordinates = new Coordinates(cordx, cordy);
      return coordinates;
    }

    //function that crops the screenshot and then converts the number to an Integer
    internal static int Imgtotxt(Coordinates coordinates, int Width, int Height, int last)
    {
      string pathCropped = Directory.GetCurrentDirectory() + "Screenshot.png";

      

      Imgediting.CropScreenshot(coordinates, Width, Height).Save(pathCropped);
          //  Imgediting.CropScreenshot(coordinates, Width, Height).Save(@"C:\Users\clega\Desktop\ary.png", ImageFormat.Png);
           // Imgediting.Screenshot().Save(@"C:\Users\clega\Desktop\aryall.png", ImageFormat.Png);

            var varResult = new IronTesseract().Read(pathCropped);
      string strResult = varResult.Text;
      int intResult = InputConvert.Convert(strResult, last);

      File.Delete(pathCropped);
      return intResult;
    }

    public static List<Suspeced> Detecte()
    {
      Bitmap? OldScreenshot = null;
      Bitmap? NewScreenshot = null;


      OldScreenshot = Imgediting.CropScreenshot( new Coordinates(695,268), 528, 528);
       //     OldScreenshot.Save(@"C:\Users\linus\Desktop\oldmap.png", ImageFormat.Png);
            Thread.Sleep(10000);
      NewScreenshot = Imgediting.CropScreenshot(new Coordinates(695, 268), 528, 528);
         //   NewScreenshot.Save(@"C:\Users\linus\Desktop\newmap.png", ImageFormat.Png);

            List<Suspeced> Posiblemarkers = new List<Suspeced>();
      for (int Y = 0; Y < NewScreenshot.Height; Y++)
      {
        for (int X = 0; X < NewScreenshot.Width; X++)
        {
          int ChanchedPixel = 0;
          if (RGBfilter.IsNotBackgroundNoice( OldScreenshot.GetPixel(X, Y), NewScreenshot.GetPixel(X, Y),25))
          {
            ChanchedPixel++;
            for (int Ytest = Y; Ytest < Y + 16 && Ytest < NewScreenshot.Height; Ytest++)
            {
              for (int Xtest = X; Xtest < X + 16 && Xtest < NewScreenshot.Width; Xtest++)
                if (OldScreenshot.GetPixel(Xtest, Ytest) != NewScreenshot.GetPixel(Xtest, Ytest))
                {
                  ChanchedPixel++;
                  
                }
            }
            if (ChanchedPixel >= 200)
            {
              Suspeced a = new Suspeced(Imgediting.Crop(new Coordinates(X, Y), 16, 16, OldScreenshot), Imgediting.Crop(new Coordinates(X, Y), 16, 16, NewScreenshot), X, Y);
                          //  Imgediting.Crop(new Coordinates(X, Y), 16, 16, OldScreenshot).Save(@"C:\Users\linus\Desktop\oldmarker.png", ImageFormat.Png);
                          // Imgediting.Crop(new Coordinates(X, Y), 16, 16, NewScreenshot).Save(@"C:\Users\linus\Desktop\newmarker.png", ImageFormat.Png);
                            Posiblemarkers.Add(a);
              Y = Y + 16;
            }
          }
          if (Y >= NewScreenshot.Height) break;
        }
      }
      Thread.Sleep(500);

      return Posiblemarkers;


    }
    public static Coordinates GetCoordinatsfromList(List<Suspeced> Markers)
    {
      Suspeced suspeced = Markers[0];
      Coordinates coordinates = suspeced.GetTargetCoordinates();
      coordinates.xcordinate += 695;
      coordinates.ycordinate += 268;
      return coordinates;
    }


    public static Coordinates GetTarget()
    {
      List<Suspeced> suspeceds = new List<Suspeced>();
      do
      {
        suspeceds = Detecte();
        System.GC.Collect();


      } while (suspeceds.Count == 0);
      return GetCoordinatsfromList(suspeceds);
    }

    public static bool isHudOn()
    {
      Bitmap Screenshot = Imgediting.Screenshot();

      for(int i = 0; i < Screenshot.Width; i++)
      {
        //if (Screenshot.GetPixel(i, 33).R == 2 && Screenshot.GetPixel(i, 33).G == 113 && Screenshot.GetPixel(i, 33).B == 187)
        if (RGBfilter.IsAproximatlyCollor(Screenshot.GetPixel(i, 33), 2, 113, 187, 10))
        {
          return true;
        }
      }
      return false;
    }
  }
}

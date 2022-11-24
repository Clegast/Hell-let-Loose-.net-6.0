using System.Collections.Generic;
using System.Drawing;
using System.IO;
using IronOcr;
using System.Threading;

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

      InputConvert inputconvert = new InputConvert();

      Imgediting.CropScreenshot(coordinates, Width, Height).Save(pathCropped);

      var varResult = new IronTesseract().Read(pathCropped);
      string strResult = varResult.Text;
      int intResult = inputconvert.Convert(strResult, last);

      File.Delete(pathCropped);
      return intResult;
    }

    public static List<Suspeced> Detecte()
    {
      Bitmap? OldScreenshot = null;
      Bitmap? NewScreenshot = null;


      OldScreenshot = Imgediting.CropScreenshot( new Coordinates(695,268), 528, 528);

      Thread.Sleep(10000);
      NewScreenshot = Imgediting.CropScreenshot(new Coordinates(695, 268), 528, 528);

      List<Suspeced> Posiblemarkers = new List<Suspeced>();
      for (int Y = 0; Y < NewScreenshot.Height; Y++)
      {
        for (int X = 0; X < NewScreenshot.Width; X++)
        {
          int ChanchedPixel = 0;
          if (OldScreenshot.GetPixel(X, Y) != NewScreenshot.GetPixel(X, Y))
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
  }
}

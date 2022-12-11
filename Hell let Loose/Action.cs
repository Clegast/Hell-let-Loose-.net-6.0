using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Main
{
  internal static class Action
  {

    /// <summary>
    /// function that presses the d key for 1 second
    /// </summary>
    public static void TurnRight()
    {

      Keypresses.press(Keypresses.GetScanCodeShort("d"));
      Thread.Sleep(1000);
      Keypresses.releas(Keypresses.GetScanCodeShort("d"));

    }

    /// <summary>
    /// function that presses the a key for 1 second
    /// </summary>
    public static void TurnLeft()
    {

      Keypresses.press(Keypresses.GetScanCodeShort("a"));
      Thread.Sleep(1000);
      Keypresses.releas(Keypresses.GetScanCodeShort("a"));

    }

    /// <summary>
    /// function that presses the w key for 0.25 seconds
    /// </summary>
    public static void TurnUp()
    {

      Keypresses.press(Keypresses.GetScanCodeShort("w"));
      Thread.Sleep(250);
      Keypresses.releas(Keypresses.GetScanCodeShort("w"));



    }

    /// <summary>
    /// function that presses the s key for 0.25 seconds
    /// </summary>
    public static void TurnDown()
    {

      Keypresses.press(Keypresses.GetScanCodeShort("s"));
      Thread.Sleep(250);
      Keypresses.releas(Keypresses.GetScanCodeShort("s"));


    }
    /// <summary>
    /// swutches seat when the player is in a vehicle or an artillery piece. only seat one and two work (for now)
    /// </summary>
    /// <param name="SeatNumber">number of the seat to cance to starts at 0</param>
    public static void SwitchSeatTo(int SeatNumber)
    {

      switch (SeatNumber)


      {
        case 0:
          Keypresses.press(Keypresses.GetScanCodeShort("f1"));
          Thread.Sleep(1100);
          Keypresses.releas(Keypresses.GetScanCodeShort("f1"));
          break;
        case 1:
          Keypresses.press(Keypresses.GetScanCodeShort("f2"));
          Thread.Sleep(1100);
          Keypresses.releas(Keypresses.GetScanCodeShort("f2"));
          break;
        default:
          break;

      }
    }

    /// <summary>
    /// function that presses the m key for 0.1 seconds to open the map
    /// </summary>
    public static void OpenMap()
    {

      Keypresses.press(Keypresses.GetScanCodeShort("m"));
      Thread.Sleep(100);
      Keypresses.releas(Keypresses.GetScanCodeShort("m"));
      Thread.Sleep(20);

    }

    /// <summary>
    /// function that Reloads the artillery piece
    /// </summary>
    public static void Reload()
    {
      Thread.Sleep(1000);
      Keypresses.press(Keypresses.GetScanCodeShort("r"));
      Thread.Sleep(800);
      Keypresses.releas(Keypresses.GetScanCodeShort("r"));
      Thread.Sleep(3000);

    }

    /// <summary>
    /// function that shoots
    /// </summary>
    public static void Fire()
    {
      Thread.Sleep(500);

      Keypresses.mousclickleft(1000);
    }

    /// <summary>
    /// function that presses T for 1 second
    /// </summary>
    public static void PressT()
    {

      Keypresses.press(Keypresses.GetScanCodeShort("t"));
      Thread.Sleep(1000);
      Keypresses.releas(Keypresses.GetScanCodeShort("t"));
      Thread.Sleep(500);

    }
  }
}

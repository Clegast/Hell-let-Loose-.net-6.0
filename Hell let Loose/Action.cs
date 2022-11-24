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
        public static void TurnRight()
        {
            
            Keypresses.press(Keypresses.GetScanCodeShort("d"));
            Thread.Sleep(1000);
            Keypresses.releas(Keypresses.GetScanCodeShort("d"));

        }
        public static void TurnLeft()
        {
            
            Keypresses.press(Keypresses.GetScanCodeShort("a"));
            Thread.Sleep(1000);
            Keypresses.releas(Keypresses.GetScanCodeShort("a"));

        }
        public static void TurnUp()
        {
            
            Keypresses.press(Keypresses.GetScanCodeShort("w"));
            Thread.Sleep(250);
            Keypresses.releas(Keypresses.GetScanCodeShort("w"));



        }
        public static void TurnDown()
        {
            
            Keypresses.press(Keypresses.GetScanCodeShort("s"));
            Thread.Sleep(250);
            Keypresses.releas(Keypresses.GetScanCodeShort("s"));


        }
        /// <summary>
        /// swutches seat wehne the player is in a vehicle or an artillery peas only seat one and tow worke (for now)
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
        public static void OpenMap()
        {
            
            Keypresses.press(Keypresses.GetScanCodeShort("m"));
            Thread.Sleep(100);
            Keypresses.releas(Keypresses.GetScanCodeShort("m"));

        }
        public static void Reload()
        {
            
            Keypresses.press(Keypresses.GetScanCodeShort("r"));
            Thread.Sleep(100);
            Keypresses.releas(Keypresses.GetScanCodeShort("r"));
            Thread.Sleep(3500);

        }

        public static void Fire()
        {
            
            Keypresses.mousclickleft(200);
        }


    }
}

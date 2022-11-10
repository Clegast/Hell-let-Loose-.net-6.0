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
            Keypresses keypresses = new Keypresses();
            keypresses.press(keypresses.GetScanCodeShort("d"));
            Thread.Sleep(1000);
            keypresses.releas(keypresses.GetScanCodeShort("d"));

        }
        public static void TurnLeft()
        {
            Keypresses keypresses = new Keypresses();
            keypresses.press(keypresses.GetScanCodeShort("a"));
            Thread.Sleep(1000);
            keypresses.releas(keypresses.GetScanCodeShort("a"));

        }
        public static void TurnUp()
        {
            Keypresses keypresses = new Keypresses();
            keypresses.press(keypresses.GetScanCodeShort("w"));
            Thread.Sleep(250);
            keypresses.releas(keypresses.GetScanCodeShort("w"));



        }
        public static void TurnDown()
        {
            Keypresses keypresses = new Keypresses();
            keypresses.press(keypresses.GetScanCodeShort("s"));
            Thread.Sleep(250);
            keypresses.releas(keypresses.GetScanCodeShort("s"));


        }
        /// <summary>
        /// swutches seat wehne the player is in a vehicle or an artillery peas only seat one and tow worke (for now)
        /// </summary>
        /// <param name="SeatNumber">number of the seat to cance to starts at 0</param>
        public static void SwitchSeatTo(int SeatNumber)
        {
            Keypresses keypresses = new Keypresses();
            switch (SeatNumber)


            {
                case 0:
                    keypresses.press(keypresses.GetScanCodeShort("f1"));
                    Thread.Sleep(1100);
                    keypresses.releas(keypresses.GetScanCodeShort("f1"));
                    break;
                case 1:
                    keypresses.press(keypresses.GetScanCodeShort("f2"));
                    Thread.Sleep(1100);
                    keypresses.releas(keypresses.GetScanCodeShort("f2"));
                    break;
                default:
                    break;

            }


        }
        public static void OpenMap()
        {
            Keypresses keypresses = new Keypresses();
            keypresses.press(keypresses.GetScanCodeShort("m"));
            Thread.Sleep(100);
            keypresses.releas(keypresses.GetScanCodeShort("m"));

        }
        public static void Reload()
        {
            Keypresses keypresses = new Keypresses();
            keypresses.press(keypresses.GetScanCodeShort("r"));
            Thread.Sleep(100);
            keypresses.releas(keypresses.GetScanCodeShort("r"));
            Thread.Sleep(3500);

        }

        public static void Fire()
        {
            Keypresses keypresses = new Keypresses();
            keypresses.mousclickleft(200);
        }


    }
}

using Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Action = Main.Action;

namespace Hell_let_Loose
{
    internal static class fastfix
    {
        public static void Main(Coordinates ary,int mapnorth,string faction,int aryalignment)
        {
            Action.OpenMap( );
            Thread.Sleep(1000);
            Coordinates target = Detection.GetTarget();

            double distance = Formula.GetHypotenuse(target, ary);
            int mil = 0;
            switch (faction)
            {
                case "Us":
                    mil = (int)Math.Round(Formula.usMetersToMill(distance));
                    break;
                case "Gr":
                    mil = (int)Math.Round(Formula.usMetersToMill(distance));
                    break;
                case "Ru":
                    mil = (int)Math.Round(Formula.ruMetersToMill(distance));
                    break;

            }
            int angel = (int)Formula.angleCalculation(target, ary, mapnorth, aryalignment);
            Action.OpenMap();

            Thread.Sleep(1000);


            int MilonScreen = Detection.Imgtotxt(new Coordinates(1800, 945), 50, 20, 622);
            int lastMil = MilonScreen;

            while (MilonScreen != mil)
            {
                lastMil = new Int32();
                lastMil = MilonScreen;
                if (MilonScreen > mil)
                {
                    Action.TurnDown();
                }
                if (MilonScreen < mil)
                {
                    Action.TurnUp();
                }

                MilonScreen = Detection.Imgtotxt(new Coordinates(1800, 945), 50, 20, lastMil);
                System.GC.Collect();
                if (MilonScreen == mil - 1)
                {
                    break;
                }
                else if (MilonScreen == mil + 1)
                {
                    break;
                }


            }





            Action.SwitchSeatTo(1);
            Action.Reload();
            ShepSoulution.AngelAlingh();
            Action.SwitchSeatTo(0);
            for (int i = 0; i < 3; i++)
            {
                Action.Fire();
                Action.SwitchSeatTo(1);
                Action.Reload();
                Action.SwitchSeatTo(0);
            }
            Thread.Sleep(1000);
        }
    }
}

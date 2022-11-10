using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Main
{

  internal class Formula
  {
    double xMeters = 0.0;
    double yMeters = 0.0;
    double Hypotenuse = 0.0;
    
    internal double GetHypotenuse(Coordinates target, Coordinates ary) {
      double xMeters = target.xmetersdifference(ary);
      double yMeters = target.ymetersdifference(ary);
      if (xMeters < 0.0) { xMeters *= (-1); }
      if (yMeters < 0.0) { yMeters *= (-1); }
      return  Math.Sqrt(xMeters * xMeters + yMeters * yMeters);
    }

    internal double ruMetersToMill(double Hypotenuse){
      return Hypotenuse * -0.2136691176 + 1141.721500;
    }

    internal double usMetersToMill(double Hypotenuse)
    {
      return Hypotenuse * -0.237035714285714 + 1001.46547619048;
    }

    internal double angleCalculation(Coordinates target, Coordinates ary, double mapnorth, double AlignmentAry)
    {
      double xMeters = target.xmetersdifference(ary);
      double yMeters = target.ymetersdifference(ary);
      
      double angleTan = (Math.Atan(yMeters / xMeters))*180/Math.PI;
      return mapnorth + AlignmentAry + angleTan;
    }
  }
}


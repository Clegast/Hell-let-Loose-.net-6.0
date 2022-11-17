using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
  internal static class GetValue
  {
  public static int GetPosition(int boxposition)
    {
      int alingment = 270;
     
      switch (boxposition){
        case 0:
          alingment = 180;
          break;
        case 1:
          alingment = 0;
          break;
        case 2:
          alingment = 90;
          break ;
      }
      return alingment;
    }

    public static string getAryTyp(int typ){
      string faction = "Us";
      if (typ == 1) { faction = "Ru"; } 
      return faction;

    }
    
   
    
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell_let_Loose
{
  internal class GetValue
  {
  public int GetPosition(int boxposition)
    {
      int aryalingment = 270;
     
      switch (boxposition){
        case 0:
          aryalingment = 180;
          break;
        case 1:
          aryalingment = 0;
          break;
        case 2:
          aryalingment = 90;
          break ;
      }
      return aryalingment;
    }

    public string getAryTyp(int typ){
      string faction = "Us";
      if (typ == 1) { faction = "Ru"; } 
      return faction;

    }
    
   
    
  }
}

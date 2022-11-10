using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class Compear
    {
        public bool IsInRangeOf(int range,int valuea,int valueb)
        {
            int temp = valuea - valueb;
            if (temp < 0)
            {
                temp = temp * -1;
            }
            return temp > range;

        }
         
        public bool SingelARGB(Color vluea, Color valueb, Char witchone, int range)
        {
            switch (witchone){
                case 'A':
                    return IsInRangeOf(vluea.A,valueb.A,range);
                    
                case 'R':
                    return IsInRangeOf(vluea.R,valueb.R,range);
                    
                case 'G':
                    return IsInRangeOf(vluea.G,valueb.G,range);
                    
                case 'B':
                    return IsInRangeOf(vluea.B,valueb.B,range);
                    
                default:
                    return (IsInRangeOf(vluea.R, valueb.R, range) || IsInRangeOf(vluea.G, valueb.G, range) || IsInRangeOf(vluea.B, valueb.B, range));
                    




                }
            }

        }
        

        }

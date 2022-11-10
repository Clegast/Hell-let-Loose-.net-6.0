﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class InputConvert
    {
        internal int Convert(string input, int last)
        {
            input = input.Trim();

            for (int i = 0; i < 2; i++)
            {
                if (input.EndsWith("M") || input.EndsWith("L") || input.EndsWith("I")) {
                    input = input.Remove(input.Length - 1);
                }
            }

            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    StringBuilder imput = new StringBuilder("input");
                    char temp = input[i];
                    if (temp == 's' || temp == 'S')
                    {
                        imput[i] = '5';
                        input = imput.ToString();
                    }
                }

                if (int.TryParse(input, out result))
                {
                    return result;
                }
                else
                {
                    return last + 1;
                }
            }
        }
    }
}

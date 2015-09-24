using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc24
{
    class ConfirmNumbers
    {
        private int[] Numbers;
        private int Count;
        public ConfirmNumbers(int []array)
        {
            Numbers = array;
            Count = Numbers.Length;
        }
        public bool ConfirmIt(string input)
        {
            int[] tempNumbers = (int[])Numbers.Clone();
            bool isLegal = true;
            int beenConfrimedCount = 0;
            for(int i=0;i<input.Length;i++)
            {
                if(isLegal==false)
                {
                    break;
                }

                if(char.IsDigit(input[i]))
                {
                    string tempNumber = "";
                    for(;i<input.Length;i++)
                    {
                        if(char.IsDigit(input[i]))
                        {
                            tempNumber +=input[i];
                        }
                        else
                        {
                            break;
                        }
                    }
                    for(int k=0;k<tempNumbers.Length;k++)
                    {
                        if(tempNumbers[k]==Convert.ToInt32(tempNumber))
                        {
                            tempNumbers[k] = -1;
                            beenConfrimedCount++;
                            break;
                        }
                        if (k == tempNumbers.Length-1)
                        {
                            isLegal = false;
                            break;
                        }
                    }
                }
            }
            if(beenConfrimedCount!=tempNumbers.Length)
            {
                isLegal = false;
            }
            return isLegal;
        }
    }
}

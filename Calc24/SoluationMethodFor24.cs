using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc24
{
    class SoluationMethodFor24
    {
        double NumberA, NumberB, NumberC, NumberD;
        public SoluationMethodFor24(int a,int b,int c,int d)
        {
            NumberA = a;
            NumberB = b;
            NumberC = c;
            NumberD = d;
        }
        public string FindSolution()
        {
            double A = NumberA;
            double B = NumberB;
            double C = NumberC;
            double D = NumberD;
            string answer=null;
            for(int i=1;i<=24;i++)
            {
                switch (i)
                {
                    case 1:
                        A = NumberA; B = NumberB; C = NumberC; D = NumberD;
                        break;
                    case 2:
                        A = NumberA; B = NumberB; D = NumberC; C = NumberD;
                        break;
                    case 3:
                        A = NumberA; C = NumberB; B = NumberC; D = NumberD;
                        break;
                    case 4:
                        A = NumberA; C = NumberB; D = NumberC; B = NumberD;
                        break;
                    case 5:
                        A = NumberA; D = NumberB; B = NumberC; C = NumberD;
                        break;
                    case 6:
                        A = NumberA; D = NumberB; C = NumberC; B = NumberD;
                        break;
                    case 7:
                        B = NumberA; A = NumberB; C = NumberC; D = NumberD;
                        break;
                    case 8:
                        B = NumberA; A = NumberB; D = NumberC; C = NumberD;
                        break;
                    case 9:
                        B = NumberA; C = NumberB; A = NumberC; D = NumberD;
                        break;
                    case 10:
                        B = NumberA; C = NumberB; D = NumberC; A = NumberD;
                        break;
                    case 11:
                        B = NumberA; D = NumberB; A = NumberC; C = NumberD;
                        break;
                    case 12:
                        B = NumberA; D = NumberB; C = NumberC; A = NumberD;
                        break;
                    case 13:
                        C = NumberA; A = NumberB; B = NumberC; D = NumberD;
                        break;
                    case 14:
                        C = NumberA; A = NumberB; D = NumberC; B = NumberD;
                        break;
                    case 15:
                        C = NumberA; B = NumberB; A = NumberC; D = NumberD;
                        break;
                    case 16:
                        C = NumberA; B = NumberB; D = NumberC; A = NumberD;
                        break;
                    case 17:
                        C = NumberA; D = NumberB; A = NumberC; B = NumberD;
                        break;
                    case 18:
                        C = NumberA; D = NumberB; B = NumberC; A = NumberD;
                        break;
                    case 19:
                        D = NumberA; A = NumberB; B = NumberC; C = NumberD;
                        break;
                    case 20:
                        D = NumberA; A = NumberB; C = NumberC; B = NumberD;
                        break;
                    case 21:
                        D = NumberA; B = NumberB; A = NumberC; C = NumberD;
                        break;
                    case 22:
                        D = NumberA; B = NumberB; C = NumberC; A = NumberD;
                        break;
                    case 23:
                        D = NumberA; C = NumberB; A = NumberC; B = NumberD;
                        break;
                    case 24:
                        D = NumberA; C = NumberB; B = NumberC; A = NumberD;
                        break;
                }

                if ((A + B + C + D) == 24.0)
                    return answer= A + "+" + B + "+" + C + "+" + D + "=24";
                if ((A + B + C - D) == 24.0)
                    return answer= A + "+" + B + "+" + C + "-" + D + "=24";
                //3 
                if (A * B + C + D == 24.0)
                    return answer= A + "*" + B + "+" + C + "+" + D + "=24";
                //4 
                if (A * B + C - D == 24.0)
                    return answer= A + "*" + B + "+" + C + "-" + D + "=24";
                //5 
                if (A * B * C + D == 24.0)
                    return answer= A + "*" + B + "*" + C + "+" + D + "=24";
                //6 
                if (A * B * C - D == 24.0)
                    return answer= A + "*" + B + "*" + C + "-" + D + "=24";
                //7 
                if (A * B * C * D == 24.0)
                    return answer= A + "*" + B + "*" + C + "*" + D + "=24";
                //8 
                if (A * B + C * D == 24.0)
                    return answer= A + "*" + B + "+" + C + "*" + D + "=24";
                //9 
                if (A * B - C * D == 24.0)
                    return answer= A + "*" + B + "-" + C + "*" + D + "=24";
                //10 
                if (A / B + C + D == 24.0)
                    return answer= A + "/" + B + "+" + C + "+" + D + "=24";
                //11 
                if (A * B / C + D == 24.0)
                    return answer= A + "*" + B + "/" + C + "+" + D + "=24";
                //12 
                if (A * B / C - D == 24.0)
                    return answer= A + "*" + B + "/" + C + "-" + D + "=24";
                //13 
                if (A * B * C / D == 24.0)
                    return answer= A + "*" + B + "*" + C + "/" + D + "=24";
                //14 
                if (A * B / C / D == 24.0)
                    return answer= A + "*" + B + "/" + C + "/" + D + "=24";
                //15 
                if ((A + B) * C / D == 24.0)
                    return answer= "("+A + "+" + B+")" + "*" + C + "/" + D + "=24";
                //16 
                if ((A + B) * C * D == 24.0)
                    return answer= "(" + A + "+" + B + ")" + "*" + C + "*" + D + "=24";
                //17 
                if ((A + B) * (C + D) == 24.0)
                    return answer= "("+A + "+" + B + ")" + "*" + "(" + C + "+" + D + ")" + "=24";
                //18 
                if ((A + B) * (C - D) == 24.0)
                    return answer= "(" + A + "+" + B + ")" + "*" + "(" + C + "-" + D + ")" + "=24";
                //19 
                if ((A - B) * (C - D) == 24.0)
                    return answer= "(" + A + "-" + B + ")" + "*" + "(" + C + "-" + D + ")" + "=24";
                //20 
                if ((A - B) * C / D == 24.0)
                    return answer= "(" + A + "-" + B + ")" + "*" + "(" + C + "/" + D + ")" + "=24";
                //21 
                if ((A - B) * C * D == 24.0)
                    return answer= "(" + A + "-" + B + ")" + "*" + "(" + C + "*" + D + ")" + "=24";
                //22 
                if ((A + B + C) * D == 24.0)
                    return answer= "(" + A + "+" + B + "+" + C + ")" + "*" + D + "=24";
                //23 
                if ((A + B + C) / D == 24.0)
                    return answer= "(" + A + "+" + B + "+" + C + ")" + "/" + D + "=24";
                //24 
                if ((A + B - C) * D == 24.0)
                    return answer= "("+A + "+" + B + "-" + C + ")" + "*" + D + "=24";
                //25 
                if (A * (B + C) + D == 24.0)
                    return answer= A + "*" + "(" + B + "+" + C + ")" + "+" + D + "=24";
                //26 
                if (A * (B - C) + D == 24.0)
                    return answer= A + "*" + "(" + B + "-" + C + ")" + "+" + D + "=24";
                //27 
                if (A * (B + C) - D == 24.0)
                    return answer= A + "*" + "(" + B + "+" + C + ")" + "-" + D + "=24";
                //28 
                if (A * (B - C) - D == 24.0)
                    return answer= A + "*" + "(" + B + "-" + C + ")" + "-" + D + "=24";
                //29 
                if (A + (B + C) / D == 24.0)
                    return answer= A + "+" + "(" + B + "+" + C + ")" + "/" + D + "=24";
                if ((A - B / C) * D == 24.0)
                    //30 
                    return answer= "(" + A + "-" + B + "/" + C + ")" + "*" + D + "=24";
            }
            return "No accpeted solution";
        }
    }
}

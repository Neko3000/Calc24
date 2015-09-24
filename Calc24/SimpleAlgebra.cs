using System;
using System.Collections;
namespace Calculater
{
    /// <summary>
    /// ClsSimpleCalculate集中包含了一些最基本的数学运算。
    /// 其中包括了数值算式的计算（SimpleAlgebra）、集合的运算等。
    /// </summary>
    public abstract class SimpleAlgebra//简单算式运算
    {
        public SimpleAlgebra()
        {
            //
            // TODO: SimpleAlgebra的构造函数
            //
        }
        public static double Deal(string inputs)//处理表达式中的括号。以括号为单元分配给下属程序运行
        {
            int i;
            ArrayList bra = new ArrayList();//记录左括号
            ArrayList ket = new ArrayList();//记录右括号
            int j = 0;
            inputs = inputs.Replace(")(", ")*(");
            for (i = 0; i < inputs.Length; i++)//只记录第一层括号位置
            {//下面两步巧妙运用了C#语言的特点来减少CODE
                if (inputs[i] == '(' && j++ == 0) bra.Add(i);
                if (inputs[i] == ')' && --j == 0) ket.Add(i);
            }
            if (!(bra.Count == ket.Count)) return 0;
            if (bra.Count == 0) return Formular(inputs);
            string replace = inputs.Substring(0, (int)bra[0]);
            string tmp = inputs.Substring((int)bra[0] + 1, (int)ket[0] - (int)bra[0] - 1);
            if (tmp.IndexOf('(') == -1) replace = replace + Formular(tmp);//无括号时的处理
            else replace = replace + Deal(tmp).ToString();//有括号时的处理
            for (i = 1; i < bra.Count; i++)
            {
                replace = replace + inputs.Substring((int)ket[i - 1] + 1, (int)bra[i] - (int)ket[i - 1] - 1);
                tmp = inputs.Substring((int)bra[i] + 1, (int)ket[i] - (int)bra[i] - 1);
                if (tmp.IndexOf('(') == -1) replace = replace + Formular(tmp).ToString();//无括号时的处理
                else replace = replace + Deal(tmp).ToString();//有括号时的处理
            }
            replace = replace + inputs.Substring((int)ket[ket.Count - 1] + 1, inputs.Length - (int)ket[ket.Count - 1] - 1);
            return Formular(replace);
        }
        protected static double Formular(string Inputs)//最简式运算
        {
            int Len = Inputs.Length;
            ArrayList OpeLoc = new ArrayList();//记录操作符位置
            ArrayList Ope = new ArrayList();//记录操作符
            int i;
            for (i = 0; i < Len; i++)
            {
                if (IsOperator(Inputs[i]))//获取算符组信息
                {
                    OpeLoc.Add(i);
                    Ope.Add((char)Inputs[i]);
                }
            }
            if (OpeLoc.Count == 0) return double.Parse(Inputs);//处理无算符的情况
            RebuildOperator(ref OpeLoc, ref Ope);//算符重组，区分负号和减号
            if (!CheckFunction(OpeLoc, Len)) return 0;//判断算符组是否合法
            ArrayList Val = new ArrayList();//记录数值内容
            int j = 0;
            for (i = 0; i < OpeLoc.Count; i++)
            {
                Val.Add(double.Parse(Inputs.Substring(j, (int)OpeLoc[i] - j)));
                j = (int)OpeLoc[i] + 1;
            }
            Val.Add(double.Parse(Inputs.Substring(j, Len - j)));//处理最后一个数据的录入
            return Calculate(Ope, Val);
        }
        protected static double Calculate(ArrayList Locs, ArrayList Values)//处理四则混合运算等基础运算
        {
            int i;
            for (i = 0; i < Locs.Count; i++)//处理逻辑运算
            {
                switch ((char)Locs[i])
                {
                    case '&':
                        Values[i] = (double)((int)(double)Values[i] & (int)(double)Values[i + 1]);
                        Values.RemoveAt(i + 1);
                        Locs.RemoveAt(i);
                        i--;
                        break;
                    case '|':
                        Values[i] = (double)((int)(double)Values[i] | (int)(double)Values[i + 1]);
                        Values.RemoveAt(i + 1);
                        Locs.RemoveAt(i);
                        i--;
                        break;
                    case '$':
                        Values[i] = (double)((int)(double)Values[i] ^ (int)(double)Values[i + 1]);
                        Values.RemoveAt(i + 1);
                        Locs.RemoveAt(i);
                        i--;
                        break;
                    case '#':
                        Values[i] = (double)(1 - ((int)(double)Values[i] ^ (int)(double)Values[i + 1]));
                        Values.RemoveAt(i + 1);
                        Locs.RemoveAt(i);
                        i--;
                        break;
                }
            }
            for (i = 0; i < Locs.Count; i++)//处理科学计数法
            {
                switch ((char)Locs[i])
                {
                    case 'E':
                        Values[i] = (double)Values[i] * Math.Pow(10, (double)Values[i + 1]);
                        Values.RemoveAt(i + 1);
                        Locs.RemoveAt(i);
                        i--;
                        break;
                    case '^':
                        Values[i] = Math.Pow((double)Values[i], (double)Values[i + 1]);
                        Values.RemoveAt(i + 1);
                        Locs.RemoveAt(i);
                        i--;
                        break;
                }
            }
            for (i = 0; i < Locs.Count; i++)//处理乘法、除法、整除和求余
            {
                switch ((char)Locs[i])
                {
                    case '*':
                        Values[i] = (double)Values[i] * (double)Values[i + 1];
                        Values.RemoveAt(i + 1);
                        Locs.RemoveAt(i);
                        i--;
                        break;
                    case '/':
                        Values[i] = (double)Values[i] / (double)Values[i + 1];
                        Values.RemoveAt(i + 1);
                        Locs.RemoveAt(i);
                        i--;
                        break;
                    case '\\':
                        Values[i] = (int)((double)Values[i] / (double)Values[i + 1]);
                        Values.RemoveAt(i + 1);
                        Locs.RemoveAt(i);
                        i--;
                        break;
                    case '%':
                        Values[i] = (double)Values[i] - (double)Values[i + 1] * (int)((double)Values[i] / (double)Values[i + 1]);
                        Values.RemoveAt(i + 1);
                        Locs.RemoveAt(i);
                        i--;
                        break;
                }
            }
            for (i = 0; i < Locs.Count; i++)//处理加法和减法
            {
                switch ((char)Locs[i])
                {
                    case '+':
                        Values[i] = (double)Values[i] + (double)Values[i + 1];
                        Values.RemoveAt(i + 1);
                        Locs.RemoveAt(i);
                        i--;
                        break;
                    case '-':
                        Values[i] = (double)Values[i] - (double)Values[i + 1];
                        Values.RemoveAt(i + 1);
                        Locs.RemoveAt(i);
                        i--;
                        break;
                }
            }
            return (double)Values[0];
        }
        protected static bool IsOperator(char chr)//判断一个符号是否是基本算符
        {
            if (chr == '+' | chr == '-' | chr == '*' | chr == '/') return true;//判断是否是四则混合运算算符
            if (chr == '\\' | chr == 'E' | chr == '%' | chr == '^') return true;//判断是否是整除或科学计数法
            if (chr == '&' | chr == '|' | chr == '$' | chr == '#') return true;//判断是否是逻辑运算（与、或、异或、同或）
            return false;
        }
        protected static void RebuildOperator(ref ArrayList Loc, ref ArrayList Val)//对负号的处理和重构
        {
            ArrayList DelItem = new ArrayList();
            if ((int)Loc[0] == 0 & (char)Val[0] == '-')//判断第一个符号是否是负号
            {
                DelItem.Add(0);
            }
            int i;
            for (i = 1; i < Loc.Count; i++)
            {
                if ((char)Val[i] == '-' & (char)Val[i - 1] != '-' & (int)Loc[i] - (int)Loc[i - 1] == 1)//判断是否有相邻的算符且后一个是负号
                {
                    DelItem.Add(i);
                }
            }
            for (i = DelItem.Count - 1; i >= 0; i--)//将负号和减号分开处理
            {
                Val.RemoveAt((int)DelItem[i]);
                Loc.RemoveAt((int)DelItem[i]);
            }
        }
        protected static bool CheckFunction(ArrayList Loc, int Len)//判断算符组是否合法
        {
            if ((int)Loc[0] == 0) return false;
            int i;
            for (i = 1; i < Loc.Count; i++)
            {
                if ((int)Loc[i] - (int)Loc[i - 1] == 1) return false;
            }
            if ((int)Loc[Loc.Count - 1] == Len - 1) return false;
            return true;
        }
    }
}

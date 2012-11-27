using System;
using System.Collections.Generic;
using System.Text;
using ComputeCommon.Common;
using ComputeCommon.Computers;
using ComputeCommon.Nodes;
using ComputeCommon.Enum;
using ComputeCommon.Interface;
using ComputeCommon.Functions;

namespace ComputeCommon.Enum
{
    public class OperandManager
    {
        static Dictionary<Esymbol, string> _DicoperandFunc = new Dictionary<Esymbol, string>();
        static OperandManager()
        {
            _DicoperandFunc.Add(Esymbol.JieChen,"JieChen");
            _DicoperandFunc.Add(Esymbol.Fan,"QiuFan");
        }
        public static bool isOperand(Esymbol symbol)
        {
            return _DicoperandFunc.ContainsKey(symbol);
        }

        public static OprandType GetOprandType(Esymbol symbol)
        {
            if (isOperand(symbol))
            {
                if (symbol == Esymbol.Fan || symbol==Esymbol.JieChen) return OprandType.Left;
                else return OprandType.Right;
            }
            return OprandType.Nothing;
        }

        public static void ParseOperand(Esymbol symbol,ref string expression,ref int pos,ref int begin,ref int end)
        {
            if (GetOprandType(symbol) == OprandType.Left)
            {
                if (CommonTool.GetSymbol(expression[pos + 1]) == Esymbol.LeftBracket)
                {
                    //replace directly
                    expression = expression.Remove(pos, 1);
                    expression = expression.Insert(pos, _DicoperandFunc[symbol]);

                    pos--;
                }
                else
                {
                    expression = expression.Remove(pos, 1);
                    expression = expression.Insert(pos, _DicoperandFunc[symbol]+"(");

                    int pos2 = pos;
                    pos2 = pos2 + _DicoperandFunc[symbol].Length + "(".Length;
                    for (;pos2<expression.Length && !CommonTool.IsCaculateSymbol(expression[pos2]); pos2++)
                    {
                        
                    }

                    expression = expression.Insert(pos2, ")");
                    pos--;
                }
            }
            else
            {
                //右操作！
            }
        }
    }

    public enum OprandType
    {
        Left,
        Right,
        Nothing,
    }
}

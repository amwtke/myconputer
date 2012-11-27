using System;
using System.Collections.Generic;
using System.Text;
using ComputeCommon.Interface;
using ComputeCommon.Enum;
namespace ComputeCommon.Nodes
{
    public class GeneralNode : INode
    {
        public bool isNumber;
        public INode left;
        public INode right;
        public Esymbol symbol;
        public double number;
        public Epriority priority;

        ////数字节点只能是叶子。
        //public GeneralNode(double number_p)
        //{
        //    number = number_p;
        //    left = right = null;
        //    isNumber = true;
        //    symbol = Esymbol.Nothing;
        //    priority = Epriority.Nothing;
        //}
        //操作符节点初始化
        public void SetUpNode(params object[] paras)//Esymbol symbol_p, INode left_p, INode right_p)
        {
            if (paras != null && paras.Length == 4)
            {
                if (paras[0] != null)
                {
                    number = (double)paras[0];
                    isNumber = true;
                }
                else
                {
                    isNumber = false;
                }

                left = (INode)paras[1];
                right = (INode)paras[2];

                if (paras[3] != null)
                {
                    symbol = (Esymbol)paras[3];
                }
                else
                {
                    symbol = Esymbol.Nothing;
                }

                priority = this.SymbolInPriority(symbol);
            }
            else
                throw new Exception("Node初始化参数数量对！");
        }

        public GeneralNode() { }

        #region INode 成员

        public Epriority SymbolInPriority(ComputeCommon.Enum.Esymbol s)
        {
            if (s == Esymbol.Plus || s == Esymbol.Subtraction) return Epriority.Low;
            else
                if (s == Esymbol.Muliply || s == Esymbol.Division || s == Esymbol.Power || s == Esymbol.Yu || s == Esymbol.Huo) return Epriority.Middle;
                else
                    if (s == Esymbol.RightBracket || s == Esymbol.LeftBracket) return Epriority.High;
                    else return Epriority.Nothing;
        }

        public bool IsNumber { get { return isNumber; } set { isNumber = value; } }

        public INode Left { get { return left; } set { left = value; } }

        public INode Right { get { return right; } set { right = value; } }

        public Esymbol Symbol { get { return symbol; } set { symbol = value; } }

        public double Number { get { return number; } set { number = value; } }

        public Epriority Priority { get { return priority; } set { priority = value; } }

        #endregion
    }
}

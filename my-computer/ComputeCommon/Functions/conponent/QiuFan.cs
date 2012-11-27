using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using ComputeCommon.Interface;
using ComputeCommon.Core;
using ComputeCommon.Nodes;

namespace ComputeCommon.Functions.conponent
{
    public class QiuFan : FuncationAbstract, IFunctionConponent
    {
        readonly int argsNum = 1;
        public string FuncName
        {
            get { return "QiuFan".ToLower(); }
        }

        public double Compute(string expression)
        {
            string[] args = this.LoadArgs(expression);
            if (Validation(args))
            {
                int stackdeep = 0;
                double temp =ComputerCore<GeneralNode>.Compute(ComputerCore<GeneralNode>.Scan(ComputerCore<GeneralNode>.LoadExpression(args[0]), ref stackdeep));
                int retInt=0;
                if(Int32.TryParse(temp.ToString(),out retInt))
                {
                    return ~retInt;
                }
                throw new Exception("QiuFan函数只能作用与Int！ "+temp.ToString());
            }
            throw new Exception("Validation Failed!");
        }

        public string Expression
        {
            get { return "QiuFan(x)"; }
        }

        public override bool Validation(string[] args)
        {
            if (!(args.Length == argsNum)) { return false; }
            return true;
        }
    }
}

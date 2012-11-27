using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using ComputeCommon.Interface;
using ComputeCommon.Core;
using ComputeCommon.Nodes;

namespace ComputeCommon.Functions
{
    public class Sum : FuncationAbstract, IFunctionConponent
    {
        readonly int argsNum = 1;

        #region IFunctionConponent 成员

        public string FuncName
        {
            get { return "sum".ToLower(); }
        }
        public string Expression
        {
            get
            {
                return "sum(...)";
            }
        }
        public override bool Validation(string[] args)
        {
            if (args==null) { return false; }
            return true;
        }

        public double Compute(string expression)
        {
            string[] args = LoadArgs(expression);
            double ret = default(double);
            if (Validation(args))
            {
                for (int i = 0; i < args.Length; i++)
                {
                    int stackdeep = 0;
                    ret += ComputerCore<GeneralNode>.Compute(ComputerCore<GeneralNode>.Scan(ComputerCore<GeneralNode>.LoadExpression(args[i]), ref stackdeep));
                }
                return ret;
            }
            throw new Exception("Validation Failed!");
        }
        #endregion
    }
}

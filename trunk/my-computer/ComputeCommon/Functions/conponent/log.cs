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
    public class Log : FuncationAbstract, IFunctionConponent
    {
        readonly int argsNum = 1;

        #region IFunctionConponent 成员

        public string FuncName
        {
            get { return "log".ToLower(); }
        }
        public string Expression
        {
            get
            {
                return "log(x)";
            }
        }
        public override bool Validation(string[] args)
        {
            if (!(args.Length == argsNum)) { return false; }
            return true;
        }

        public double Compute(string expression)
        {
            string[] args = LoadArgs(expression);
            if (Validation(args))
            {
                int stackdeep = 0;
                return Math.Log10(ComputerCore<GeneralNode>.Compute(ComputerCore<GeneralNode>.Scan(ComputerCore<GeneralNode>.LoadExpression(args[0]), ref stackdeep)));
            }
            throw new Exception("Validation Failed!");
        }
        #endregion
    }
}

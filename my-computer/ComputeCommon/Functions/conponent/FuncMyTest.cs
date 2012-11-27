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
    public class FuncMyTest : FuncationAbstract, IFunctionConponent
    {
        readonly int argsNum = 3;

        #region IFunctionConponent 成员

        public string FuncName
        {
            get { return "my".ToLower(); }
        }
        public string Expression
        {
            get
            {
                return "my(x,y,z)";
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
            double[] rets = new double[args.Length];
            if (Validation(args))
            {
                int stackdeep = 0;
                for (int i = 0; i < rets.Length; i++)
                {
                    rets[i] = ComputerCore<GeneralNode>.Compute(ComputerCore<GeneralNode>.Scan(ComputerCore<GeneralNode>.LoadExpression(args[i]), ref stackdeep));
                }

                return rets[0] + rets[1] + rets[2];
            }
            throw new Exception("Validation Failed!");
        }
        #endregion
    }
}

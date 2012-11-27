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
    public class SuperSum : FuncationAbstract, IFunctionConponent
    {
        readonly int argsNum = 3;

        #region IFunctionConponent 成员

        public string FuncName
        {
            get { return "SuperSum".ToLower(); }
        }
        public string Expression
        {
            get
            {
                return "SuperSum(x,y,z) x-次数，y为叠加基数。";
            }
        }
        public override bool Validation(string[] args)
        {
            if (args.Length == argsNum) { return true; }
            return false;
        }

        public double Compute(string expression)
        {
            int stackdeep = 0;
            string[] args = LoadArgs(expression);
            double ret = default(double);

            int begin = Convert.ToInt32(ComputerCore<GeneralNode>.Compute(args[0], ref stackdeep));
            int end = Convert.ToInt32(ComputerCore<GeneralNode>.Compute(args[1], ref stackdeep));

            //变量参数
            string[] innerArgs = LoadArgs(args[2]);
            string ars2=args[2];

            if (Validation(args))
            {
                for (; begin<=end; begin++)
                {
                    foreach (string s in innerArgs)
                    {
                        args[2] = args[2].ToLower().Replace(s, begin.ToString());
                    }
                    ret+=ComputerCore<GeneralNode>.Compute(args[2],ref stackdeep);
                    args[2] = ars2;
                }
                return ret;
            }
            throw new Exception("Validation Failed!");
        }
        #endregion
    }
}

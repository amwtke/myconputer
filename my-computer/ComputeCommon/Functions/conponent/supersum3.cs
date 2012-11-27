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
    public class SuperSum3 : FuncationAbstract, IFunctionConponent
    {
        readonly int argsNum = 6;

        #region IFunctionConponent 成员

        public string FuncName
        {
            get { return "SuperSum3".ToLower(); }
        }
        public string Expression
        {
            get
            {
                return "SuperSum3(1,2,3,4,5,6) 1-2范围；3-5 变参数函数；6求和函数。";
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
            string[] innerArgs6 = LoadArgs(args[5]);
            string ars6 = args[5];


            string[] innerArg5 = LoadArgs(args[4]);
            string ars5 = args[4];

            string[] innerArg4 = LoadArgs(args[3]);
            string ars4 = args[3];

            string[] innerArg3 = LoadArgs(args[2]);
            string ars3 = args[2];


            if (Validation(args))
            {
                for (; begin <= end; begin++)
                {
                    foreach (string s in innerArg5)
                    {
                        args[4] = args[4].ToLower().Replace(s, begin.ToString());
                        args[4] = ComputerCore<GeneralNode>.Compute(args[4], ref stackdeep).ToString();
                    }

                    foreach (string s in innerArg4)
                    {
                        args[3] = args[3].ToLower().Replace(s, begin.ToString());
                        args[3] = ComputerCore<GeneralNode>.Compute(args[3], ref stackdeep).ToString();
                    }


                    foreach (string s in innerArg3)
                    {
                        args[2] = args[2].ToLower().Replace(s, begin.ToString());
                        args[2] = ComputerCore<GeneralNode>.Compute(args[2], ref stackdeep).ToString();
                    }



                    args[5] = args[5].ToLower().Replace(innerArgs6[0], args[2]);
                    args[5] = args[5].ToLower().Replace(innerArgs6[1], args[3]);
                    args[5] = args[5].ToLower().Replace(innerArgs6[2], args[4]);

                    ret += ComputerCore<GeneralNode>.Compute(args[5], ref stackdeep);
                    args[5] = ars6;
                    args[2] = ars3;
                    args[3] = ars4;
                    args[4] = ars5;

                }
                return ret;
            }
            throw new Exception("Validation Failed!");
        }
        #endregion
    }
}

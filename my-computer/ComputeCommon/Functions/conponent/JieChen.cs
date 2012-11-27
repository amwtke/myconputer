using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using ComputeCommon.Interface;
using ComputeCommon.Core;
using ComputeCommon.Nodes;
using ComputeCommon.Algorithm;

namespace ComputeCommon.Functions.conponent
{
    public class JieChen : FuncationAbstract, IFunctionConponent
    {
        readonly int argsNum = 1;

        public string FuncName
        {
            get { return "JieChen".ToLower(); }
        }

        public double Compute(string expression)
        {
            string[] args = this.LoadArgs(expression);
            if (Validation(args))
            {
                int stackdeep = 0;
                double temp = ComputerCore<GeneralNode>.Compute(ComputerCore<GeneralNode>.Scan(ComputerCore<GeneralNode>.LoadExpression(args[0]), ref stackdeep));
                int retInt = 0;
                if (Int32.TryParse(temp.ToString(), out retInt))
                {
                    if (retInt < 0) throw new Exception("Jiechen函数不能为负数！");
                    else
                    {
                        Factorial f = new Factorial(retInt);
                        List<int> result = f.Calculate();
                        String ret = f.ToString();
                        return Double.Parse(ret);
                    }
                }
                throw new Exception("JieChen函数只能作用与Int！ " + temp.ToString());
            }
            throw new Exception("Validation Failed!");
        }

        public string Expression
        {
            get { return "JieChen(x)"; }
        }

        public override bool Validation(string[] args)
        {
            if (!(args.Length == argsNum)) { return false; }
            return true;
        }
    }
}

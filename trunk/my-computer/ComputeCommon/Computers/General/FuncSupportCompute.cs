using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputeCommon.Interface;
using ComputeCommon.Enum;
using ComputeCommon.Common;
using ComputeCommon.Core;
using ComputeCommon.Functions;
using ComputeCommon.Nodes;

namespace ComputeCommon.Computers
{
    public class FuncSupportCompute : IComputeConponent
    {
        public List<Object> LoadExpression(string formula, Dictionary<string, IFunctionConponent> funcDic)
        {
            try
            {
                return ComputerCore<GeneralNode>.LoadExpression(formula);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        int stackDeep = 0;
        public int StackDeep { get { return stackDeep; } }
        public string ConponentName { get { return "General"; } }

        public INode Scan(List<object> charInput)
        {
            try
            {
                return ComputerCore<GeneralNode>.Scan(charInput, ref stackDeep);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double Compute(INode root)
        {
            try
            {
                return ComputerCore<GeneralNode>.Compute(root);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CleanUp()
        {
            ComputerCore<GeneralNode>.CleanUp();
            stackDeep = 0;
        }
    }
}

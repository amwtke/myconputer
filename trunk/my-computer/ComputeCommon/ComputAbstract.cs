using System;
using System.Collections.Generic;
using System.Text;
using ComputeCommon.Interface;
using ComputeCommon.Computers;
using ComputeCommon.Functions;

namespace ComputeCommon
{
    public abstract class ComputAbstract
    {
        static IComputeConponent _computeComponent=null;
        static ComputAbstract()
        {
            //_computeComponent = new GeneralComput();
            _computeComponent = new FuncSupportCompute();
        }

        public static double DoCompute(string expression)
        {
            try
            {
                return _computeComponent.Compute(_computeComponent.Scan(_computeComponent.LoadExpression(expression,FunctionManager.FuncModols)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IComputeConponent Computer
        {
            get
            {
                return _computeComponent;
            }
        }
    }
}

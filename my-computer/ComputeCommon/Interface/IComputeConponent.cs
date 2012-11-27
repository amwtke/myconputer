using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputeCommon.Interface
{
	public interface IComputeConponent
	{
        string ConponentName { get;}
        List<Object> LoadExpression(string expression, Dictionary<string, IFunctionConponent> funcDic);
        INode Scan(List<object> expressNodes);
        double Compute(INode root);
        int StackDeep { get; }
        void CleanUp();
	}
}

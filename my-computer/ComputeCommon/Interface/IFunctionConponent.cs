using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace ComputeCommon.Interface
{
	public interface IFunctionConponent
	{
        string FuncName { get; }
        double Compute(string expression);
        string Expression { get; }
	}
}

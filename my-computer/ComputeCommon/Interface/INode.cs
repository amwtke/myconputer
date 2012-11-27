using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputeCommon.Enum;

namespace ComputeCommon.Interface
{
	public interface INode
	{
        Epriority SymbolInPriority(Esymbol s);
        bool IsNumber { get; set; }
        INode Left { get; set; }
        INode Right { get; set; }
        Esymbol Symbol { get; set; }
        double Number { get; set; }
        Epriority Priority{get;set;}

        /// <summary>
        /// 1:number
        /// 2:left
        /// 3:right
        /// 4:symbol
        /// </summary>
        /// <param name="paras"></param>
        void SetUpNode(params object[] paras);
	}
}

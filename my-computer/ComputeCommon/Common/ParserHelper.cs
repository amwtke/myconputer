using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputeCommon.Core;
using ComputeCommon.Enum;
using ComputeCommon.Nodes;
using ComputeCommon.Functions;

namespace ComputeCommon.Common
{
    public class ParserHelper
    {
        public static void ConstsParser(string wholeFormula,ref int begin,ref int end,ref int pos,ParserObject p,List<object> charInput)
        {
            string constExpression = wholeFormula.Substring(begin, end - begin).ToLower();
            if (ConstNumbers.Consts.ContainsKey(constExpression))
            {
                charInput.Add(ConstNumbers.Consts[constExpression]);
                charInput.Add(CommonTool.GetSymbol(wholeFormula[pos]));
            }
            else
                throw new Exception("UNKNOW CONST! " + constExpression + " .");

            //归零
            begin = end = pos + 1;
            p.SetClear();
        }

        public static void FuncParser(string wholeFormula, ref int begin, ref int end, ref int pos, ParserObject p, List<object> charInput)
        {
            string funExpression = wholeFormula.Substring(begin, end - begin + 1).ToLower();
            string funcname = CommonTool.GetFuncName(funExpression).ToLower();

            if ((funcname != string.Empty) && FunctionManager.IsFunc(funcname))
            {
                charInput.Add(FunctionManager.FuncModols[funcname].Compute(funExpression));

                //归零
                begin = end = pos + 1;
                p.SetClear();
            }
            else if ((funcname != string.Empty) && UserDefinFuncManager.IsUFunc(funcname))
            {
                charInput.Add(UFuncParser.ComputeUfun(UserDefinFuncManager.UserFuncDic[funcname], funExpression));
                //归零
                begin = end = pos + 1;
                p.SetClear();
            }
        }
    }

    public class ParserObject
    {
        public int leftCount;
        public int rightCount;
        public bool inSepcialScope;
        public bool inFuncScope;
        public bool inConstScope;

        public ParserObject()
        {
            leftCount = rightCount = 0;
            inSepcialScope = inFuncScope = inConstScope = false;
        }
        public void SetClear()
        {
            leftCount = rightCount = 0;
            inSepcialScope = inConstScope = inFuncScope = false;
        }
    }
}

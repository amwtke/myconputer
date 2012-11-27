using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputeCommon.Core;
using ComputeCommon.Nodes;

namespace ComputeCommon.Functions
{
    public class UFuncParser : FuncationAbstract
    {
        public static string GetUfuncName(string wholething)
        {
            return GetDefinition(wholething).Split(new char[] { '(' })[0].Trim();
        }

        public static string GetDefinition(string wholething)
        {
            return wholething.Split(new char[] { '=' })[0];
        }

        public static string GetUfuncExpression(string wholething,bool withP)
        {
            string rets = wholething.Split(new char[] { '=' })[1];
            if(withP)
                MarkParenthese(ref rets);
            return rets;
        }

        public static string[] GetVariables(string wholething)
        {
            string def = GetDefinition(wholething);
            return SLoadArgs(def);
        }

        public override bool Validation(string[] args)
        {
            return true;
        }

        private static string Parse(string wholething,string Args)
        {
            string[] realArgs = SLoadArgs(Args);
            string[] variables = GetVariables(wholething);
            if (realArgs.Length != variables.Length)
                throw new Exception("自定义函数参数数量错误！");

            string expression_withp = GetUfuncExpression(wholething,true);
            MarkParenthese(ref realArgs);

            for (int i = 0; i < variables.Length; i++)
            {
                expression_withp = expression_withp.Replace(variables[i], realArgs[i]);
            }

            return expression_withp;
        }

        public static double ComputeUfun(string wholething, string realArgs)
        {
            string expression = Parse(wholething, realArgs);
            int stackdeep=0;
            return ComputerCore<GeneralNode>.Compute(expression, ref stackdeep);
        }

        private static void MarkParenthese(ref string s)
        {
            s = "(" + s;
            s = s + ")";
        }

        private static void MarkParenthese(ref string[] array)
        {
            for(int i=0;i<array.Length;i++)
            {
                MarkParenthese(ref array[i]);
            }
        }
    }
}

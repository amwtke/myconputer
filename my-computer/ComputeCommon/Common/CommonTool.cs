using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputeCommon.Enum;
using ComputeCommon.Interface;

namespace ComputeCommon.Common
{
    public class CommonTool
    {
        public static double StringToFloat(String s)
        {
            return double.Parse(s);
        }

        public static Esymbol GetSymbol(char c)
        {
            if (SymbolContainer.SymbolDic.ContainsKey(c))
            {
                return SymbolContainer.SymbolDic[c];
            }

            return Esymbol.Nothing;

        }

        #region is
        public static bool ObjectIsSymbol(Object o)
        {
            if (o != null)
                return o is Esymbol;
            else return false;
        }

        public static bool ObjectIsNode(Object o)
        {
            if (o != null)
                return o is INode;
            else return false;
        }

        public static bool ObjectIsFunc(object o)
        {
            if (o != null)
                return o is IFunctionConponent;
            else
                return false;
        }
        #endregion

        #region parse expression
        public static bool IsNumber(char c)
        {
            if (c == '.') return true;
            return Char.IsDigit(c);
        }

        public static bool IsFuncPrix(char c)
        {
            return (!IsNumber(c)) && (!IsSymbolPrix(c));
        }

        public static bool IsSymbolPrix(char c)
        {
            if (SymbolContainer.SymbolDic.ContainsKey(c))
            {
                return true;
            }

            return false;
        }

        public static void ParenthesesComplete(char c,ref int l,ref int r)
        {
            if (GetSymbol(c) == Esymbol.LeftBracket) l++;
            if (GetSymbol(c) == Esymbol.RightBracket) r++;
        }

        public static void FuncConstScopeJudger(char c, int leftcount, int rightcount, ref bool infuncscope, ref bool inconstscope)
        {
            if (IsCaculateSymbol(c) && infuncscope==false)
            {
                inconstscope = true;
            }
            else if (leftcount < rightcount)
            {
                infuncscope = false;
                inconstscope = true;
            }
            else if (leftcount > rightcount)
            {
                infuncscope = true;
                inconstscope = false;
            }
        }

        #endregion

        public static string GetFuncName(string expression)
        {
            if (expression.Contains("("))
            {
                return expression.Substring(0, expression.IndexOf('('));
            }
            return string.Empty;
        }

        public static bool IsCaculateSymbol(char c)
        {
            Esymbol s = GetSymbol(c);
            if (s == Esymbol.Division || s == Esymbol.Muliply || s == Esymbol.Plus || s == Esymbol.Subtraction||s==Esymbol.Power)
                return true;
            return false;
        }

        public static string GetAssemblyPath()
        {
            string _CodeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            _CodeBase = _CodeBase.Substring(8, _CodeBase.Length - 8);    // 8是 file:// 的长度
            string[] arrSection = _CodeBase.Split(new char[] { '/' });

            string _FolderPath = "";
            for (int i = 0; i < arrSection.Length - 1; i++)
            {
                _FolderPath += arrSection[i] + "/";
            }
            return _FolderPath;
        }

        public static string KillSpace(string s)
        {
            for (int i = 0; i < s.Length; i++)
            { 
                if(char.IsWhiteSpace(s[i]))
                    s.Remove(i,1);
            }
            return s;
        }
    }
}

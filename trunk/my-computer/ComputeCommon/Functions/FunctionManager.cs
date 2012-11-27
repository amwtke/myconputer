using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputeCommon.Interface;
using ComputeCommon.Common;
using ComputeCommon.Functions;
using System.Reflection;

namespace ComputeCommon.Functions
{
    public class FunctionManager
    {
        static Dictionary<string, IFunctionConponent> _funcDic = null;
        public static Dictionary<string, IFunctionConponent> FuncModols
        {
            get
            {
                return _funcDic;
            }
        }
        static FunctionManager()
        {
            _funcDic = new Dictionary<string, IFunctionConponent>();
            LoadFuncModels(CommonTool.GetAssemblyPath());
        }
        public static void LoadFuncModels(string filePath)
        {
            foreach (Type t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes())
            {
                if (t.IsClass && t.GetInterface("IFunctionConponent", true) != null)
                {
                    IFunctionConponent temp = (IFunctionConponent)t.InvokeMember(string.Empty, BindingFlags.CreateInstance, null, null, null);
                    if (temp is IFunctionConponent)
                        Add(temp);
                }

            }
        }
        public static bool IsFunc(string funcName)
        {
            return FuncModols.ContainsKey(funcName.ToLower());
        }

        static void Add(IFunctionConponent func)
        {
            if (func != null && func.FuncName != null && func.FuncName.Length > 0)
            {
                if (!FuncModols.ContainsKey(func.FuncName))
                {
                    FuncModols.Add(func.FuncName, func);
                }
            }
        }
    }
}

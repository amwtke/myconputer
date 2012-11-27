using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using ComputeCommon.Common;
using System.IO;


namespace ComputeCommon.Functions
{
    public class UserDefinFuncManager
    {
        readonly static string FILENAME;
        static UFuncs _uFuncs = new UFuncs();
        static Dictionary<string, string> _userFuncs=null;
        public static Dictionary<string, string> UserFuncDic
        {
            get
            {
                if (_userFuncs != null)
                    return _userFuncs;
                throw new Exception("ufunc Not Loaded Correctly!");
            }
        }


        static UserDefinFuncManager()
        {
            FILENAME = CommonTool.GetAssemblyPath() + @"ufunc.xml";
            _userFuncs = new Dictionary<string, string>();
            LoadUfuncs();
        }


        static void LoadUfuncs()
        {
            if (!File.Exists(FILENAME))
            {
                //nothing
            }
            else
            {
                try
                {
                    _uFuncs = SerializerHelper.XMLDeSerialize<UFuncs>(FILENAME);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (_uFuncs != null)
                {
                    foreach (UserDefinFunItem n in _uFuncs.Items)
                    {
                        CreateUfunc(n.UfuncName, n.UfuncExpression);
                    }
                }
            }
        }

        public static bool IsUFunc(string funcName)
        {
            return UserFuncDic.ContainsKey(funcName);
        }

        public static bool CreateUfunc(string functName, string expression)
        {
            if (UserFuncDic.ContainsKey(functName)) return false;
            else
            {
                UserFuncDic.Add(functName, expression);
                return true;
            }
        }

        public static void CreateUfuncOverWrite(string functName, string expression)
        {
            UserFuncDic[functName] = expression;
        }

        public static void Dump()
        {
            try
            {
                UserDefinFunItem[] nodes = new UserDefinFunItem[UserFuncDic.Count];
                int i = 0;

                foreach (KeyValuePair<string, string> pair in UserFuncDic)
                {
                    nodes[i] = new UserDefinFunItem();
                    nodes[i].UfuncName = pair.Key;
                    nodes[i].UfuncExpression = pair.Value;
                    i++;
                }

                UFuncs temp = new UFuncs();
                temp.Items = nodes;

                SerializerHelper.XMLSerialize(FILENAME, temp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }


    [XmlRootAttribute("UFuncs", Namespace = "http://www.xiaojin.com",
IsNullable = false)]
    public class UFuncs
    {
        private UserDefinFunItem[] _items;

        [XmlArrayAttribute("Items")]
        public UserDefinFunItem[] Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
            }
        }
    }


    public class UserDefinFunItem
    {
        private string _funcName;
        private string _funcExpression;

        public string UfuncName
        {
            get
            {
                return _funcName;
            }
            set
            {
                _funcName = value;
            }
        }

        public string UfuncExpression
        {
            get
            {
                return _funcExpression;
            }
            set
            {
                _funcExpression = value;
            }
        }
    }
}

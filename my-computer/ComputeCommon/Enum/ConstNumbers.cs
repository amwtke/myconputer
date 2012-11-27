using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using ComputeCommon.Common;
using System.IO;

namespace ComputeCommon.Enum
{
    public class ConstNumbers
    {
        readonly static string FILENAME;

        static Dictionary<string, double> _constsDic;
        static ConstNodes _nodes;

        public static Dictionary<string, double> Consts
        {
            get
            {
                if (_constsDic != null)
                    return _constsDic;
                throw new Exception("Consts Not Loaded Correctly!");
            }
        }
        static ConstNumbers()
        {
            FILENAME = CommonTool.GetAssemblyPath() + @"const.xml";

            _constsDic = new Dictionary<string, double>();
            LoadConsts();
        }

        static void LoadConsts()
        {
            if (!File.Exists(FILENAME))
            {
                Consts.Add("PI".ToLower(), Math.PI);
                Consts.Add("My".ToLower(), 1234.4);
                Consts.Add("E".ToLower(), Math.E);
            }
            else
            {
                try
                {
                    _nodes = SerializerHelper.XMLDeSerialize<ConstNodes>(FILENAME);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (_nodes != null)
                {
                    foreach (ConstNode n in _nodes.Nodes)
                    {
                        CreateConst(n.Name, n.Value);
                    }
                }
            }
        }

        public static bool CreateConst(string constName,double value)
        {
            if (Consts.ContainsKey(constName)) return false;
            else
            {
                Consts.Add(constName, value);
                return true;
            }
        }

        public static void CreateConstOverWrite(string constName, double value)
        {
            Consts[constName] = value;
        }

        public static void Dump()
        {
            try
            {
                ConstNode[] nodes = new ConstNode[_constsDic.Count];
                int i = 0;

                foreach (KeyValuePair<string, double> pair in _constsDic)
                {
                    nodes[i] = new ConstNode();
                    nodes[i].Name = pair.Key;
                    nodes[i].Value = pair.Value;
                    i++;
                }

                ConstNodes temp = new ConstNodes(); temp.Nodes = nodes;

                SerializerHelper.XMLSerialize(FILENAME,temp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    [XmlRootAttribute("Consts", Namespace="http://www.xiaojin.com", 
IsNullable = false)]
    public class ConstNodes
    {
        private ConstNode[] _nodes;

        [XmlArrayAttribute("Items")]
        public ConstNode[] Nodes
        {
            get
            {
                if (_nodes != null && _nodes.Length > 0)
                    return _nodes;
                else
                    return null;
            }
            set
            {
                _nodes = value;
            }
        }
    }

    public class ConstNode
    {
        private string _name;
        private double? _value;

        public string Name
        {
            get
            {
                return _name;
            }
            set 
            {
                _name = value;
            }
        }

        public double Value
        {
            get
            {
                if (_value != null) 
                    return _value.Value;
                return 0L;
            }
            set
            {
                _value= value;
            }
        }
    }
}

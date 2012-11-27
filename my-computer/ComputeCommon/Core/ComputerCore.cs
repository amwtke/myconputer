using System;
using System.Collections.Generic;
using System.Text;
using ComputeCommon.Common;
using ComputeCommon.Computers;
using ComputeCommon.Nodes;
using ComputeCommon.Enum;
using ComputeCommon.Interface;
using ComputeCommon.Functions;

namespace ComputeCommon.Core
{
    /// <summary>
    /// Support function
    /// </summary>
    public sealed class ComputerCore<T> where  T : INode, new()
    {
        public static double Compute(string expression, ref int stackDeep)
        {
            try
            {
                return ComputerCore<GeneralNode>.Compute(ComputerCore<GeneralNode>.Scan(ComputerCore<GeneralNode>.LoadExpression(expression), ref stackDeep));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static void Parser(string Formula, ref ParserObject p,List<object> charInput)
        {
            int begin = 0, end = 0;
            Formula = Formula.Trim();

            if (Formula != null && Formula.Length > 0)
            {
                for (int pos=0; pos < Formula.Length; pos++)
                {
                    if (p.inSepcialScope || CommonTool.IsFuncPrix(Formula[pos]))
                    {
                        CommonTool.ParenthesesComplete(Formula[pos], ref p.leftCount, ref p.rightCount);
                        CommonTool.FuncConstScopeJudger(Formula[pos], p.leftCount, p.rightCount, ref p.inFuncScope, ref p.inConstScope);

                        if (p.inConstScope)
                        {
                            ParserHelper.ConstsParser(Formula, ref begin, ref end, ref pos, p, charInput);
                            continue;
                        }

                        if (p.inFuncScope)
                        {
                            if (p.leftCount == p.rightCount)
                            {
                                ParserHelper.FuncParser(Formula, ref begin, ref end, ref pos, p, charInput);
                                continue;
                            }
                        }

                        end++;
                        p.inSepcialScope = true;
                
                    }
                    else if (!CommonTool.IsNumber(Formula[pos]))
                    {
                        if (OperandManager.isOperand(CommonTool.GetSymbol(Formula[pos])))
                        {
                            OperandManager.ParseOperand(CommonTool.GetSymbol(Formula[pos]), ref Formula, ref pos, ref begin, ref end);
                        }
                        else
                        {
                            if (begin != end)
                            {
                                charInput.Add(CommonTool.StringToFloat(Formula.Substring(begin, end - begin)));
                            }
                            charInput.Add(CommonTool.GetSymbol(Formula[pos]));
                            begin = end = pos + 1;
                        }
                    }
                    else//数字
                    {
                        end++;
                    }
                }
                //after read all the symbols
                //The last word is numeric the algorithm above is not correct.
                if (p.inSepcialScope)//const
                {
                    string constExpression = Formula.Substring(begin, end - begin).ToLower();
                    if (ConstNumbers.Consts.ContainsKey(constExpression))
                    {
                        charInput.Add(ConstNumbers.Consts[constExpression]);
                    }
                }
                else if (CommonTool.IsNumber(Formula[Formula.Length - 1]))
                {
                    charInput.Add(CommonTool.StringToFloat(Formula.Substring(begin, end - begin)));
                }
            }
            else
            {
                throw new Exception("Formula must contain a word!");
            }
        }
        public static List<Object> LoadExpression(string formula)
        {
            formula = CommonTool.KillSpace(formula);
            List<Object> charInput = new List<object>();
            ParserObject p = new ParserObject();
            Parser(formula, ref p ,charInput);

            return charInput;
        }

        public static T Scan(List<object> charInput, ref int stackDeep)
        {
            T n;
            Stack<Object> stack = new Stack<Object>();
            //use as reverse.
            Stack<Object> _innerStack = new Stack<Object>();

            for (int i = 0; i < charInput.Count; i++)
            {
                Object temp = charInput[i];
                if (CommonTool.ObjectIsSymbol(temp) && (Esymbol)temp == Esymbol.LeftBracket)
                {
                    //System.out.println("scan1");
                    stack.Push(temp);
                }
                else if (CommonTool.ObjectIsSymbol(temp) && (Esymbol)temp == Esymbol.RightBracket)
                {
                    //System.out.println("scan2");
                    _innerStack.Clear();
                    while (stack.Count > 0)
                    {
                        Object inner = stack.Pop();
                        if (CommonTool.ObjectIsSymbol(inner) && (Esymbol)inner == Esymbol.LeftBracket) break;

                        _innerStack.Push(inner);
                    }
                    stack.Push(gen_tree(_innerStack, ref stackDeep));//push result
                    _innerStack.Clear();
                }
                else
                    stack.Push(temp);
            }
            //compose no parensises!
            _innerStack.Clear();
            while (stack.Count > 0)
            {
                Object inner = stack.Pop();
                _innerStack.Push(inner);
            }
            n = gen_tree(_innerStack, ref stackDeep);
            _innerStack.Clear();

            return n;
        }
        static T gen_tree(Stack<Object> s, ref int stackDeep)
        {
            stackDeep++;

            T ret = default(T);
            if (s.Count == 2)//负数
            {
                double innerfloat = .0f;
                if ((Esymbol)s.Pop() == Esymbol.Subtraction)
                {
                    innerfloat = (double)s.Pop();
                    innerfloat = 0 - innerfloat;
                    ret = new T();
                    ret.SetUpNode(innerfloat, null, null, null);//= new T(innerfloat);
                }
            }
            else
            {
                T parent = default(T);
                while (s.Count > 0)
                {
                    Object innerObject = s.Pop();
                    if (!CommonTool.ObjectIsSymbol(innerObject) && !CommonTool.ObjectIsNode(innerObject))//number
                    {
                        if (parent == null)
                        {
                            parent = new T();
                            parent.SetUpNode((double)innerObject, null, null, null);//= new T((double)innerObject);
                        }
                        else if (parent.Right == null)
                        {
                            parent.Right = new T();
                            parent.Right.SetUpNode((double)innerObject, null, null, null);// = new T((double)innerObject);
                        }
                        else if (parent.Right.Right == null)
                        {
                            parent.Right.Right = new T();
                            parent.Right.Right.SetUpNode((double)innerObject, null, null, null);// = new T((double)innerObject);
                        }
                    }
                    else if (CommonTool.ObjectIsNode(innerObject))
                    {
                        if (parent == null)
                        {
                            if (s.Count == 0) return (T)innerObject;
                            parent = new T();
                            parent.SetUpNode(null,null,null,(Esymbol)s.Pop());// = new T((Esymbol)s.Pop(), null, null);
                            parent.Left = (T)innerObject;
                        }
                        else if (parent.Right == null)
                        {
                            parent.Right = (T)innerObject;
                        }
                        else if (parent.Right.Right == null)
                            parent.Right.Right = (T)innerObject;
                    }
                    else if (CommonTool.ObjectIsSymbol(innerObject))
                    {
                        T temp = new T(); 
                        temp.SetUpNode(null, null, null, (Esymbol)innerObject);
                        parent = addSymbolReturnParent(temp, parent);
                    }
                }

                ret = parent;
            }

            return ret;
        }
        static T addSymbolReturnParent(T symbol, T parent)
        {
            T ret = default(T);
            if (parent.IsNumber == true)
            {
                symbol.Left = parent;
                ret = symbol;
            }
            else
            {
                if (symbol.Priority - parent.Priority > 0)
                {
                    symbol.Left = parent.Right;
                    parent.Right = symbol;
                    ret = parent;
                }
                else if (symbol.Priority - parent.Priority <= 0)
                {
                    symbol.Left = parent;
                    ret = symbol;
                }
            }

            return ret;
        }
        public static double Compute(INode root)
        {
            double left, right; left = right = .0f;
            double ret = .0f;

            if (root.IsNumber == true)
            {
                return root.Number;
            }
            else
            {
                if (root.Left != null)
                {
                    left = Compute(root.Left);
                }
                if (root.Right != null)
                {
                    right = Compute(root.Right);
                }
            }

            if (root.Symbol == Esymbol.Plus) ret = left + right;
            if (root.Symbol == Esymbol.Subtraction) ret = left - right;
            if (root.Symbol == Esymbol.Muliply) ret = left * right;
            if (root.Symbol == Esymbol.Division) ret = left / right;
            if (root.Symbol == Esymbol.Power) ret = Math.Pow(left, right);
            if (root.Symbol == Esymbol.Huo) ret = Convert.ToInt32(left) | Convert.ToInt32(right);
            if (root.Symbol == Esymbol.Yu) ret = Convert.ToInt32(left) & Convert.ToInt32(right);
            return ret;
        }

        public static void CleanUp()
        {
            //Nothing
        }
    }
}

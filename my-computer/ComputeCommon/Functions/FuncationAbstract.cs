using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using ComputeCommon.Common;

namespace ComputeCommon.Functions
{
    public abstract class FuncationAbstract
    {
        public virtual string[] LoadArgs(string expression)
        {
            int left = expression.IndexOf('(') + 1;
            int right = expression.Length - 1;
            expression = expression.Substring(left, right - left);



            int begin, end;
            begin = end = 0;
            int leftCount, rightCount;
            leftCount = rightCount = 0;
            List<string> args = new List<string>();

            for (int i = 0; i < expression.Length; i++)
            {
                CommonTool.ParenthesesComplete(expression[i], ref leftCount, ref rightCount);
                if (expression[i] == ',' && leftCount == rightCount)
                {
                    args.Add(expression.Substring(begin, end - begin));

                    begin = end = i + 1;
                    continue;
                }
                else
                {
                    end++;
                }
            }

            //最后一个逗号后面的
            args.Add(expression.Substring(begin, end - begin));

            return args.ToArray();
        }

        public static string[] SLoadArgs(string expression)
        {
            int left = expression.IndexOf('(') + 1;
            int right = expression.Length - 1;
            expression = expression.Substring(left, right - left);



            int begin, end;
            begin = end = 0;
            int leftCount, rightCount;
            leftCount = rightCount = 0;
            List<string> args = new List<string>();

            for (int i = 0; i < expression.Length; i++)
            {
                CommonTool.ParenthesesComplete(expression[i], ref leftCount, ref rightCount);
                if (expression[i] == ',' && leftCount == rightCount)
                {
                    args.Add(expression.Substring(begin, end - begin));

                    begin = end = i + 1;
                    continue;
                }
                else
                {
                    end++;
                }
            }
            args.Add(expression.Substring(begin, end - begin));

            return args.ToArray();
        }

        public abstract bool Validation(string[] args);
    }
}

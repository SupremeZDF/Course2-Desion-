using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExerCiseExpresions.ExpressionModel
{
    public static class OneExerciseTool
    {
        public static string NodeTypeTostring(this ExpressionType type) 
        {
            var str = "";
            switch (type) 
            {
                case ExpressionType.Add:
                    str = "+";
                    ;break;
                case ExpressionType.Subtract:
                    str = "-";
                    ; break;
                case ExpressionType.Multiply:
                    str = "*";
                    ; break;
                case ExpressionType.Divide:
                    str = "/";
                    ; break;
            }
            return str;
        }
    }
}

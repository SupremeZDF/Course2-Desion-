using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Diagnostics;

namespace ExerCiseExpresions.ExpressionModel
{
    public class TwoExpressionExercise : ExpressionVisitor
    {
        public  Stack<string> GetVs = new Stack<string>();

        public void Modify(Expression node)
        {
            var vis = Visit(node);
            var ss = 1;
            string[] s = GetVs.ToArray();
            Debug.WriteLine(string.Concat(s));
        }

        //public override Expression Visit(Expression node)
        //{
        //    //var to = node.ToString();
        //    //Debug.WriteLine(to);
        //    return base.Visit(node);
        //}

        //Expression<Func<int, int, int>> expression = (m, n) => m * n - 2 + (m / n) * n + 2*m;
        //m * n - 2 - m
        protected override Expression VisitBinary(BinaryExpression node) 
        {
            if (node == null)
                throw new ArgumentNullException("");
            //var sub = node.Left;
            //var sup = node.Right;
            GetVs.Push(")");
            var sub = Visit(node.Right);
            GetVs.Push(node.NodeType.NodeTypeTostring());
            var sup = Visit(node.Left);
            GetVs.Push("(");
            if (node.NodeType == ExpressionType.Subtract)
            {
                return Expression.Add(sup, sub);
            }
            //base.VisitBinary(node);
            //var bb = Expression.Subtract(sup , sup);
            return node;
        }

        protected override Expression VisitMember(MemberExpression node) 
        {
            if (node == null)
                throw new ArgumentNullException("");
            GetVs.Push(node.Member.Name);
            return node;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node == null)
                throw new ArgumentNullException("");
            GetVs.Push(node.Name);
            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node == null)
                throw new ArgumentNullException("");
            GetVs.Push(node.ToString());
            return node;
        }
    }
}

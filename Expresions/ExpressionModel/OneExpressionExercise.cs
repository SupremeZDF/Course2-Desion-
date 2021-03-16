using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ExerCiseExpresions.ExpressionModel
{
    public class OneExpressionExercise :ExpressionVisitor
    {

        public OneExpressionExercise() 
        {
        
        }

        public void Modify(System.Linq.Expressions.Expression expresions) 
        {
            this.Visit(expresions);
        }

        // ExpressionVisitor 访问者类 visit是个入口 解读表达式的入口
        // lambda 会区分参数和方法体，调度到更专业访问（处理方法）
        // 根据表达式的类型 将表达式调度到此类中更专业的访问方法之一的表达式
        // 默认的专业处理方法就是按照旧得模式产生一个新的

        //二叉树遍历
        public override Expression Visit(Expression node) 
        {
            var s = node.ToString();
            return base.Visit(node);
        }

        // (m + n) * m + 2 二叉树遍历
        protected  override Expression VisitBinary(BinaryExpression node) 
        {
            Expression expression = this.Visit(node.Left);
            Expression expression1 = this.Visit(node.Right);
            if (node.NodeType == ExpressionType.Add) 
            {
                return Expression.Subtract(expression, expression1);
            }
            if (node.NodeType == ExpressionType.Multiply) 
            {
                return Expression.Divide(expression, expression1);
            }
            Expression expression2 = base.VisitBinary(node);
            return expression2;
        }

        protected  override Expression VisitConstant(ConstantExpression node) 
        {
            return base.VisitConstant(node);
        }
    }
}

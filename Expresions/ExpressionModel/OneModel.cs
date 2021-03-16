using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ExerCiseExpresions.ExpressionModel
{
    public class OneModel
    {
        public static void IOneRun() 
        {
            Expression<Func<int, int, int>> expression = (m, n) => (m + n) + 2 + (m + n) * m + 2;
            OneExpressionExercise oneExpression = new OneExpressionExercise();
            oneExpression.Modify(expression);
        }

        // 
        public static void ITwoRun() 
        {
            Expression<Func<int, int, int>> expression = (m, n) => m * n - 2 + (m / n) * n + 2 * m;
            TwoExpressionExercise twoExpressionExercise = new TwoExpressionExercise();
            var s = twoExpressionExercise.Visit(expression);
        }
    }
}

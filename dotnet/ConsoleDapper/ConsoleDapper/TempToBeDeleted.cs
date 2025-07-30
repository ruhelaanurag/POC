using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDapper
{
    internal class TempToBeDeleted
    {
        public static void ExpressionTr()
        {
            Expression<Func<int, int>> addFive = (num) => num + 5;

            if (addFive is LambdaExpression lambdaExp)
            {
                var parameter = lambdaExp.Parameters[0]; // first
            
                Console.WriteLine(parameter.Name);
                Console.WriteLine(parameter.Type);
            }
        }

        public static void CreateExprTr()
        {
            // Addition is an add expression for "1 + 2"
            var one = Expression.Constant(1, typeof(int));
            var two = Expression.Constant(2, typeof(int));
            var addition = Expression.Add(one, two);
        }
        public static void CoPilotGen()
        {
            // Create a parameter expression.
            ParameterExpression paramExpr = Expression.Parameter(typeof(int), "arg");

            // Create an expression to hold a local variable. 
            ParameterExpression variableExpr = Expression.Variable(typeof(int), "variable");

            // Create a block that contains an expression to increment the variable.
            BlockExpression blockExpr = Expression.Block(
                               new[] { variableExpr },
                                              Expression.Assign(variableExpr, Expression.Constant(1)),
                                                             Expression.AddAssign(variableExpr, paramExpr)
                                                                        );

            // Create a lambda expression.
            Expression<Func<int, int>> lambdaExpr = Expression.Lambda<Func<int, int>>(
                               blockExpr,
                                              paramExpr
                                                         );

            // Compile and run the lambda expression.
            Func<int, int> compiledExpr = lambdaExpr.Compile();
            Console.WriteLine(compiledExpr(1));
        }   
    }
}

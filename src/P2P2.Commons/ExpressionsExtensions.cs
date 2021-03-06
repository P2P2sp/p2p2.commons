﻿using System;
using System.Linq.Expressions;

namespace P2P2.Commons
{
    public static class ExpressionsExtensions
    {
        public static string GetPath(this LambdaExpression e)
        {
            return GetPath(e, false);
        }

        public static string GetPath(this LambdaExpression e, bool forAllMembers)
        {
            Expression exp;
            if (!forAllMembers)
            {
                exp = e.Body.RemoveUnary() as MemberExpression;
                if (exp == null)
                {
                    throw new NullReferenceException($"Can not retrieve info about member of {e}");
                }
            }
            else
            {
                exp = e.Body.RemoveUnary();
            }

            var path = exp.ToString();

            if (e.Parameters.Count == 1)
            {
                path = path.Replace(e.Parameters[0].Name + ".", "");
            }

            return path;
        }

        public static Expression RemoveUnary(this Expression body)
        {
            var unary = body as UnaryExpression;
            return unary?.Operand ?? body;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace AOP.Sorter.Sorters
{
    public class EnumerableSorter : ISorter
    {
        public IEnumerable<Type> SortingTypes
        {
            get
            {
                return new List<Type> {
                    typeof(IEnumerable),

                };
            }
        }

        public Dictionary<string,string> ConvertTypes
        {
            get
            {
                return new Dictionary<string, string>
                {
                    {"List`1","ToList" },
                    {"Array","ToArray" },
                    {"Enumerable`1","AsEnumerable" },
                    {"Dictionary`1","ToDictionary" }
                };
            }
        }

        public void Sort(ref object value)
        {

            var argument =  value.GetType().GetGenericArguments().FirstOrDefault() ?? value.GetType().GetElementType();

            string valueType = value.GetType().IsArray ? "Array" : value.GetType().Name;

            ParameterExpression pe = Expression.Parameter(argument, "x");

            var queryableData = ((IEnumerable)value).AsQueryable();

            MethodCallExpression orderByCallExpression = Expression.Call(
                                typeof(Queryable),
                                "OrderBy",
                                new Type[] { queryableData.ElementType, queryableData.ElementType },
                                queryableData.Expression,
                                Expression.Quote(Expression.Lambda(pe, pe))
                                );


            value = queryableData.Provider.CreateQuery(orderByCallExpression);

            var ofType = typeof(Enumerable).GetMethod(ConvertTypes[valueType], BindingFlags.Static | BindingFlags.Public);

            var methodInfo = ofType.MakeGenericMethod(argument);

            value = methodInfo.Invoke(null, new[] { value });
        }
    }
}

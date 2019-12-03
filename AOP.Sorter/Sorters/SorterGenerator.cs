using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AOP.Sorter.Sorters
{
    public class SorterGenerator
    {
        private static IEnumerable<ISorter> Sorters;

        public static ISorter GetSorter(object sortedObj)
        {
            if (Sorters == null)
                SetAllSorters();

            return Sorters.Where(x => x.SortingTypes.Any(y => y.IsAssignableFrom(sortedObj.GetType()))).FirstOrDefault();
        }

        public static void SetAllSorters()
        {
            Sorters = Assembly.GetExecutingAssembly()
                                  .GetTypes()
                                  .Where(type => typeof(ISorter).IsAssignableFrom(type) && !type.GetType().IsAbstract && !type.IsInterface)
                                  .OrderByDescending(x=>x.Name)
                                  .Select(type => (ISorter)Activator.CreateInstance(type));
        }


    }
}

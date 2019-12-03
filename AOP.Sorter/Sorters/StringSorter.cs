using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOP.Sorter.Sorters
{
    public class StringSorter : ISorter
    {
        public IEnumerable<Type> SortingTypes
        {
            get
            {
                return new List<Type> { typeof(string) };
            }
        }

        public void Sort(ref object value )
        {
            value = new string(value.ToString().ToList().OrderBy(x => x).ToArray());
        }
    }
}

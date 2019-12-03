using System;
using System.Collections.Generic;
using System.Text;

namespace AOP.Sorter.Sorters
{
    public interface ISorter
    {

        IEnumerable<Type> SortingTypes { get;  }

        void Sort(ref object value);
    }
}

using AOP.Sorter.Sorters;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOP.Homework.Aspects
{
    [PSerializable]
    public class OnValueSorterAspect : OnMethodBoundaryAspect
    {
        public override void OnExit(MethodExecutionArgs args)
        {
            base.OnExit(args);

            var value = args.ReturnValue;

            var sorter = SorterGenerator.GetSorter(value);

            if (sorter != null)
                sorter.Sort(ref value);

            args.ReturnValue = value;

        }
    }
}

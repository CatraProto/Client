using System;
using System.Text;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects.Types
{
    internal class DoubleType : TypeBase
    {
        public DoubleType()
        {
            Name = "double";
            IsBare = true;
        }

        public override void WriteBaseParameters(StringBuilder stringBuilder, bool isAbstract = false)
        {
            throw new NotSupportedException("Double doesn't need a base type");
        }
    }
}
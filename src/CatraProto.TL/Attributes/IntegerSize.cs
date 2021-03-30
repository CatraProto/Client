using System;

namespace CatraProto.TL.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IntegerSize : Attribute
    {
        public int BitSize { get; }
        public IntegerSize(int bitSize)
        {
            BitSize = bitSize;
        }
    }
}
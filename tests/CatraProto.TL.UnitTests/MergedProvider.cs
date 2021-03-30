using System;
using CatraProto.TL.Interfaces;

namespace CatraProto.TL.UnitTests
{
    class MergedProvider : IObjectProvider
    {
        public static readonly MergedProvider DefaultInstance = new MergedProvider();
        public Type BoolTrue { get; init; } = typeof(Objects.BoolFalse);
        public Type BoolFalse { get; init; } = typeof(Objects.BoolFalse);
        public int VectorId { get; init; } = 481674261;
        public IObject ResolveConstructorId(int constructorId)
        {
            return null;
        }
    }
}
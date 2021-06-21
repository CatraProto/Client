using System;
using CatraProto.TL.Interfaces;
using CatraProto.TL.UnitTests.Objects;

namespace CatraProto.TL.UnitTests
{
    class MergedProvider : IObjectProvider
    {
        public Type BoolTrue { get; init; } = typeof(BoolFalse);
        public Type BoolFalse { get; init; } = typeof(BoolFalse);
        public int VectorId { get; init; } = 481674261;
        public static readonly MergedProvider DefaultInstance = new MergedProvider();

        public IObject ResolveConstructorId(int constructorId)
        {
            return null;
        }
    }
}
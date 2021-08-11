using CatraProto.TL.Interfaces;
using CatraProto.TL.UnitTests.Objects;

namespace CatraProto.TL.UnitTests
{
    class MergedProvider : ObjectProvider
    {
        public static readonly MergedProvider DefaultInstance = new MergedProvider();
        public override int BoolTrueId { get; init; } = BoolTrue.ConstructorId;
        public override int BoolFalseId { get; init; } = BoolFalse.ConstructorId;
        public override int VectorId { get; init; } = 481674261;

        public override IObject ResolveConstructorId(int constructorId)
        {
            return null;
        }
    }
}
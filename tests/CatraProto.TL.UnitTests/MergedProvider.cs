using System;
using CatraProto.TL.Interfaces;
using CatraProto.TL.UnitTests.Objects;

namespace CatraProto.TL.UnitTests
{
	class MergedProvider : ObjectProvider
	{
		public static readonly MergedProvider DefaultInstance = new MergedProvider();
		public override Type BoolTrue { get; init; } = typeof(BoolFalse);
		public override Type BoolFalse { get; init; } = typeof(BoolFalse);
		public override int VectorId { get; init; } = 481674261;

		public override IObject ResolveConstructorId(int constructorId)
		{
			return null;
		}
	}
}
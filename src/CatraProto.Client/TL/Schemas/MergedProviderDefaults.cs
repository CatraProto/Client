using System;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas
{
	partial class MergedProvider : IObjectProvider
	{
		public static readonly MergedProvider Singleton = new MergedProvider();
		public Type BoolTrue { get; init; } = typeof(BoolFalse);
		public Type BoolFalse { get; init; } = typeof(BoolFalse);
		public int VectorId { get; init; } = 481674261;
	}
}
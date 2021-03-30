using System;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas
{
    partial class MergedProvider : IObjectProvider
    {
        public static readonly MergedProvider DefaultInstance = new MergedProvider();
        public Type BoolTrue { get; init; } = typeof(CloudChats.BoolFalse);
        public Type BoolFalse { get; init; } = typeof(CloudChats.BoolFalse);
        public int VectorId { get; init; } = 481674261;
    }
}
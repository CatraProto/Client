using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetDhConfig : IMethod
	{
		public static int ConstructorId { get; } = 651135312;
		public int Version { get; set; }
		public int RandomLength { get; set; }

		public Type Type { get; init; } = typeof(DhConfigBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Version);
			writer.Write(RandomLength);
		}

		public void Deserialize(Reader reader)
		{
			Version = reader.Read<int>();
			RandomLength = reader.Read<int>();
		}
	}
}
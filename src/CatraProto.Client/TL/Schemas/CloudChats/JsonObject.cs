using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class JsonObject : JSONValueBase
	{
		public static int ConstructorId { get; } = -1715350371;
		public IList<JSONObjectValueBase> Value { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Value);
		}

		public override void Deserialize(Reader reader)
		{
			Value = reader.ReadVector<JSONObjectValueBase>();
		}
	}
}
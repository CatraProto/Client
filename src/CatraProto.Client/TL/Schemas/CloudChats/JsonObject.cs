using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class JsonObject : JSONValueBase
	{


        public static int ConstructorId { get; } = -1715350371;
		public IList<CatraProto.Client.TL.Schemas.CloudChats.JSONObjectValueBase> Value { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Value);

		}

		public override void Deserialize(Reader reader)
		{
			Value = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.JSONObjectValueBase>();

		}
	}
}
using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetFavedStickers : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.FavedStickersBase>
	{


        public static int ConstructorId { get; } = 567151374;

		public int Hash { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Hash = reader.Read<int>();

		}
	}
}
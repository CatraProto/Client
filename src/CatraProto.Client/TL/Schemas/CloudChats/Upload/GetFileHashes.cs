using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class GetFileHashes : IMethod<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>
	{


        public static int ConstructorId { get; } = -956147407;

		public InputFileLocationBase Location { get; set; }
		public int Offset { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Location);
			writer.Write(Offset);

		}

		public void Deserialize(Reader reader)
		{
			Location = reader.Read<InputFileLocationBase>();
			Offset = reader.Read<int>();

		}
	}
}
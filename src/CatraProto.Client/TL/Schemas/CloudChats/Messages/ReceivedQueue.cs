using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ReceivedQueue : IMethod<long>
	{


        public static int ConstructorId { get; } = 1436924774;

		public int MaxQts { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MaxQts);

		}

		public void Deserialize(Reader reader)
		{
			MaxQts = reader.Read<int>();

		}
	}
}
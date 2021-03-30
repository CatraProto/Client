using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class GetInactiveChannels : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.InactiveChatsBase>
	{


        public static int ConstructorId { get; } = 300429806;


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);

		}

		public void Deserialize(Reader reader)
		{

		}
	}
}
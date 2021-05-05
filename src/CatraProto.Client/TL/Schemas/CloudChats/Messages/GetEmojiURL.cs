using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetEmojiURL : IMethod<EmojiURLBase>
	{


        public static int ConstructorId { get; } = -709817306;

		public Type Type { get; init; } = typeof(GetEmojiURL);
		public bool IsVector { get; init; } = false;
		public string LangCode { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(LangCode);

		}

		public void Deserialize(Reader reader)
		{
			LangCode = reader.Read<string>();

		}
	}
}
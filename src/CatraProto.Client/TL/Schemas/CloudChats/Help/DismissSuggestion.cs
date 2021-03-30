using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class DismissSuggestion : IMethod<bool>
	{


        public static int ConstructorId { get; } = 125807007;

		public string Suggestion { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Suggestion);

		}

		public void Deserialize(Reader reader)
		{
			Suggestion = reader.Read<string>();

		}
	}
}
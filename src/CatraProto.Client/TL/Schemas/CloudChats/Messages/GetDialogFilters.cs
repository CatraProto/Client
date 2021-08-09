using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetDialogFilters : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -241247891; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore] Type IMethod.Type { get; init; } = typeof(DialogFilterBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = true;


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
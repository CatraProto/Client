using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetMultiWallPapers : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 1705865692; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(WallPaperBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = true;

[JsonPropertyName("wallpapers")]
		public IList<InputWallPaperBase> Wallpapers { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Wallpapers);

		}

		public void Deserialize(Reader reader)
		{
			Wallpapers = reader.ReadVector<InputWallPaperBase>();

		}
	}
}
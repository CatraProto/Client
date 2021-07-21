using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetMultiWallPapers : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 1705865692; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = true;

[JsonPropertyName("wallpapers")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase> Wallpapers { get; set; }


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
			Wallpapers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase>();

		}
	}
}
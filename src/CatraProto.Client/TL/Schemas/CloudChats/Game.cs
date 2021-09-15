using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Game : CatraProto.Client.TL.Schemas.CloudChats.GameBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Document = 1 << 0
		}

        public static int StaticConstructorId { get => -1107729093; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public override long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("short_name")]
		public override string ShortName { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public override string Title { get; set; }

[Newtonsoft.Json.JsonProperty("description")]
		public override string Description { get; set; }

[Newtonsoft.Json.JsonProperty("photo")]
		public override CatraProto.Client.TL.Schemas.CloudChats.PhotoBase Photo { get; set; }

[Newtonsoft.Json.JsonProperty("document")]
		public override CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(ShortName);
			writer.Write(Title);
			writer.Write(Description);
			writer.Write(Photo);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Document);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			ShortName = reader.Read<string>();
			Title = reader.Read<string>();
			Description = reader.Read<string>();
			Photo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Document = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
			}


		}
				
		public override string ToString()
		{
		    return "game";
		}
	}
}
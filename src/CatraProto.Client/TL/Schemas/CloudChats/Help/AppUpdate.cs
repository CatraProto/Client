using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class AppUpdate : CatraProto.Client.TL.Schemas.CloudChats.Help.AppUpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			CanNotSkip = 1 << 0,
			Document = 1 << 1,
			Url = 1 << 2,
			Sticker = 1 << 3
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -860107216; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("can_not_skip")]
		public bool CanNotSkip { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public int Id { get; set; }

[Newtonsoft.Json.JsonProperty("version")]
		public string Version { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public string Text { get; set; }

[Newtonsoft.Json.JsonProperty("entities")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

[Newtonsoft.Json.JsonProperty("document")]
		public CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }

[Newtonsoft.Json.JsonProperty("url")]
		public string Url { get; set; }

[Newtonsoft.Json.JsonProperty("sticker")]
		public CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Sticker { get; set; }


        #nullable enable
 public AppUpdate (int id,string version,string text,IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> entities)
{
 Id = id;
Version = version;
Text = text;
Entities = entities;
 
}
#nullable disable
        internal AppUpdate() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = CanNotSkip ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Sticker == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(Version);
			writer.Write(Text);
			writer.Write(Entities);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Document);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Url);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Sticker);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			CanNotSkip = FlagsHelper.IsFlagSet(Flags, 0);
			Id = reader.Read<int>();
			Version = reader.Read<string>();
			Text = reader.Read<string>();
			Entities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Document = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Url = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Sticker = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
			}


		}
		
		public override string ToString()
		{
		    return "help.appUpdate";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
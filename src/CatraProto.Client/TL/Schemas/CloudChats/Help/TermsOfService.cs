using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class TermsOfService : CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Popup = 1 << 0,
			MinAgeConfirm = 1 << 1
		}

        public static int StaticConstructorId { get => 2013922064; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("popup")]
		public override bool Popup { get; set; }

[JsonPropertyName("id")]
		public override CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Id { get; set; }

[JsonPropertyName("text")]
		public override string Text { get; set; }

[JsonPropertyName("entities")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

[JsonPropertyName("min_age_confirm")]
		public override int? MinAgeConfirm { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Popup ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = MinAgeConfirm == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(Text);
			writer.Write(Entities);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(MinAgeConfirm.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Popup = FlagsHelper.IsFlagSet(Flags, 0);
			Id = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
			Text = reader.Read<string>();
			Entities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				MinAgeConfirm = reader.Read<int>();
			}


		}
	}
}
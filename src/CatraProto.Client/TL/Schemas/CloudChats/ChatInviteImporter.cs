using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatInviteImporter : CatraProto.Client.TL.Schemas.CloudChats.ChatInviteImporterBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Requested = 1 << 0,
			About = 1 << 2,
			ApprovedBy = 1 << 1
		}

        public static int StaticConstructorId { get => -1940201511; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("requested")]
		public override bool Requested { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public override long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public override int Date { get; set; }

[Newtonsoft.Json.JsonProperty("about")]
		public override string About { get; set; }

[Newtonsoft.Json.JsonProperty("approved_by")]
		public override long? ApprovedBy { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Requested ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = About == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = ApprovedBy == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(UserId);
			writer.Write(Date);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(About);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(ApprovedBy.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Requested = FlagsHelper.IsFlagSet(Flags, 0);
			UserId = reader.Read<long>();
			Date = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				About = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				ApprovedBy = reader.Read<long>();
			}


		}
				
		public override string ToString()
		{
		    return "chatInviteImporter";
		}
	}
}
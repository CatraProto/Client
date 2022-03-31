using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageFwdHeader : CatraProto.Client.TL.Schemas.CloudChats.MessageFwdHeaderBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Imported = 1 << 7,
			FromId = 1 << 0,
			FromName = 1 << 5,
			ChannelPost = 1 << 2,
			PostAuthor = 1 << 3,
			SavedFromPeer = 1 << 4,
			SavedFromMsgId = 1 << 4,
			PsaType = 1 << 6
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1601666510; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("imported")]
		public sealed override bool Imported { get; set; }

[Newtonsoft.Json.JsonProperty("from_id")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase FromId { get; set; }

[Newtonsoft.Json.JsonProperty("from_name")]
		public sealed override string FromName { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public sealed override int Date { get; set; }

[Newtonsoft.Json.JsonProperty("channel_post")]
		public sealed override int? ChannelPost { get; set; }

[Newtonsoft.Json.JsonProperty("post_author")]
		public sealed override string PostAuthor { get; set; }

[Newtonsoft.Json.JsonProperty("saved_from_peer")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase SavedFromPeer { get; set; }

[Newtonsoft.Json.JsonProperty("saved_from_msg_id")]
		public sealed override int? SavedFromMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("psa_type")]
		public sealed override string PsaType { get; set; }


        #nullable enable
 public MessageFwdHeader (int date)
{
 Date = date;
 
}
#nullable disable
        internal MessageFwdHeader() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Imported ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
			Flags = FromId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = FromName == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
			Flags = ChannelPost == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = PostAuthor == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = SavedFromPeer == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = SavedFromMsgId == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = PsaType == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(FromId);
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				writer.Write(FromName);
			}

			writer.Write(Date);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(ChannelPost.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(PostAuthor);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(SavedFromPeer);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(SavedFromMsgId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				writer.Write(PsaType);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Imported = FlagsHelper.IsFlagSet(Flags, 7);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				FromId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				FromName = reader.Read<string>();
			}

			Date = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				ChannelPost = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				PostAuthor = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				SavedFromPeer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				SavedFromMsgId = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				PsaType = reader.Read<string>();
			}


		}
		
		public override string ToString()
		{
		    return "messageFwdHeader";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
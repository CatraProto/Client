using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DialogFilter : CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Contacts = 1 << 0,
			NonContacts = 1 << 1,
			Groups = 1 << 2,
			Broadcasts = 1 << 3,
			Bots = 1 << 4,
			ExcludeMuted = 1 << 11,
			ExcludeRead = 1 << 12,
			ExcludeArchived = 1 << 13,
			Emoticon = 1 << 25
		}

        public static int StaticConstructorId { get => 1949890536; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("contacts")]
		public sealed override bool Contacts { get; set; }

[Newtonsoft.Json.JsonProperty("non_contacts")]
		public sealed override bool NonContacts { get; set; }

[Newtonsoft.Json.JsonProperty("groups")]
		public sealed override bool Groups { get; set; }

[Newtonsoft.Json.JsonProperty("broadcasts")]
		public sealed override bool Broadcasts { get; set; }

[Newtonsoft.Json.JsonProperty("bots")]
		public sealed override bool Bots { get; set; }

[Newtonsoft.Json.JsonProperty("exclude_muted")]
		public sealed override bool ExcludeMuted { get; set; }

[Newtonsoft.Json.JsonProperty("exclude_read")]
		public sealed override bool ExcludeRead { get; set; }

[Newtonsoft.Json.JsonProperty("exclude_archived")]
		public sealed override bool ExcludeArchived { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public sealed override int Id { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public sealed override string Title { get; set; }

[Newtonsoft.Json.JsonProperty("emoticon")]
		public sealed override string Emoticon { get; set; }

[Newtonsoft.Json.JsonProperty("pinned_peers")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> PinnedPeers { get; set; }

[Newtonsoft.Json.JsonProperty("include_peers")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> IncludePeers { get; set; }

[Newtonsoft.Json.JsonProperty("exclude_peers")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> ExcludePeers { get; set; }


        #nullable enable
 public DialogFilter (int id,string title,IList<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> pinnedPeers,IList<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> includePeers,IList<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> excludePeers)
{
 Id = id;
Title = title;
PinnedPeers = pinnedPeers;
IncludePeers = includePeers;
ExcludePeers = excludePeers;
 
}
#nullable disable
        internal DialogFilter() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Contacts ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = NonContacts ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Groups ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = Broadcasts ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = Bots ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = ExcludeMuted ? FlagsHelper.SetFlag(Flags, 11) : FlagsHelper.UnsetFlag(Flags, 11);
			Flags = ExcludeRead ? FlagsHelper.SetFlag(Flags, 12) : FlagsHelper.UnsetFlag(Flags, 12);
			Flags = ExcludeArchived ? FlagsHelper.SetFlag(Flags, 13) : FlagsHelper.UnsetFlag(Flags, 13);
			Flags = Emoticon == null ? FlagsHelper.UnsetFlag(Flags, 25) : FlagsHelper.SetFlag(Flags, 25);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(Title);
			if(FlagsHelper.IsFlagSet(Flags, 25))
			{
				writer.Write(Emoticon);
			}

			writer.Write(PinnedPeers);
			writer.Write(IncludePeers);
			writer.Write(ExcludePeers);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Contacts = FlagsHelper.IsFlagSet(Flags, 0);
			NonContacts = FlagsHelper.IsFlagSet(Flags, 1);
			Groups = FlagsHelper.IsFlagSet(Flags, 2);
			Broadcasts = FlagsHelper.IsFlagSet(Flags, 3);
			Bots = FlagsHelper.IsFlagSet(Flags, 4);
			ExcludeMuted = FlagsHelper.IsFlagSet(Flags, 11);
			ExcludeRead = FlagsHelper.IsFlagSet(Flags, 12);
			ExcludeArchived = FlagsHelper.IsFlagSet(Flags, 13);
			Id = reader.Read<int>();
			Title = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 25))
			{
				Emoticon = reader.Read<string>();
			}

			PinnedPeers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			IncludePeers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			ExcludePeers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();

		}
				
		public override string ToString()
		{
		    return "dialogFilter";
		}
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class MarkDialogUnread : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Unread = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1031349873; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("unread")]
		public bool Unread { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase Peer { get; set; }

        
        #nullable enable
 public MarkDialogUnread (CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase peer)
{
 Peer = peer;
 
}
#nullable disable
                
        internal MarkDialogUnread() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Unread ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Unread = FlagsHelper.IsFlagSet(Flags, 0);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase>();

		}

		public override string ToString()
		{
		    return "messages.markDialogUnread";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
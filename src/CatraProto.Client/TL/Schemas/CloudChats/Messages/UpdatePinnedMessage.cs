using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class UpdatePinnedMessage : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Silent = 1 << 0,
			Unpin = 1 << 1,
			PmOneside = 1 << 2
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -760547348; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("silent")]
		public bool Silent { get; set; }

[Newtonsoft.Json.JsonProperty("unpin")]
		public bool Unpin { get; set; }

[Newtonsoft.Json.JsonProperty("pm_oneside")]
		public bool PmOneside { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public int Id { get; set; }

        
        #nullable enable
 public UpdatePinnedMessage (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,int id)
{
 Peer = peer;
Id = id;
 
}
#nullable disable
                
        internal UpdatePinnedMessage() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Silent ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Unpin ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = PmOneside ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(Id);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Silent = FlagsHelper.IsFlagSet(Flags, 0);
			Unpin = FlagsHelper.IsFlagSet(Flags, 1);
			PmOneside = FlagsHelper.IsFlagSet(Flags, 2);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			Id = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "messages.updatePinnedMessage";
		}
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class InstallStickerSet : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -946871200; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetInstallResultBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("stickerset")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase Stickerset { get; set; }

[Newtonsoft.Json.JsonProperty("archived")]
		public bool Archived { get; set; }

        
        #nullable enable
 public InstallStickerSet (CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset,bool archived)
{
 Stickerset = stickerset;
Archived = archived;
 
}
#nullable disable
                
        internal InstallStickerSet() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Stickerset);
			writer.Write(Archived);

		}

		public void Deserialize(Reader reader)
		{
			Stickerset = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
			Archived = reader.Read<bool>();

		}

		public override string ToString()
		{
		    return "messages.installStickerSet";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
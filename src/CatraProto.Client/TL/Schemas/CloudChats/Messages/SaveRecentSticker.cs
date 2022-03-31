using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SaveRecentSticker : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Attached = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 958863608; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("attached")]
		public bool Attached { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Id { get; set; }

[Newtonsoft.Json.JsonProperty("unsave")]
		public bool Unsave { get; set; }

        
        #nullable enable
 public SaveRecentSticker (CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase id,bool unsave)
{
 Id = id;
Unsave = unsave;
 
}
#nullable disable
                
        internal SaveRecentSticker() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Attached ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(Unsave);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Attached = FlagsHelper.IsFlagSet(Flags, 0);
			Id = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
			Unsave = reader.Read<bool>();

		}

		public override string ToString()
		{
		    return "messages.saveRecentSticker";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
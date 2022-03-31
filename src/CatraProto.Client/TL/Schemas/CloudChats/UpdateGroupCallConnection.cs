using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateGroupCallConnection : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Presentation = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 192428418; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("presentation")]
		public bool Presentation { get; set; }

[Newtonsoft.Json.JsonProperty("params")]
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Params { get; set; }


        #nullable enable
 public UpdateGroupCallConnection (CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase pparams)
{
 Params = pparams;
 
}
#nullable disable
        internal UpdateGroupCallConnection() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Presentation ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Params);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Presentation = FlagsHelper.IsFlagSet(Flags, 0);
			Params = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();

		}
		
		public override string ToString()
		{
		    return "updateGroupCallConnection";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
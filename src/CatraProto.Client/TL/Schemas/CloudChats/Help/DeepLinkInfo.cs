using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class DeepLinkInfo : CatraProto.Client.TL.Schemas.CloudChats.Help.DeepLinkInfoBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			UpdateApp = 1 << 0,
			Entities = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1783556146; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("update_app")]
		public bool UpdateApp { get; set; }

[Newtonsoft.Json.JsonProperty("message")]
		public string Message { get; set; }

[Newtonsoft.Json.JsonProperty("entities")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }


        #nullable enable
 public DeepLinkInfo (string message)
{
 Message = message;
 
}
#nullable disable
        internal DeepLinkInfo() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = UpdateApp ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Message);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Entities);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			UpdateApp = FlagsHelper.IsFlagSet(Flags, 0);
			Message = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Entities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
			}


		}
		
		public override string ToString()
		{
		    return "help.deepLinkInfo";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
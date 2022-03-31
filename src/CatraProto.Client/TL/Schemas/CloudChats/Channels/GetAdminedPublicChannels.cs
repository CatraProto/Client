using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class GetAdminedPublicChannels : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			ByLocation = 1 << 0,
			CheckLimit = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -122669393; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("by_location")]
		public bool ByLocation { get; set; }

[Newtonsoft.Json.JsonProperty("check_limit")]
		public bool CheckLimit { get; set; }

        
        
                
        public GetAdminedPublicChannels() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = ByLocation ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = CheckLimit ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ByLocation = FlagsHelper.IsFlagSet(Flags, 0);
			CheckLimit = FlagsHelper.IsFlagSet(Flags, 1);

		}

		public override string ToString()
		{
		    return "channels.getAdminedPublicChannels";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
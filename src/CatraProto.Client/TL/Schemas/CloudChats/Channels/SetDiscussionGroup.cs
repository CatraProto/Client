using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class SetDiscussionGroup : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1079520178; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("broadcast")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Broadcast { get; set; }

[Newtonsoft.Json.JsonProperty("group")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Group { get; set; }

        
        #nullable enable
 public SetDiscussionGroup (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase broadcast,CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase group)
{
 Broadcast = broadcast;
Group = group;
 
}
#nullable disable
                
        internal SetDiscussionGroup() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Broadcast);
			writer.Write(Group);

		}

		public void Deserialize(Reader reader)
		{
			Broadcast = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
			Group = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();

		}

		public override string ToString()
		{
		    return "channels.setDiscussionGroup";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
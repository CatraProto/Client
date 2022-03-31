using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class SetBotUpdatesStatus : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -333262899; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("pending_updates_count")]
		public int PendingUpdatesCount { get; set; }

[Newtonsoft.Json.JsonProperty("message")]
		public string Message { get; set; }

        
        #nullable enable
 public SetBotUpdatesStatus (int pendingUpdatesCount,string message)
{
 PendingUpdatesCount = pendingUpdatesCount;
Message = message;
 
}
#nullable disable
                
        internal SetBotUpdatesStatus() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(PendingUpdatesCount);
			writer.Write(Message);

		}

		public void Deserialize(Reader reader)
		{
			PendingUpdatesCount = reader.Read<int>();
			Message = reader.Read<string>();

		}

		public override string ToString()
		{
		    return "help.setBotUpdatesStatus";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
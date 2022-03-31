using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetDefaultReaction : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -647969580; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("reaction")]
		public string Reaction { get; set; }

        
        #nullable enable
 public SetDefaultReaction (string reaction)
{
 Reaction = reaction;
 
}
#nullable disable
                
        internal SetDefaultReaction() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Reaction);

		}

		public void Deserialize(Reader reader)
		{
			Reaction = reader.Read<string>();

		}

		public override string ToString()
		{
		    return "messages.setDefaultReaction";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
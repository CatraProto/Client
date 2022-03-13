using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class CreateChat : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 164303470; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("users")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> Users { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }

        
        #nullable enable
 public CreateChat (IList<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> users,string title)
{
 Users = users;
Title = title;
 
}
#nullable disable
                
        internal CreateChat() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Users);
			writer.Write(Title);

		}

		public void Deserialize(Reader reader)
		{
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			Title = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "messages.createChat";
		}
	}
}
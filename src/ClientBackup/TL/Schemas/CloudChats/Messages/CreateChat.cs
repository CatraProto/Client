using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class CreateChat : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 164303470; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

[Newtonsoft.Json.JsonProperty("users")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> Users { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }

        
        #nullable enable
 public CreateChat (List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> users,string title)
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

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkusers = 			writer.WriteVector(Users, false);
if(checkusers.IsError){
 return checkusers; 
}

			writer.WriteString(Title);

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryusers.IsError){
return ReadResult<IObject>.Move(tryusers);
}
Users = tryusers.Value;
			var trytitle = reader.ReadString();
if(trytitle.IsError){
return ReadResult<IObject>.Move(trytitle);
}
Title = trytitle.Value;
return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "messages.createChat";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
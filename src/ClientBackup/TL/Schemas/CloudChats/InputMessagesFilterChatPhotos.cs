using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMessagesFilterChatPhotos : CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 975236280; }
        

        
        public InputMessagesFilterChatPhotos() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "inputMessagesFilterChatPhotos";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
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
	public partial class InputSingleMedia : CatraProto.Client.TL.Schemas.CloudChats.InputSingleMediaBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Entities = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 482797855; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("media")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase Media { get; set; }

[Newtonsoft.Json.JsonProperty("random_id")]
		public sealed override long RandomId { get; set; }

[Newtonsoft.Json.JsonProperty("message")]
		public sealed override string Message { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("entities")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }


        #nullable enable
 public InputSingleMedia (CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase media,long randomId,string message)
{
 Media = media;
RandomId = randomId;
Message = message;
 
}
#nullable disable
        internal InputSingleMedia() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
var checkmedia = 			writer.WriteObject(Media);
if(checkmedia.IsError){
 return checkmedia; 
}
writer.WriteInt64(RandomId);

			writer.WriteString(Message);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
var checkentities = 				writer.WriteVector(Entities, false);
if(checkentities.IsError){
 return checkentities; 
}
			}


return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryflags = reader.ReadInt32();
if(tryflags.IsError){
return ReadResult<IObject>.Move(tryflags);
}
Flags = tryflags.Value;
			var trymedia = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase>();
if(trymedia.IsError){
return ReadResult<IObject>.Move(trymedia);
}
Media = trymedia.Value;
			var tryrandomId = reader.ReadInt64();
if(tryrandomId.IsError){
return ReadResult<IObject>.Move(tryrandomId);
}
RandomId = tryrandomId.Value;
			var trymessage = reader.ReadString();
if(trymessage.IsError){
return ReadResult<IObject>.Move(trymessage);
}
Message = trymessage.Value;
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				var tryentities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryentities.IsError){
return ReadResult<IObject>.Move(tryentities);
}
Entities = tryentities.Value;
			}

return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "inputSingleMedia";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
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
	public partial class MessageMediaPhoto : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Photo = 1 << 0,
			TtlSeconds = 1 << 2
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1766936791; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("photo")]
		public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase Photo { get; set; }

[Newtonsoft.Json.JsonProperty("ttl_seconds")]
		public int? TtlSeconds { get; set; }


        
        public MessageMediaPhoto() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Photo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = TtlSeconds == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
var checkphoto = 				writer.WriteObject(Photo);
if(checkphoto.IsError){
 return checkphoto; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
writer.WriteInt32(TtlSeconds.Value);
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
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				var tryphoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
if(tryphoto.IsError){
return ReadResult<IObject>.Move(tryphoto);
}
Photo = tryphoto.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				var tryttlSeconds = reader.ReadInt32();
if(tryttlSeconds.IsError){
return ReadResult<IObject>.Move(tryttlSeconds);
}
TtlSeconds = tryttlSeconds.Value;
			}

return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "messageMediaPhoto";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
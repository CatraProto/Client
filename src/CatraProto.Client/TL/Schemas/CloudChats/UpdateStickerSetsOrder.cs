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
	public partial class UpdateStickerSetsOrder : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Masks = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 196268545; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("masks")]
		public bool Masks { get; set; }

[Newtonsoft.Json.JsonProperty("order")]
		public List<long> Order { get; set; }


        #nullable enable
 public UpdateStickerSetsOrder (List<long> order)
{
 Order = order;
 
}
#nullable disable
        internal UpdateStickerSetsOrder() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Masks ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);

			writer.WriteVector(Order, false);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryflags = reader.ReadInt32();
if(tryflags.IsError){
return ReadResult<IObject>.Move(tryflags);
}
Flags = tryflags.Value;
			Masks = FlagsHelper.IsFlagSet(Flags, 0);
			var tryorder = reader.ReadVector<long>(ParserTypes.Int64);
if(tryorder.IsError){
return ReadResult<IObject>.Move(tryorder);
}
Order = tryorder.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "updateStickerSetsOrder";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
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
	public partial class InputSecureValue : CatraProto.Client.TL.Schemas.CloudChats.InputSecureValueBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Data = 1 << 0,
			FrontSide = 1 << 1,
			ReverseSide = 1 << 2,
			Selfie = 1 << 3,
			Translation = 1 << 6,
			Files = 1 << 4,
			PlainData = 1 << 5
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -618540889; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("type")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("data")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureDataBase Data { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("front_side")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase FrontSide { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("reverse_side")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase ReverseSide { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("selfie")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase Selfie { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("translation")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase> Translation { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("files")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase> Files { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("plain_data")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecurePlainDataBase PlainData { get; set; }


        #nullable enable
 public InputSecureValue (CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase type)
{
 Type = type;
 
}
#nullable disable
        internal InputSecureValue() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Data == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = FrontSide == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = ReverseSide == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Selfie == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = Translation == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
			Flags = Files == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = PlainData == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
var checktype = 			writer.WriteObject(Type);
if(checktype.IsError){
 return checktype; 
}
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
var checkdata = 				writer.WriteObject(Data);
if(checkdata.IsError){
 return checkdata; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
var checkfrontSide = 				writer.WriteObject(FrontSide);
if(checkfrontSide.IsError){
 return checkfrontSide; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
var checkreverseSide = 				writer.WriteObject(ReverseSide);
if(checkreverseSide.IsError){
 return checkreverseSide; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
var checkselfie = 				writer.WriteObject(Selfie);
if(checkselfie.IsError){
 return checkselfie; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
var checktranslation = 				writer.WriteVector(Translation, false);
if(checktranslation.IsError){
 return checktranslation; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
var checkfiles = 				writer.WriteVector(Files, false);
if(checkfiles.IsError){
 return checkfiles; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
var checkplainData = 				writer.WriteObject(PlainData);
if(checkplainData.IsError){
 return checkplainData; 
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
			var trytype = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>();
if(trytype.IsError){
return ReadResult<IObject>.Move(trytype);
}
Type = trytype.Value;
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				var trydata = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecureDataBase>();
if(trydata.IsError){
return ReadResult<IObject>.Move(trydata);
}
Data = trydata.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				var tryfrontSide = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase>();
if(tryfrontSide.IsError){
return ReadResult<IObject>.Move(tryfrontSide);
}
FrontSide = tryfrontSide.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				var tryreverseSide = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase>();
if(tryreverseSide.IsError){
return ReadResult<IObject>.Move(tryreverseSide);
}
ReverseSide = tryreverseSide.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				var tryselfie = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase>();
if(tryselfie.IsError){
return ReadResult<IObject>.Move(tryselfie);
}
Selfie = tryselfie.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				var trytranslation = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(trytranslation.IsError){
return ReadResult<IObject>.Move(trytranslation);
}
Translation = trytranslation.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				var tryfiles = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryfiles.IsError){
return ReadResult<IObject>.Move(tryfiles);
}
Files = tryfiles.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				var tryplainData = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecurePlainDataBase>();
if(tryplainData.IsError){
return ReadResult<IObject>.Move(tryplainData);
}
PlainData = tryplainData.Value;
			}

return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "inputSecureValue";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
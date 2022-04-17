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
	public partial class BotInlineResult : CatraProto.Client.TL.Schemas.CloudChats.BotInlineResultBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Title = 1 << 1,
			Description = 1 << 2,
			Url = 1 << 3,
			Thumb = 1 << 4,
			Content = 1 << 5
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 295067450; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public sealed override string Id { get; set; }

[Newtonsoft.Json.JsonProperty("type")]
		public sealed override string Type { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("description")]
		public string Description { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("url")]
		public string Url { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("thumb")]
		public CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase Thumb { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("content")]
		public CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase Content { get; set; }

[Newtonsoft.Json.JsonProperty("send_message")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase SendMessage { get; set; }


        #nullable enable
 public BotInlineResult (string id,string type,CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase sendMessage)
{
 Id = id;
Type = type;
SendMessage = sendMessage;
 
}
#nullable disable
        internal BotInlineResult() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Description == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = Thumb == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = Content == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);

			writer.WriteString(Id);

			writer.WriteString(Type);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{

				writer.WriteString(Title);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{

				writer.WriteString(Description);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{

				writer.WriteString(Url);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
var checkthumb = 				writer.WriteObject(Thumb);
if(checkthumb.IsError){
 return checkthumb; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
var checkcontent = 				writer.WriteObject(Content);
if(checkcontent.IsError){
 return checkcontent; 
}
			}

var checksendMessage = 			writer.WriteObject(SendMessage);
if(checksendMessage.IsError){
 return checksendMessage; 
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
			var tryid = reader.ReadString();
if(tryid.IsError){
return ReadResult<IObject>.Move(tryid);
}
Id = tryid.Value;
			var trytype = reader.ReadString();
if(trytype.IsError){
return ReadResult<IObject>.Move(trytype);
}
Type = trytype.Value;
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				var trytitle = reader.ReadString();
if(trytitle.IsError){
return ReadResult<IObject>.Move(trytitle);
}
Title = trytitle.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				var trydescription = reader.ReadString();
if(trydescription.IsError){
return ReadResult<IObject>.Move(trydescription);
}
Description = trydescription.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				var tryurl = reader.ReadString();
if(tryurl.IsError){
return ReadResult<IObject>.Move(tryurl);
}
Url = tryurl.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				var trythumb = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase>();
if(trythumb.IsError){
return ReadResult<IObject>.Move(trythumb);
}
Thumb = trythumb.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				var trycontent = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase>();
if(trycontent.IsError){
return ReadResult<IObject>.Move(trycontent);
}
Content = trycontent.Value;
			}

			var trysendMessage = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase>();
if(trysendMessage.IsError){
return ReadResult<IObject>.Move(trysendMessage);
}
SendMessage = trysendMessage.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "botInlineResult";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
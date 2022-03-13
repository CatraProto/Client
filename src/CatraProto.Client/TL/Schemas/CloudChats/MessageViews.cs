using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageViews : CatraProto.Client.TL.Schemas.CloudChats.MessageViewsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Views = 1 << 0,
			Forwards = 1 << 1,
			Replies = 1 << 2
		}

        public static int StaticConstructorId { get => 1163625789; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("views")]
		public sealed override int? Views { get; set; }

[Newtonsoft.Json.JsonProperty("forwards")]
		public sealed override int? Forwards { get; set; }

[Newtonsoft.Json.JsonProperty("replies")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.MessageRepliesBase Replies { get; set; }


        
        public MessageViews() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Views == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Forwards == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Replies == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Views.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Forwards.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Replies);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Views = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Forwards = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Replies = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageRepliesBase>();
			}


		}
				
		public override string ToString()
		{
		    return "messageViews";
		}
	}
}
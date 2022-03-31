using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class AvailableReaction : CatraProto.Client.TL.Schemas.CloudChats.AvailableReactionBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Inactive = 1 << 0,
			AroundAnimation = 1 << 1,
			CenterIcon = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1065882623; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("inactive")]
		public sealed override bool Inactive { get; set; }

[Newtonsoft.Json.JsonProperty("reaction")]
		public sealed override string Reaction { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public sealed override string Title { get; set; }

[Newtonsoft.Json.JsonProperty("static_icon")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.DocumentBase StaticIcon { get; set; }

[Newtonsoft.Json.JsonProperty("appear_animation")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.DocumentBase AppearAnimation { get; set; }

[Newtonsoft.Json.JsonProperty("select_animation")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.DocumentBase SelectAnimation { get; set; }

[Newtonsoft.Json.JsonProperty("activate_animation")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.DocumentBase ActivateAnimation { get; set; }

[Newtonsoft.Json.JsonProperty("effect_animation")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.DocumentBase EffectAnimation { get; set; }

[Newtonsoft.Json.JsonProperty("around_animation")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.DocumentBase AroundAnimation { get; set; }

[Newtonsoft.Json.JsonProperty("center_icon")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.DocumentBase CenterIcon { get; set; }


        #nullable enable
 public AvailableReaction (string reaction,string title,CatraProto.Client.TL.Schemas.CloudChats.DocumentBase staticIcon,CatraProto.Client.TL.Schemas.CloudChats.DocumentBase appearAnimation,CatraProto.Client.TL.Schemas.CloudChats.DocumentBase selectAnimation,CatraProto.Client.TL.Schemas.CloudChats.DocumentBase activateAnimation,CatraProto.Client.TL.Schemas.CloudChats.DocumentBase effectAnimation)
{
 Reaction = reaction;
Title = title;
StaticIcon = staticIcon;
AppearAnimation = appearAnimation;
SelectAnimation = selectAnimation;
ActivateAnimation = activateAnimation;
EffectAnimation = effectAnimation;
 
}
#nullable disable
        internal AvailableReaction() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Inactive ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = AroundAnimation == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = CenterIcon == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Reaction);
			writer.Write(Title);
			writer.Write(StaticIcon);
			writer.Write(AppearAnimation);
			writer.Write(SelectAnimation);
			writer.Write(ActivateAnimation);
			writer.Write(EffectAnimation);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(AroundAnimation);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(CenterIcon);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Inactive = FlagsHelper.IsFlagSet(Flags, 0);
			Reaction = reader.Read<string>();
			Title = reader.Read<string>();
			StaticIcon = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
			AppearAnimation = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
			SelectAnimation = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
			ActivateAnimation = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
			EffectAnimation = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				AroundAnimation = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				CenterIcon = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
			}


		}
		
		public override string ToString()
		{
		    return "availableReaction";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
using System;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

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

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("around_animation")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.DocumentBase AroundAnimation { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("center_icon")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.DocumentBase CenterIcon { get; set; }


#nullable enable
        public AvailableReaction(string reaction, string title, CatraProto.Client.TL.Schemas.CloudChats.DocumentBase staticIcon, CatraProto.Client.TL.Schemas.CloudChats.DocumentBase appearAnimation, CatraProto.Client.TL.Schemas.CloudChats.DocumentBase selectAnimation, CatraProto.Client.TL.Schemas.CloudChats.DocumentBase activateAnimation, CatraProto.Client.TL.Schemas.CloudChats.DocumentBase effectAnimation)
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

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Reaction);

            writer.WriteString(Title);
            var checkstaticIcon = writer.WriteObject(StaticIcon);
            if (checkstaticIcon.IsError)
            {
                return checkstaticIcon;
            }
            var checkappearAnimation = writer.WriteObject(AppearAnimation);
            if (checkappearAnimation.IsError)
            {
                return checkappearAnimation;
            }
            var checkselectAnimation = writer.WriteObject(SelectAnimation);
            if (checkselectAnimation.IsError)
            {
                return checkselectAnimation;
            }
            var checkactivateAnimation = writer.WriteObject(ActivateAnimation);
            if (checkactivateAnimation.IsError)
            {
                return checkactivateAnimation;
            }
            var checkeffectAnimation = writer.WriteObject(EffectAnimation);
            if (checkeffectAnimation.IsError)
            {
                return checkeffectAnimation;
            }
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checkaroundAnimation = writer.WriteObject(AroundAnimation);
                if (checkaroundAnimation.IsError)
                {
                    return checkaroundAnimation;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checkcenterIcon = writer.WriteObject(CenterIcon);
                if (checkcenterIcon.IsError)
                {
                    return checkcenterIcon;
                }
            }


            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            Inactive = FlagsHelper.IsFlagSet(Flags, 0);
            var tryreaction = reader.ReadString();
            if (tryreaction.IsError)
            {
                return ReadResult<IObject>.Move(tryreaction);
            }
            Reaction = tryreaction.Value;
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }
            Title = trytitle.Value;
            var trystaticIcon = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
            if (trystaticIcon.IsError)
            {
                return ReadResult<IObject>.Move(trystaticIcon);
            }
            StaticIcon = trystaticIcon.Value;
            var tryappearAnimation = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
            if (tryappearAnimation.IsError)
            {
                return ReadResult<IObject>.Move(tryappearAnimation);
            }
            AppearAnimation = tryappearAnimation.Value;
            var tryselectAnimation = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
            if (tryselectAnimation.IsError)
            {
                return ReadResult<IObject>.Move(tryselectAnimation);
            }
            SelectAnimation = tryselectAnimation.Value;
            var tryactivateAnimation = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
            if (tryactivateAnimation.IsError)
            {
                return ReadResult<IObject>.Move(tryactivateAnimation);
            }
            ActivateAnimation = tryactivateAnimation.Value;
            var tryeffectAnimation = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
            if (tryeffectAnimation.IsError)
            {
                return ReadResult<IObject>.Move(tryeffectAnimation);
            }
            EffectAnimation = tryeffectAnimation.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryaroundAnimation = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
                if (tryaroundAnimation.IsError)
                {
                    return ReadResult<IObject>.Move(tryaroundAnimation);
                }
                AroundAnimation = tryaroundAnimation.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trycenterIcon = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
                if (trycenterIcon.IsError)
                {
                    return ReadResult<IObject>.Move(trycenterIcon);
                }
                CenterIcon = trycenterIcon.Value;
            }

            return new ReadResult<IObject>(this);

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
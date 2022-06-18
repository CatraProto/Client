using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class AttachMenuBot : CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Inactive = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -381896846; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("inactive")]
        public sealed override bool Inactive { get; set; }

        [Newtonsoft.Json.JsonProperty("bot_id")]
        public sealed override long BotId { get; set; }

        [Newtonsoft.Json.JsonProperty("short_name")]
        public sealed override string ShortName { get; set; }

        [Newtonsoft.Json.JsonProperty("icons")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconBase> Icons { get; set; }


#nullable enable
        public AttachMenuBot(long botId, string shortName, List<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconBase> icons)
        {
            BotId = botId;
            ShortName = shortName;
            Icons = icons;

        }
#nullable disable
        internal AttachMenuBot()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Inactive ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(BotId);

            writer.WriteString(ShortName);
            var checkicons = writer.WriteVector(Icons, false);
            if (checkicons.IsError)
            {
                return checkicons;
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
            var trybotId = reader.ReadInt64();
            if (trybotId.IsError)
            {
                return ReadResult<IObject>.Move(trybotId);
            }
            BotId = trybotId.Value;
            var tryshortName = reader.ReadString();
            if (tryshortName.IsError)
            {
                return ReadResult<IObject>.Move(tryshortName);
            }
            ShortName = tryshortName.Value;
            var tryicons = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryicons.IsError)
            {
                return ReadResult<IObject>.Move(tryicons);
            }
            Icons = tryicons.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "attachMenuBot";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new AttachMenuBot
            {
                Flags = Flags,
                Inactive = Inactive,
                BotId = BotId,
                ShortName = ShortName,
                Icons = new List<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconBase>()
            };
            foreach (var icons in Icons)
            {
                var cloneicons = (CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconBase?)icons.Clone();
                if (cloneicons is null)
                {
                    return null;
                }
                newClonedObject.Icons.Add(cloneicons);
            }
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not AttachMenuBot castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (Inactive != castedOther.Inactive)
            {
                return true;
            }
            if (BotId != castedOther.BotId)
            {
                return true;
            }
            if (ShortName != castedOther.ShortName)
            {
                return true;
            }
            var iconssize = castedOther.Icons.Count;
            if (iconssize != Icons.Count)
            {
                return true;
            }
            for (var i = 0; i < iconssize; i++)
            {
                if (castedOther.Icons[i].Compare(Icons[i]))
                {
                    return true;
                }
            }
            return false;

        }

#nullable disable
    }
}
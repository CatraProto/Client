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
    public partial class AttachMenuBot : CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Inactive = 1 << 0,
            HasSettings = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -928371502; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("inactive")]
        public sealed override bool Inactive { get; set; }

        [Newtonsoft.Json.JsonProperty("has_settings")]
        public sealed override bool HasSettings { get; set; }

        [Newtonsoft.Json.JsonProperty("bot_id")]
        public sealed override long BotId { get; set; }

        [Newtonsoft.Json.JsonProperty("short_name")]
        public sealed override string ShortName { get; set; }

        [Newtonsoft.Json.JsonProperty("peer_types")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuPeerTypeBase> PeerTypes { get; set; }

        [Newtonsoft.Json.JsonProperty("icons")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconBase> Icons { get; set; }


#nullable enable
        public AttachMenuBot(long botId, string shortName, List<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuPeerTypeBase> peerTypes, List<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconBase> icons)
        {
            BotId = botId;
            ShortName = shortName;
            PeerTypes = peerTypes;
            Icons = icons;
        }
#nullable disable
        internal AttachMenuBot()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Inactive ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = HasSettings ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(BotId);

            writer.WriteString(ShortName);
            var checkpeerTypes = writer.WriteVector(PeerTypes, false);
            if (checkpeerTypes.IsError)
            {
                return checkpeerTypes;
            }

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
            HasSettings = FlagsHelper.IsFlagSet(Flags, 1);
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
            var trypeerTypes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuPeerTypeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trypeerTypes.IsError)
            {
                return ReadResult<IObject>.Move(trypeerTypes);
            }

            PeerTypes = trypeerTypes.Value;
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
            var newClonedObject = new AttachMenuBot();
            newClonedObject.Flags = Flags;
            newClonedObject.Inactive = Inactive;
            newClonedObject.HasSettings = HasSettings;
            newClonedObject.BotId = BotId;
            newClonedObject.ShortName = ShortName;
            newClonedObject.PeerTypes = new List<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuPeerTypeBase>();
            foreach (var peerTypes in PeerTypes)
            {
                var clonepeerTypes = (CatraProto.Client.TL.Schemas.CloudChats.AttachMenuPeerTypeBase?)peerTypes.Clone();
                if (clonepeerTypes is null)
                {
                    return null;
                }

                newClonedObject.PeerTypes.Add(clonepeerTypes);
            }

            newClonedObject.Icons = new List<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconBase>();
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

            if (HasSettings != castedOther.HasSettings)
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

            var peerTypessize = castedOther.PeerTypes.Count;
            if (peerTypessize != PeerTypes.Count)
            {
                return true;
            }

            for (var i = 0; i < peerTypessize; i++)
            {
                if (castedOther.PeerTypes[i].Compare(PeerTypes[i]))
                {
                    return true;
                }
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
using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetInlineBotResults : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            GeoPoint = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1364105629; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("bot")] public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Bot { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("geo_point")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase GeoPoint { get; set; }

        [Newtonsoft.Json.JsonProperty("query")]
        public string Query { get; set; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public string Offset { get; set; }


#nullable enable
        public GetInlineBotResults(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string query, string offset)
        {
            Bot = bot;
            Peer = peer;
            Query = query;
            Offset = offset;
        }
#nullable disable

        internal GetInlineBotResults()
        {
        }

        public void UpdateFlags()
        {
            Flags = GeoPoint == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkbot = writer.WriteObject(Bot);
            if (checkbot.IsError)
            {
                return checkbot;
            }

            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkgeoPoint = writer.WriteObject(GeoPoint);
                if (checkgeoPoint.IsError)
                {
                    return checkgeoPoint;
                }
            }


            writer.WriteString(Query);

            writer.WriteString(Offset);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            var trybot = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (trybot.IsError)
            {
                return ReadResult<IObject>.Move(trybot);
            }

            Bot = trybot.Value;
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trygeoPoint = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase>();
                if (trygeoPoint.IsError)
                {
                    return ReadResult<IObject>.Move(trygeoPoint);
                }

                GeoPoint = trygeoPoint.Value;
            }

            var tryquery = reader.ReadString();
            if (tryquery.IsError)
            {
                return ReadResult<IObject>.Move(tryquery);
            }

            Query = tryquery.Value;
            var tryoffset = reader.ReadString();
            if (tryoffset.IsError)
            {
                return ReadResult<IObject>.Move(tryoffset);
            }

            Offset = tryoffset.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.getInlineBotResults";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetInlineBotResults();
            newClonedObject.Flags = Flags;
            var cloneBot = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)Bot.Clone();
            if (cloneBot is null)
            {
                return null;
            }

            newClonedObject.Bot = cloneBot;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            if (GeoPoint is not null)
            {
                var cloneGeoPoint = (CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase?)GeoPoint.Clone();
                if (cloneGeoPoint is null)
                {
                    return null;
                }

                newClonedObject.GeoPoint = cloneGeoPoint;
            }

            newClonedObject.Query = Query;
            newClonedObject.Offset = Offset;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetInlineBotResults castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Bot.Compare(castedOther.Bot))
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (GeoPoint is null && castedOther.GeoPoint is not null || GeoPoint is not null && castedOther.GeoPoint is null)
            {
                return true;
            }

            if (GeoPoint is not null && castedOther.GeoPoint is not null && GeoPoint.Compare(castedOther.GeoPoint))
            {
                return true;
            }

            if (Query != castedOther.Query)
            {
                return true;
            }

            if (Offset != castedOther.Offset)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
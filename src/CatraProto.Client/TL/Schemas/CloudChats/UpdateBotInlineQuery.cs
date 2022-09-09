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
    public partial class UpdateBotInlineQuery : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Geo = 1 << 0,
            PeerType = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1232025500; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("query_id")]
        public long QueryId { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("query")]
        public string Query { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("geo")]
        public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase Geo { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("peer_type")]
        public CatraProto.Client.TL.Schemas.CloudChats.InlineQueryPeerTypeBase PeerType { get; set; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public string Offset { get; set; }


#nullable enable
        public UpdateBotInlineQuery(long queryId, long userId, string query, string offset)
        {
            QueryId = queryId;
            UserId = userId;
            Query = query;
            Offset = offset;
        }
#nullable disable
        internal UpdateBotInlineQuery()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Geo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = PeerType == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(QueryId);
            writer.WriteInt64(UserId);

            writer.WriteString(Query);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkgeo = writer.WriteObject(Geo);
                if (checkgeo.IsError)
                {
                    return checkgeo;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checkpeerType = writer.WriteObject(PeerType);
                if (checkpeerType.IsError)
                {
                    return checkpeerType;
                }
            }


            writer.WriteString(Offset);

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
            var tryqueryId = reader.ReadInt64();
            if (tryqueryId.IsError)
            {
                return ReadResult<IObject>.Move(tryqueryId);
            }

            QueryId = tryqueryId.Value;
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            var tryquery = reader.ReadString();
            if (tryquery.IsError)
            {
                return ReadResult<IObject>.Move(tryquery);
            }

            Query = tryquery.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trygeo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase>();
                if (trygeo.IsError)
                {
                    return ReadResult<IObject>.Move(trygeo);
                }

                Geo = trygeo.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trypeerType = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InlineQueryPeerTypeBase>();
                if (trypeerType.IsError)
                {
                    return ReadResult<IObject>.Move(trypeerType);
                }

                PeerType = trypeerType.Value;
            }

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
            return "updateBotInlineQuery";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateBotInlineQuery();
            newClonedObject.Flags = Flags;
            newClonedObject.QueryId = QueryId;
            newClonedObject.UserId = UserId;
            newClonedObject.Query = Query;
            if (Geo is not null)
            {
                var cloneGeo = (CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase?)Geo.Clone();
                if (cloneGeo is null)
                {
                    return null;
                }

                newClonedObject.Geo = cloneGeo;
            }

            if (PeerType is not null)
            {
                var clonePeerType = (CatraProto.Client.TL.Schemas.CloudChats.InlineQueryPeerTypeBase?)PeerType.Clone();
                if (clonePeerType is null)
                {
                    return null;
                }

                newClonedObject.PeerType = clonePeerType;
            }

            newClonedObject.Offset = Offset;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateBotInlineQuery castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (QueryId != castedOther.QueryId)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            if (Query != castedOther.Query)
            {
                return true;
            }

            if (Geo is null && castedOther.Geo is not null || Geo is not null && castedOther.Geo is null)
            {
                return true;
            }

            if (Geo is not null && castedOther.Geo is not null && Geo.Compare(castedOther.Geo))
            {
                return true;
            }

            if (PeerType is null && castedOther.PeerType is not null || PeerType is not null && castedOther.PeerType is null)
            {
                return true;
            }

            if (PeerType is not null && castedOther.PeerType is not null && PeerType.Compare(castedOther.PeerType))
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
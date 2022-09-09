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
    public partial class UpdateBotInlineSend : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Geo = 1 << 0,
            MsgId = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 317794823; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("query")]
        public string Query { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("geo")]
        public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase Geo { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public string Id { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("msg_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase MsgId { get; set; }


#nullable enable
        public UpdateBotInlineSend(long userId, string query, string id)
        {
            UserId = userId;
            Query = query;
            Id = id;
        }
#nullable disable
        internal UpdateBotInlineSend()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Geo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = MsgId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
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


            writer.WriteString(Id);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checkmsgId = writer.WriteObject(MsgId);
                if (checkmsgId.IsError)
                {
                    return checkmsgId;
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

            var tryid = reader.ReadString();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trymsgId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase>();
                if (trymsgId.IsError)
                {
                    return ReadResult<IObject>.Move(trymsgId);
                }

                MsgId = trymsgId.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateBotInlineSend";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateBotInlineSend();
            newClonedObject.Flags = Flags;
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

            newClonedObject.Id = Id;
            if (MsgId is not null)
            {
                var cloneMsgId = (CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase?)MsgId.Clone();
                if (cloneMsgId is null)
                {
                    return null;
                }

                newClonedObject.MsgId = cloneMsgId;
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateBotInlineSend castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
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

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (MsgId is null && castedOther.MsgId is not null || MsgId is not null && castedOther.MsgId is null)
            {
                return true;
            }

            if (MsgId is not null && castedOther.MsgId is not null && MsgId.Compare(castedOther.MsgId))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
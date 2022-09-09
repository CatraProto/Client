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
    public partial class InputMediaDocument : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
    {
        [Flags]
        public enum FlagsEnum
        {
            TtlSeconds = 1 << 0,
            Query = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 860303448; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Id { get; set; }

        [Newtonsoft.Json.JsonProperty("ttl_seconds")]
        public int? TtlSeconds { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("query")]
        public string Query { get; set; }


#nullable enable
        public InputMediaDocument(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase id)
        {
            Id = id;
        }
#nullable disable
        internal InputMediaDocument()
        {
        }

        public override void UpdateFlags()
        {
            Flags = TtlSeconds == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Query == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkid = writer.WriteObject(Id);
            if (checkid.IsError)
            {
                return checkid;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(TtlSeconds.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(Query);
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
            var tryid = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryttlSeconds = reader.ReadInt32();
                if (tryttlSeconds.IsError)
                {
                    return ReadResult<IObject>.Move(tryttlSeconds);
                }

                TtlSeconds = tryttlSeconds.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryquery = reader.ReadString();
                if (tryquery.IsError)
                {
                    return ReadResult<IObject>.Move(tryquery);
                }

                Query = tryquery.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputMediaDocument";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputMediaDocument();
            newClonedObject.Flags = Flags;
            var cloneId = (CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase?)Id.Clone();
            if (cloneId is null)
            {
                return null;
            }

            newClonedObject.Id = cloneId;
            newClonedObject.TtlSeconds = TtlSeconds;
            newClonedObject.Query = Query;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputMediaDocument castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Id.Compare(castedOther.Id))
            {
                return true;
            }

            if (TtlSeconds != castedOther.TtlSeconds)
            {
                return true;
            }

            if (Query != castedOther.Query)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
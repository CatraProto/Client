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
    public partial class MessageMediaDocument : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Nopremium = 1 << 3,
            Document = 1 << 0,
            TtlSeconds = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1666158377; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("nopremium")]
        public bool Nopremium { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("document")]
        public CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }

        [Newtonsoft.Json.JsonProperty("ttl_seconds")]
        public int? TtlSeconds { get; set; }


        public MessageMediaDocument()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Nopremium ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = TtlSeconds == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkdocument = writer.WriteObject(Document);
                if (checkdocument.IsError)
                {
                    return checkdocument;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteInt32(TtlSeconds.Value);
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
            Nopremium = FlagsHelper.IsFlagSet(Flags, 3);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trydocument = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
                if (trydocument.IsError)
                {
                    return ReadResult<IObject>.Move(trydocument);
                }

                Document = trydocument.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryttlSeconds = reader.ReadInt32();
                if (tryttlSeconds.IsError)
                {
                    return ReadResult<IObject>.Move(tryttlSeconds);
                }

                TtlSeconds = tryttlSeconds.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageMediaDocument";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageMediaDocument();
            newClonedObject.Flags = Flags;
            newClonedObject.Nopremium = Nopremium;
            if (Document is not null)
            {
                var cloneDocument = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)Document.Clone();
                if (cloneDocument is null)
                {
                    return null;
                }

                newClonedObject.Document = cloneDocument;
            }

            newClonedObject.TtlSeconds = TtlSeconds;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageMediaDocument castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Nopremium != castedOther.Nopremium)
            {
                return true;
            }

            if (Document is null && castedOther.Document is not null || Document is not null && castedOther.Document is null)
            {
                return true;
            }

            if (Document is not null && castedOther.Document is not null && Document.Compare(castedOther.Document))
            {
                return true;
            }

            if (TtlSeconds != castedOther.TtlSeconds)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
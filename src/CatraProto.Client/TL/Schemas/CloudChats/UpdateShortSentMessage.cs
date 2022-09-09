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
    public partial class UpdateShortSentMessage : CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Out = 1 << 1,
            Media = 1 << 9,
            Entities = 1 << 7,
            TtlPeriod = 1 << 25
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1877614335; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("out")] public bool Out { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")] public int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("pts_count")]
        public int PtsCount { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("media")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase Media { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("entities")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

        [Newtonsoft.Json.JsonProperty("ttl_period")]
        public int? TtlPeriod { get; set; }


#nullable enable
        public UpdateShortSentMessage(int id, int pts, int ptsCount, int date)
        {
            Id = id;
            Pts = pts;
            PtsCount = ptsCount;
            Date = date;
        }
#nullable disable
        internal UpdateShortSentMessage()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Out ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Media == null ? FlagsHelper.UnsetFlag(Flags, 9) : FlagsHelper.SetFlag(Flags, 9);
            Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 7) : FlagsHelper.SetFlag(Flags, 7);
            Flags = TtlPeriod == null ? FlagsHelper.UnsetFlag(Flags, 25) : FlagsHelper.SetFlag(Flags, 25);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Id);
            writer.WriteInt32(Pts);
            writer.WriteInt32(PtsCount);
            writer.WriteInt32(Date);
            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                var checkmedia = writer.WriteObject(Media);
                if (checkmedia.IsError)
                {
                    return checkmedia;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                var checkentities = writer.WriteVector(Entities, false);
                if (checkentities.IsError)
                {
                    return checkentities;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 25))
            {
                writer.WriteInt32(TtlPeriod.Value);
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
            Out = FlagsHelper.IsFlagSet(Flags, 1);
            var tryid = reader.ReadInt32();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var trypts = reader.ReadInt32();
            if (trypts.IsError)
            {
                return ReadResult<IObject>.Move(trypts);
            }

            Pts = trypts.Value;
            var tryptsCount = reader.ReadInt32();
            if (tryptsCount.IsError)
            {
                return ReadResult<IObject>.Move(tryptsCount);
            }

            PtsCount = tryptsCount.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                var trymedia = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>();
                if (trymedia.IsError)
                {
                    return ReadResult<IObject>.Move(trymedia);
                }

                Media = trymedia.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                var tryentities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (tryentities.IsError)
                {
                    return ReadResult<IObject>.Move(tryentities);
                }

                Entities = tryentities.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 25))
            {
                var tryttlPeriod = reader.ReadInt32();
                if (tryttlPeriod.IsError)
                {
                    return ReadResult<IObject>.Move(tryttlPeriod);
                }

                TtlPeriod = tryttlPeriod.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateShortSentMessage";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateShortSentMessage();
            newClonedObject.Flags = Flags;
            newClonedObject.Out = Out;
            newClonedObject.Id = Id;
            newClonedObject.Pts = Pts;
            newClonedObject.PtsCount = PtsCount;
            newClonedObject.Date = Date;
            if (Media is not null)
            {
                var cloneMedia = (CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase?)Media.Clone();
                if (cloneMedia is null)
                {
                    return null;
                }

                newClonedObject.Media = cloneMedia;
            }

            if (Entities is not null)
            {
                newClonedObject.Entities = new List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
                foreach (var entities in Entities)
                {
                    var cloneentities = (CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase?)entities.Clone();
                    if (cloneentities is null)
                    {
                        return null;
                    }

                    newClonedObject.Entities.Add(cloneentities);
                }
            }

            newClonedObject.TtlPeriod = TtlPeriod;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateShortSentMessage castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Out != castedOther.Out)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (Pts != castedOther.Pts)
            {
                return true;
            }

            if (PtsCount != castedOther.PtsCount)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (Media is null && castedOther.Media is not null || Media is not null && castedOther.Media is null)
            {
                return true;
            }

            if (Media is not null && castedOther.Media is not null && Media.Compare(castedOther.Media))
            {
                return true;
            }

            if (Entities is null && castedOther.Entities is not null || Entities is not null && castedOther.Entities is null)
            {
                return true;
            }

            if (Entities is not null && castedOther.Entities is not null)
            {
                var entitiessize = castedOther.Entities.Count;
                if (entitiessize != Entities.Count)
                {
                    return true;
                }

                for (var i = 0; i < entitiessize; i++)
                {
                    if (castedOther.Entities[i].Compare(Entities[i]))
                    {
                        return true;
                    }
                }
            }

            if (TtlPeriod != castedOther.TtlPeriod)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
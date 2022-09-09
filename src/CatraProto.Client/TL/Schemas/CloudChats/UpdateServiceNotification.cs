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
    public partial class UpdateServiceNotification : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Popup = 1 << 0,
            InboxDate = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -337352679; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("popup")]
        public bool Popup { get; set; }

        [Newtonsoft.Json.JsonProperty("inbox_date")]
        public int? InboxDate { get; set; }

        [Newtonsoft.Json.JsonProperty("type")] public string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("message")]
        public string Message { get; set; }

        [Newtonsoft.Json.JsonProperty("media")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase Media { get; set; }

        [Newtonsoft.Json.JsonProperty("entities")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }


#nullable enable
        public UpdateServiceNotification(string type, string message, CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase media, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> entities)
        {
            Type = type;
            Message = message;
            Media = media;
            Entities = entities;
        }
#nullable disable
        internal UpdateServiceNotification()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Popup ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = InboxDate == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(InboxDate.Value);
            }


            writer.WriteString(Type);

            writer.WriteString(Message);
            var checkmedia = writer.WriteObject(Media);
            if (checkmedia.IsError)
            {
                return checkmedia;
            }

            var checkentities = writer.WriteVector(Entities, false);
            if (checkentities.IsError)
            {
                return checkentities;
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
            Popup = FlagsHelper.IsFlagSet(Flags, 0);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryinboxDate = reader.ReadInt32();
                if (tryinboxDate.IsError)
                {
                    return ReadResult<IObject>.Move(tryinboxDate);
                }

                InboxDate = tryinboxDate.Value;
            }

            var trytype = reader.ReadString();
            if (trytype.IsError)
            {
                return ReadResult<IObject>.Move(trytype);
            }

            Type = trytype.Value;
            var trymessage = reader.ReadString();
            if (trymessage.IsError)
            {
                return ReadResult<IObject>.Move(trymessage);
            }

            Message = trymessage.Value;
            var trymedia = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>();
            if (trymedia.IsError)
            {
                return ReadResult<IObject>.Move(trymedia);
            }

            Media = trymedia.Value;
            var tryentities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryentities.IsError)
            {
                return ReadResult<IObject>.Move(tryentities);
            }

            Entities = tryentities.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateServiceNotification";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateServiceNotification();
            newClonedObject.Flags = Flags;
            newClonedObject.Popup = Popup;
            newClonedObject.InboxDate = InboxDate;
            newClonedObject.Type = Type;
            newClonedObject.Message = Message;
            var cloneMedia = (CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase?)Media.Clone();
            if (cloneMedia is null)
            {
                return null;
            }

            newClonedObject.Media = cloneMedia;
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

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateServiceNotification castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Popup != castedOther.Popup)
            {
                return true;
            }

            if (InboxDate != castedOther.InboxDate)
            {
                return true;
            }

            if (Type != castedOther.Type)
            {
                return true;
            }

            if (Message != castedOther.Message)
            {
                return true;
            }

            if (Media.Compare(castedOther.Media))
            {
                return true;
            }

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

            return false;
        }

#nullable disable
    }
}
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
    public partial class ChatInvite : CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Channel = 1 << 0,
            Broadcast = 1 << 1,
            Public = 1 << 2,
            Megagroup = 1 << 3,
            RequestNeeded = 1 << 6,
            About = 1 << 5,
            Participants = 1 << 4
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 806110401; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("channel")]
        public bool Channel { get; set; }

        [Newtonsoft.Json.JsonProperty("broadcast")]
        public bool Broadcast { get; set; }

        [Newtonsoft.Json.JsonProperty("public")]
        public bool Public { get; set; }

        [Newtonsoft.Json.JsonProperty("megagroup")]
        public bool Megagroup { get; set; }

        [Newtonsoft.Json.JsonProperty("request_needed")]
        public bool RequestNeeded { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("about")]
        public string About { get; set; }

        [Newtonsoft.Json.JsonProperty("photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase Photo { get; set; }

        [Newtonsoft.Json.JsonProperty("participants_count")]
        public int ParticipantsCount { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("participants")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Participants { get; set; }


#nullable enable
        public ChatInvite(string title, CatraProto.Client.TL.Schemas.CloudChats.PhotoBase photo, int participantsCount)
        {
            Title = title;
            Photo = photo;
            ParticipantsCount = participantsCount;
        }
#nullable disable
        internal ChatInvite()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Channel ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Broadcast ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Public ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = Megagroup ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = RequestNeeded ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
            Flags = About == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
            Flags = Participants == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Title);
            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                writer.WriteString(About);
            }

            var checkphoto = writer.WriteObject(Photo);
            if (checkphoto.IsError)
            {
                return checkphoto;
            }

            writer.WriteInt32(ParticipantsCount);
            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var checkparticipants = writer.WriteVector(Participants, false);
                if (checkparticipants.IsError)
                {
                    return checkparticipants;
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
            Channel = FlagsHelper.IsFlagSet(Flags, 0);
            Broadcast = FlagsHelper.IsFlagSet(Flags, 1);
            Public = FlagsHelper.IsFlagSet(Flags, 2);
            Megagroup = FlagsHelper.IsFlagSet(Flags, 3);
            RequestNeeded = FlagsHelper.IsFlagSet(Flags, 6);
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }

            Title = trytitle.Value;
            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var tryabout = reader.ReadString();
                if (tryabout.IsError)
                {
                    return ReadResult<IObject>.Move(tryabout);
                }

                About = tryabout.Value;
            }

            var tryphoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
            if (tryphoto.IsError)
            {
                return ReadResult<IObject>.Move(tryphoto);
            }

            Photo = tryphoto.Value;
            var tryparticipantsCount = reader.ReadInt32();
            if (tryparticipantsCount.IsError)
            {
                return ReadResult<IObject>.Move(tryparticipantsCount);
            }

            ParticipantsCount = tryparticipantsCount.Value;
            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var tryparticipants = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (tryparticipants.IsError)
                {
                    return ReadResult<IObject>.Move(tryparticipants);
                }

                Participants = tryparticipants.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "chatInvite";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatInvite();
            newClonedObject.Flags = Flags;
            newClonedObject.Channel = Channel;
            newClonedObject.Broadcast = Broadcast;
            newClonedObject.Public = Public;
            newClonedObject.Megagroup = Megagroup;
            newClonedObject.RequestNeeded = RequestNeeded;
            newClonedObject.Title = Title;
            newClonedObject.About = About;
            var clonePhoto = (CatraProto.Client.TL.Schemas.CloudChats.PhotoBase?)Photo.Clone();
            if (clonePhoto is null)
            {
                return null;
            }

            newClonedObject.Photo = clonePhoto;
            newClonedObject.ParticipantsCount = ParticipantsCount;
            if (Participants is not null)
            {
                newClonedObject.Participants = new List<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
                foreach (var participants in Participants)
                {
                    var cloneparticipants = (CatraProto.Client.TL.Schemas.CloudChats.UserBase?)participants.Clone();
                    if (cloneparticipants is null)
                    {
                        return null;
                    }

                    newClonedObject.Participants.Add(cloneparticipants);
                }
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChatInvite castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Channel != castedOther.Channel)
            {
                return true;
            }

            if (Broadcast != castedOther.Broadcast)
            {
                return true;
            }

            if (Public != castedOther.Public)
            {
                return true;
            }

            if (Megagroup != castedOther.Megagroup)
            {
                return true;
            }

            if (RequestNeeded != castedOther.RequestNeeded)
            {
                return true;
            }

            if (Title != castedOther.Title)
            {
                return true;
            }

            if (About != castedOther.About)
            {
                return true;
            }

            if (Photo.Compare(castedOther.Photo))
            {
                return true;
            }

            if (ParticipantsCount != castedOther.ParticipantsCount)
            {
                return true;
            }

            if (Participants is null && castedOther.Participants is not null || Participants is not null && castedOther.Participants is null)
            {
                return true;
            }

            if (Participants is not null && castedOther.Participants is not null)
            {
                var participantssize = castedOther.Participants.Count;
                if (participantssize != Participants.Count)
                {
                    return true;
                }

                for (var i = 0; i < participantssize; i++)
                {
                    if (castedOther.Participants[i].Compare(Participants[i]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

#nullable disable
    }
}
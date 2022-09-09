using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class SetCallRating : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            UserInitiative = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1508562471; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("user_initiative")]
        public bool UserInitiative { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("rating")]
        public int Rating { get; set; }

        [Newtonsoft.Json.JsonProperty("comment")]
        public string Comment { get; set; }


#nullable enable
        public SetCallRating(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, int rating, string comment)
        {
            Peer = peer;
            Rating = rating;
            Comment = comment;
        }
#nullable disable

        internal SetCallRating()
        {
        }

        public void UpdateFlags()
        {
            Flags = UserInitiative ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteInt32(Rating);

            writer.WriteString(Comment);

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
            UserInitiative = FlagsHelper.IsFlagSet(Flags, 0);
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var tryrating = reader.ReadInt32();
            if (tryrating.IsError)
            {
                return ReadResult<IObject>.Move(tryrating);
            }

            Rating = tryrating.Value;
            var trycomment = reader.ReadString();
            if (trycomment.IsError)
            {
                return ReadResult<IObject>.Move(trycomment);
            }

            Comment = trycomment.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "phone.setCallRating";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetCallRating();
            newClonedObject.Flags = Flags;
            newClonedObject.UserInitiative = UserInitiative;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.Rating = Rating;
            newClonedObject.Comment = Comment;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SetCallRating castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (UserInitiative != castedOther.UserInitiative)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (Rating != castedOther.Rating)
            {
                return true;
            }

            if (Comment != castedOther.Comment)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
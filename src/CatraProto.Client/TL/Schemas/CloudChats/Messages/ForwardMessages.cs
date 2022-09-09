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
    public partial class ForwardMessages : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Silent = 1 << 5,
            Background = 1 << 6,
            WithMyScore = 1 << 8,
            DropAuthor = 1 << 11,
            DropMediaCaptions = 1 << 12,
            Noforwards = 1 << 14,
            ScheduleDate = 1 << 10,
            SendAs = 1 << 13
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -869258997; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("silent")]
        public bool Silent { get; set; }

        [Newtonsoft.Json.JsonProperty("background")]
        public bool Background { get; set; }

        [Newtonsoft.Json.JsonProperty("with_my_score")]
        public bool WithMyScore { get; set; }

        [Newtonsoft.Json.JsonProperty("drop_author")]
        public bool DropAuthor { get; set; }

        [Newtonsoft.Json.JsonProperty("drop_media_captions")]
        public bool DropMediaCaptions { get; set; }

        [Newtonsoft.Json.JsonProperty("noforwards")]
        public bool Noforwards { get; set; }

        [Newtonsoft.Json.JsonProperty("from_peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase FromPeer { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public List<int> Id { get; set; }

        [Newtonsoft.Json.JsonProperty("random_id")]
        public List<long> RandomId { get; set; }

        [Newtonsoft.Json.JsonProperty("to_peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase ToPeer { get; set; }

        [Newtonsoft.Json.JsonProperty("schedule_date")]
        public int? ScheduleDate { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("send_as")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase SendAs { get; set; }


#nullable enable
        public ForwardMessages(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase fromPeer, List<int> id, List<long> randomId, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase toPeer)
        {
            FromPeer = fromPeer;
            Id = id;
            RandomId = randomId;
            ToPeer = toPeer;
        }
#nullable disable

        internal ForwardMessages()
        {
        }

        public void UpdateFlags()
        {
            Flags = Silent ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = Background ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
            Flags = WithMyScore ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
            Flags = DropAuthor ? FlagsHelper.SetFlag(Flags, 11) : FlagsHelper.UnsetFlag(Flags, 11);
            Flags = DropMediaCaptions ? FlagsHelper.SetFlag(Flags, 12) : FlagsHelper.UnsetFlag(Flags, 12);
            Flags = Noforwards ? FlagsHelper.SetFlag(Flags, 14) : FlagsHelper.UnsetFlag(Flags, 14);
            Flags = ScheduleDate == null ? FlagsHelper.UnsetFlag(Flags, 10) : FlagsHelper.SetFlag(Flags, 10);
            Flags = SendAs == null ? FlagsHelper.UnsetFlag(Flags, 13) : FlagsHelper.SetFlag(Flags, 13);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkfromPeer = writer.WriteObject(FromPeer);
            if (checkfromPeer.IsError)
            {
                return checkfromPeer;
            }

            writer.WriteVector(Id, false);

            writer.WriteVector(RandomId, false);
            var checktoPeer = writer.WriteObject(ToPeer);
            if (checktoPeer.IsError)
            {
                return checktoPeer;
            }

            if (FlagsHelper.IsFlagSet(Flags, 10))
            {
                writer.WriteInt32(ScheduleDate.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 13))
            {
                var checksendAs = writer.WriteObject(SendAs);
                if (checksendAs.IsError)
                {
                    return checksendAs;
                }
            }


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
            Silent = FlagsHelper.IsFlagSet(Flags, 5);
            Background = FlagsHelper.IsFlagSet(Flags, 6);
            WithMyScore = FlagsHelper.IsFlagSet(Flags, 8);
            DropAuthor = FlagsHelper.IsFlagSet(Flags, 11);
            DropMediaCaptions = FlagsHelper.IsFlagSet(Flags, 12);
            Noforwards = FlagsHelper.IsFlagSet(Flags, 14);
            var tryfromPeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (tryfromPeer.IsError)
            {
                return ReadResult<IObject>.Move(tryfromPeer);
            }

            FromPeer = tryfromPeer.Value;
            var tryid = reader.ReadVector<int>(ParserTypes.Int);
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var tryrandomId = reader.ReadVector<long>(ParserTypes.Int64);
            if (tryrandomId.IsError)
            {
                return ReadResult<IObject>.Move(tryrandomId);
            }

            RandomId = tryrandomId.Value;
            var trytoPeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trytoPeer.IsError)
            {
                return ReadResult<IObject>.Move(trytoPeer);
            }

            ToPeer = trytoPeer.Value;
            if (FlagsHelper.IsFlagSet(Flags, 10))
            {
                var tryscheduleDate = reader.ReadInt32();
                if (tryscheduleDate.IsError)
                {
                    return ReadResult<IObject>.Move(tryscheduleDate);
                }

                ScheduleDate = tryscheduleDate.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 13))
            {
                var trysendAs = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
                if (trysendAs.IsError)
                {
                    return ReadResult<IObject>.Move(trysendAs);
                }

                SendAs = trysendAs.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.forwardMessages";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ForwardMessages();
            newClonedObject.Flags = Flags;
            newClonedObject.Silent = Silent;
            newClonedObject.Background = Background;
            newClonedObject.WithMyScore = WithMyScore;
            newClonedObject.DropAuthor = DropAuthor;
            newClonedObject.DropMediaCaptions = DropMediaCaptions;
            newClonedObject.Noforwards = Noforwards;
            var cloneFromPeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)FromPeer.Clone();
            if (cloneFromPeer is null)
            {
                return null;
            }

            newClonedObject.FromPeer = cloneFromPeer;
            newClonedObject.Id = new List<int>();
            foreach (var id in Id)
            {
                newClonedObject.Id.Add(id);
            }

            newClonedObject.RandomId = new List<long>();
            foreach (var randomId in RandomId)
            {
                newClonedObject.RandomId.Add(randomId);
            }

            var cloneToPeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)ToPeer.Clone();
            if (cloneToPeer is null)
            {
                return null;
            }

            newClonedObject.ToPeer = cloneToPeer;
            newClonedObject.ScheduleDate = ScheduleDate;
            if (SendAs is not null)
            {
                var cloneSendAs = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)SendAs.Clone();
                if (cloneSendAs is null)
                {
                    return null;
                }

                newClonedObject.SendAs = cloneSendAs;
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ForwardMessages castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Silent != castedOther.Silent)
            {
                return true;
            }

            if (Background != castedOther.Background)
            {
                return true;
            }

            if (WithMyScore != castedOther.WithMyScore)
            {
                return true;
            }

            if (DropAuthor != castedOther.DropAuthor)
            {
                return true;
            }

            if (DropMediaCaptions != castedOther.DropMediaCaptions)
            {
                return true;
            }

            if (Noforwards != castedOther.Noforwards)
            {
                return true;
            }

            if (FromPeer.Compare(castedOther.FromPeer))
            {
                return true;
            }

            var idsize = castedOther.Id.Count;
            if (idsize != Id.Count)
            {
                return true;
            }

            for (var i = 0; i < idsize; i++)
            {
                if (castedOther.Id[i] != Id[i])
                {
                    return true;
                }
            }

            var randomIdsize = castedOther.RandomId.Count;
            if (randomIdsize != RandomId.Count)
            {
                return true;
            }

            for (var i = 0; i < randomIdsize; i++)
            {
                if (castedOther.RandomId[i] != RandomId[i])
                {
                    return true;
                }
            }

            if (ToPeer.Compare(castedOther.ToPeer))
            {
                return true;
            }

            if (ScheduleDate != castedOther.ScheduleDate)
            {
                return true;
            }

            if (SendAs is null && castedOther.SendAs is not null || SendAs is not null && castedOther.SendAs is null)
            {
                return true;
            }

            if (SendAs is not null && castedOther.SendAs is not null && SendAs.Compare(castedOther.SendAs))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
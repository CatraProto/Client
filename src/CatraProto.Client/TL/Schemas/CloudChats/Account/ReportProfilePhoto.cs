using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class ReportProfilePhoto : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -91437323; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("photo_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase PhotoId { get; set; }

        [Newtonsoft.Json.JsonProperty("reason")]
        public CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase Reason { get; set; }

        [Newtonsoft.Json.JsonProperty("message")]
        public string Message { get; set; }


#nullable enable
        public ReportProfilePhoto(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase photoId, CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase reason, string message)
        {
            Peer = peer;
            PhotoId = photoId;
            Reason = reason;
            Message = message;
        }
#nullable disable

        internal ReportProfilePhoto()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            var checkphotoId = writer.WriteObject(PhotoId);
            if (checkphotoId.IsError)
            {
                return checkphotoId;
            }

            var checkreason = writer.WriteObject(Reason);
            if (checkreason.IsError)
            {
                return checkreason;
            }

            writer.WriteString(Message);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var tryphotoId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase>();
            if (tryphotoId.IsError)
            {
                return ReadResult<IObject>.Move(tryphotoId);
            }

            PhotoId = tryphotoId.Value;
            var tryreason = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase>();
            if (tryreason.IsError)
            {
                return ReadResult<IObject>.Move(tryreason);
            }

            Reason = tryreason.Value;
            var trymessage = reader.ReadString();
            if (trymessage.IsError)
            {
                return ReadResult<IObject>.Move(trymessage);
            }

            Message = trymessage.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.reportProfilePhoto";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ReportProfilePhoto();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            var clonePhotoId = (CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase?)PhotoId.Clone();
            if (clonePhotoId is null)
            {
                return null;
            }

            newClonedObject.PhotoId = clonePhotoId;
            var cloneReason = (CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase?)Reason.Clone();
            if (cloneReason is null)
            {
                return null;
            }

            newClonedObject.Reason = cloneReason;
            newClonedObject.Message = Message;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ReportProfilePhoto castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (PhotoId.Compare(castedOther.PhotoId))
            {
                return true;
            }

            if (Reason.Compare(castedOther.Reason))
            {
                return true;
            }

            if (Message != castedOther.Message)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
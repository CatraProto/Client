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
    public partial class UpdateEditMessage : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -469536605; }

        [Newtonsoft.Json.JsonProperty("message")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessageBase Message { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")] public int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("pts_count")]
        public int PtsCount { get; set; }


#nullable enable
        public UpdateEditMessage(CatraProto.Client.TL.Schemas.CloudChats.MessageBase message, int pts, int ptsCount)
        {
            Message = message;
            Pts = pts;
            PtsCount = ptsCount;
        }
#nullable disable
        internal UpdateEditMessage()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkmessage = writer.WriteObject(Message);
            if (checkmessage.IsError)
            {
                return checkmessage;
            }

            writer.WriteInt32(Pts);
            writer.WriteInt32(PtsCount);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trymessage = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
            if (trymessage.IsError)
            {
                return ReadResult<IObject>.Move(trymessage);
            }

            Message = trymessage.Value;
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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateEditMessage";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateEditMessage();
            var cloneMessage = (CatraProto.Client.TL.Schemas.CloudChats.MessageBase?)Message.Clone();
            if (cloneMessage is null)
            {
                return null;
            }

            newClonedObject.Message = cloneMessage;
            newClonedObject.Pts = Pts;
            newClonedObject.PtsCount = PtsCount;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateEditMessage castedOther)
            {
                return true;
            }

            if (Message.Compare(castedOther.Message))
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

            return false;
        }

#nullable disable
    }
}
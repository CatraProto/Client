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
    public partial class SendMessageHistoryImportAction : CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -606432698; }

        [Newtonsoft.Json.JsonProperty("progress")]
        public int Progress { get; set; }


#nullable enable
        public SendMessageHistoryImportAction(int progress)
        {
            Progress = progress;
        }
#nullable disable
        internal SendMessageHistoryImportAction()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Progress);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryprogress = reader.ReadInt32();
            if (tryprogress.IsError)
            {
                return ReadResult<IObject>.Move(tryprogress);
            }

            Progress = tryprogress.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "sendMessageHistoryImportAction";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SendMessageHistoryImportAction();
            newClonedObject.Progress = Progress;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SendMessageHistoryImportAction castedOther)
            {
                return true;
            }

            if (Progress != castedOther.Progress)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
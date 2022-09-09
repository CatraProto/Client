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
    public partial class CheckedHistoryImportPeer : CatraProto.Client.TL.Schemas.CloudChats.Messages.CheckedHistoryImportPeerBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1571952873; }

        [Newtonsoft.Json.JsonProperty("confirm_text")]
        public sealed override string ConfirmText { get; set; }


#nullable enable
        public CheckedHistoryImportPeer(string confirmText)
        {
            ConfirmText = confirmText;
        }
#nullable disable
        internal CheckedHistoryImportPeer()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(ConfirmText);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryconfirmText = reader.ReadString();
            if (tryconfirmText.IsError)
            {
                return ReadResult<IObject>.Move(tryconfirmText);
            }

            ConfirmText = tryconfirmText.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.checkedHistoryImportPeer";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new CheckedHistoryImportPeer();
            newClonedObject.ConfirmText = ConfirmText;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not CheckedHistoryImportPeer castedOther)
            {
                return true;
            }

            if (ConfirmText != castedOther.ConfirmText)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
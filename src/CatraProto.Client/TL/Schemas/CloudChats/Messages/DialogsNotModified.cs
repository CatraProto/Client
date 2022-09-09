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
    public partial class DialogsNotModified : CatraProto.Client.TL.Schemas.CloudChats.Messages.DialogsBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -253500010; }

        [Newtonsoft.Json.JsonProperty("count")]
        public int Count { get; set; }


#nullable enable
        public DialogsNotModified(int count)
        {
            Count = count;
        }
#nullable disable
        internal DialogsNotModified()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Count);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycount = reader.ReadInt32();
            if (trycount.IsError)
            {
                return ReadResult<IObject>.Move(trycount);
            }

            Count = trycount.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.dialogsNotModified";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DialogsNotModified();
            newClonedObject.Count = Count;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not DialogsNotModified castedOther)
            {
                return true;
            }

            if (Count != castedOther.Count)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
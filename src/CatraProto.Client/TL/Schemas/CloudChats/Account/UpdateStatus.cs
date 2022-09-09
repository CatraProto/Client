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
    public partial class UpdateStatus : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1713919532; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("offline")]
        public bool Offline { get; set; }


#nullable enable
        public UpdateStatus(bool offline)
        {
            Offline = offline;
        }
#nullable disable

        internal UpdateStatus()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkoffline = writer.WriteBool(Offline);
            if (checkoffline.IsError)
            {
                return checkoffline;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryoffline = reader.ReadBool();
            if (tryoffline.IsError)
            {
                return ReadResult<IObject>.Move(tryoffline);
            }

            Offline = tryoffline.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.updateStatus";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new UpdateStatus();
            newClonedObject.Offline = Offline;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not UpdateStatus castedOther)
            {
                return true;
            }

            if (Offline != castedOther.Offline)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
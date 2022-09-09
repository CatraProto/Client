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
    public partial class WebPagePending : CatraProto.Client.TL.Schemas.CloudChats.WebPageBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -981018084; }

        [Newtonsoft.Json.JsonProperty("id")] public long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }


#nullable enable
        public WebPagePending(long id, int date)
        {
            Id = id;
            Date = date;
        }
#nullable disable
        internal WebPagePending()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Id);
            writer.WriteInt32(Date);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "webPagePending";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new WebPagePending();
            newClonedObject.Id = Id;
            newClonedObject.Date = Date;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not WebPagePending castedOther)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
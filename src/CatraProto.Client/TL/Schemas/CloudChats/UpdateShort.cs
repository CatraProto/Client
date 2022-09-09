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
    public partial class UpdateShort : CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 2027216577; }

        [Newtonsoft.Json.JsonProperty("update")]
        public CatraProto.Client.TL.Schemas.CloudChats.UpdateBase Update { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }


#nullable enable
        public UpdateShort(CatraProto.Client.TL.Schemas.CloudChats.UpdateBase update, int date)
        {
            Update = update;
            Date = date;
        }
#nullable disable
        internal UpdateShort()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkupdate = writer.WriteObject(Update);
            if (checkupdate.IsError)
            {
                return checkupdate;
            }

            writer.WriteInt32(Date);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryupdate = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase>();
            if (tryupdate.IsError)
            {
                return ReadResult<IObject>.Move(tryupdate);
            }

            Update = tryupdate.Value;
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
            return "updateShort";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateShort();
            var cloneUpdate = (CatraProto.Client.TL.Schemas.CloudChats.UpdateBase?)Update.Clone();
            if (cloneUpdate is null)
            {
                return null;
            }

            newClonedObject.Update = cloneUpdate;
            newClonedObject.Date = Date;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateShort castedOther)
            {
                return true;
            }

            if (Update.Compare(castedOther.Update))
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
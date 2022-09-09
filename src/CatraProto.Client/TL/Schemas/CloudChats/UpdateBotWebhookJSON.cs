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
    public partial class UpdateBotWebhookJSON : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2095595325; }

        [Newtonsoft.Json.JsonProperty("data")] public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Data { get; set; }


#nullable enable
        public UpdateBotWebhookJSON(CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase data)
        {
            Data = data;
        }
#nullable disable
        internal UpdateBotWebhookJSON()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkdata = writer.WriteObject(Data);
            if (checkdata.IsError)
            {
                return checkdata;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydata = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
            if (trydata.IsError)
            {
                return ReadResult<IObject>.Move(trydata);
            }

            Data = trydata.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateBotWebhookJSON";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateBotWebhookJSON();
            var cloneData = (CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase?)Data.Clone();
            if (cloneData is null)
            {
                return null;
            }

            newClonedObject.Data = cloneData;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateBotWebhookJSON castedOther)
            {
                return true;
            }

            if (Data.Compare(castedOther.Data))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
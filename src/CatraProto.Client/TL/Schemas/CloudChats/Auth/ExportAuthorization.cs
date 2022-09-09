using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class ExportAuthorization : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -440401971; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("dc_id")]
        public int DcId { get; set; }


#nullable enable
        public ExportAuthorization(int dcId)
        {
            DcId = dcId;
        }
#nullable disable

        internal ExportAuthorization()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(DcId);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydcId = reader.ReadInt32();
            if (trydcId.IsError)
            {
                return ReadResult<IObject>.Move(trydcId);
            }

            DcId = trydcId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "auth.exportAuthorization";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ExportAuthorization();
            newClonedObject.DcId = DcId;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ExportAuthorization castedOther)
            {
                return true;
            }

            if (DcId != castedOther.DcId)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
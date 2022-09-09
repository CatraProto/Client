using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
    public partial class SendCustomRequest : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1440257555; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("custom_method")]
        public string CustomMethod { get; set; }

        [Newtonsoft.Json.JsonProperty("params")]
        public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Params { get; set; }


#nullable enable
        public SendCustomRequest(string customMethod, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase pparams)
        {
            CustomMethod = customMethod;
            Params = pparams;
        }
#nullable disable

        internal SendCustomRequest()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(CustomMethod);
            var checkpparams = writer.WriteObject(Params);
            if (checkpparams.IsError)
            {
                return checkpparams;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycustomMethod = reader.ReadString();
            if (trycustomMethod.IsError)
            {
                return ReadResult<IObject>.Move(trycustomMethod);
            }

            CustomMethod = trycustomMethod.Value;
            var trypparams = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
            if (trypparams.IsError)
            {
                return ReadResult<IObject>.Move(trypparams);
            }

            Params = trypparams.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "bots.sendCustomRequest";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SendCustomRequest();
            newClonedObject.CustomMethod = CustomMethod;
            var cloneParams = (CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase?)Params.Clone();
            if (cloneParams is null)
            {
                return null;
            }

            newClonedObject.Params = cloneParams;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SendCustomRequest castedOther)
            {
                return true;
            }

            if (CustomMethod != castedOther.CustomMethod)
            {
                return true;
            }

            if (Params.Compare(castedOther.Params))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
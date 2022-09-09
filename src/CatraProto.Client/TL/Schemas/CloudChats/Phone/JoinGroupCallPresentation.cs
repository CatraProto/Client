using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class JoinGroupCallPresentation : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -873829436; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("call")] public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        [Newtonsoft.Json.JsonProperty("params")]
        public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Params { get; set; }


#nullable enable
        public JoinGroupCallPresentation(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase pparams)
        {
            Call = call;
            Params = pparams;
        }
#nullable disable

        internal JoinGroupCallPresentation()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkcall = writer.WriteObject(Call);
            if (checkcall.IsError)
            {
                return checkcall;
            }

            var checkpparams = writer.WriteObject(Params);
            if (checkpparams.IsError)
            {
                return checkpparams;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
            if (trycall.IsError)
            {
                return ReadResult<IObject>.Move(trycall);
            }

            Call = trycall.Value;
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
            return "phone.joinGroupCallPresentation";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new JoinGroupCallPresentation();
            var cloneCall = (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase?)Call.Clone();
            if (cloneCall is null)
            {
                return null;
            }

            newClonedObject.Call = cloneCall;
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
            if (other is not JoinGroupCallPresentation castedOther)
            {
                return true;
            }

            if (Call.Compare(castedOther.Call))
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
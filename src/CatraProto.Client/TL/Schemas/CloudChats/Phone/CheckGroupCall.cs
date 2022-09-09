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
    public partial class CheckGroupCall : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1248003721; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Int;

        [Newtonsoft.Json.JsonProperty("call")] public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        [Newtonsoft.Json.JsonProperty("sources")]
        public List<int> Sources { get; set; }


#nullable enable
        public CheckGroupCall(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, List<int> sources)
        {
            Call = call;
            Sources = sources;
        }
#nullable disable

        internal CheckGroupCall()
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

            writer.WriteVector(Sources, false);

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
            var trysources = reader.ReadVector<int>(ParserTypes.Int);
            if (trysources.IsError)
            {
                return ReadResult<IObject>.Move(trysources);
            }

            Sources = trysources.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "phone.checkGroupCall";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new CheckGroupCall();
            var cloneCall = (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase?)Call.Clone();
            if (cloneCall is null)
            {
                return null;
            }

            newClonedObject.Call = cloneCall;
            newClonedObject.Sources = new List<int>();
            foreach (var sources in Sources)
            {
                newClonedObject.Sources.Add(sources);
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not CheckGroupCall castedOther)
            {
                return true;
            }

            if (Call.Compare(castedOther.Call))
            {
                return true;
            }

            var sourcessize = castedOther.Sources.Count;
            if (sourcessize != Sources.Count)
            {
                return true;
            }

            for (var i = 0; i < sourcessize; i++)
            {
                if (castedOther.Sources[i] != Sources[i])
                {
                    return true;
                }
            }

            return false;
        }
#nullable disable
    }
}
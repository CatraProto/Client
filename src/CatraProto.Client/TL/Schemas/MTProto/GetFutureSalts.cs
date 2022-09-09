using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class GetFutureSalts : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1188971260; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("num")] public int Num { get; set; }


#nullable enable
        public GetFutureSalts(int num)
        {
            Num = num;
        }
#nullable disable

        internal GetFutureSalts()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Num);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trynum = reader.ReadInt32();
            if (trynum.IsError)
            {
                return ReadResult<IObject>.Move(trynum);
            }

            Num = trynum.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "get_future_salts";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetFutureSalts();
            newClonedObject.Num = Num;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetFutureSalts castedOther)
            {
                return true;
            }

            if (Num != castedOther.Num)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
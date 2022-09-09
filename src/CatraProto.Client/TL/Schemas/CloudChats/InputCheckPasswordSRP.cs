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
    public partial class InputCheckPasswordSRP : CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -763367294; }

        [Newtonsoft.Json.JsonProperty("srp_id")]
        public long SrpId { get; set; }

        [Newtonsoft.Json.JsonProperty("A")] public byte[] A { get; set; }

        [Newtonsoft.Json.JsonProperty("M1")] public byte[] M1 { get; set; }


#nullable enable
        public InputCheckPasswordSRP(long srpId, byte[] a, byte[] m1)
        {
            SrpId = srpId;
            A = a;
            M1 = m1;
        }
#nullable disable
        internal InputCheckPasswordSRP()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(SrpId);

            writer.WriteBytes(A);

            writer.WriteBytes(M1);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysrpId = reader.ReadInt64();
            if (trysrpId.IsError)
            {
                return ReadResult<IObject>.Move(trysrpId);
            }

            SrpId = trysrpId.Value;
            var trya = reader.ReadBytes();
            if (trya.IsError)
            {
                return ReadResult<IObject>.Move(trya);
            }

            A = trya.Value;
            var trym1 = reader.ReadBytes();
            if (trym1.IsError)
            {
                return ReadResult<IObject>.Move(trym1);
            }

            M1 = trym1.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputCheckPasswordSRP";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputCheckPasswordSRP();
            newClonedObject.SrpId = SrpId;
            newClonedObject.A = A;
            newClonedObject.M1 = M1;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputCheckPasswordSRP castedOther)
            {
                return true;
            }

            if (SrpId != castedOther.SrpId)
            {
                return true;
            }

            if (A != castedOther.A)
            {
                return true;
            }

            if (M1 != castedOther.M1)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
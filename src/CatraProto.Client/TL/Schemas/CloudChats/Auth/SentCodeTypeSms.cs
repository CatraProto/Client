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
    public partial class SentCodeTypeSms : CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1073693790; }

        [Newtonsoft.Json.JsonProperty("length")]
        public int Length { get; set; }


#nullable enable
        public SentCodeTypeSms(int length)
        {
            Length = length;
        }
#nullable disable
        internal SentCodeTypeSms()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Length);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trylength = reader.ReadInt32();
            if (trylength.IsError)
            {
                return ReadResult<IObject>.Move(trylength);
            }

            Length = trylength.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "auth.sentCodeTypeSms";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SentCodeTypeSms();
            newClonedObject.Length = Length;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SentCodeTypeSms castedOther)
            {
                return true;
            }

            if (Length != castedOther.Length)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
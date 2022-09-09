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
    public partial class SecureValueErrorData : CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -391902247; }

        [Newtonsoft.Json.JsonProperty("type")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

        [Newtonsoft.Json.JsonProperty("data_hash")]
        public byte[] DataHash { get; set; }

        [Newtonsoft.Json.JsonProperty("field")]
        public string Field { get; set; }

        [Newtonsoft.Json.JsonProperty("text")] public sealed override string Text { get; set; }


#nullable enable
        public SecureValueErrorData(CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase type, byte[] dataHash, string field, string text)
        {
            Type = type;
            DataHash = dataHash;
            Field = field;
            Text = text;
        }
#nullable disable
        internal SecureValueErrorData()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checktype = writer.WriteObject(Type);
            if (checktype.IsError)
            {
                return checktype;
            }

            writer.WriteBytes(DataHash);

            writer.WriteString(Field);

            writer.WriteString(Text);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytype = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>();
            if (trytype.IsError)
            {
                return ReadResult<IObject>.Move(trytype);
            }

            Type = trytype.Value;
            var trydataHash = reader.ReadBytes();
            if (trydataHash.IsError)
            {
                return ReadResult<IObject>.Move(trydataHash);
            }

            DataHash = trydataHash.Value;
            var tryfield = reader.ReadString();
            if (tryfield.IsError)
            {
                return ReadResult<IObject>.Move(tryfield);
            }

            Field = tryfield.Value;
            var trytext = reader.ReadString();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }

            Text = trytext.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "secureValueErrorData";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SecureValueErrorData();
            var cloneType = (CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase?)Type.Clone();
            if (cloneType is null)
            {
                return null;
            }

            newClonedObject.Type = cloneType;
            newClonedObject.DataHash = DataHash;
            newClonedObject.Field = Field;
            newClonedObject.Text = Text;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SecureValueErrorData castedOther)
            {
                return true;
            }

            if (Type.Compare(castedOther.Type))
            {
                return true;
            }

            if (DataHash != castedOther.DataHash)
            {
                return true;
            }

            if (Field != castedOther.Field)
            {
                return true;
            }

            if (Text != castedOther.Text)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
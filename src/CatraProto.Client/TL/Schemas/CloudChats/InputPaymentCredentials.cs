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
    public partial class InputPaymentCredentials : CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Save = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 873977640; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("save")] public bool Save { get; set; }

        [Newtonsoft.Json.JsonProperty("data")] public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Data { get; set; }


#nullable enable
        public InputPaymentCredentials(CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase data)
        {
            Data = data;
        }
#nullable disable
        internal InputPaymentCredentials()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Save ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkdata = writer.WriteObject(Data);
            if (checkdata.IsError)
            {
                return checkdata;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            Save = FlagsHelper.IsFlagSet(Flags, 0);
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
            return "inputPaymentCredentials";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputPaymentCredentials();
            newClonedObject.Flags = Flags;
            newClonedObject.Save = Save;
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
            if (other is not InputPaymentCredentials castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Save != castedOther.Save)
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
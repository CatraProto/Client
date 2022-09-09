using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class TermsOfServiceUpdateEmpty : CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceUpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -483352705; }

        [Newtonsoft.Json.JsonProperty("expires")]
        public sealed override int Expires { get; set; }


#nullable enable
        public TermsOfServiceUpdateEmpty(int expires)
        {
            Expires = expires;
        }
#nullable disable
        internal TermsOfServiceUpdateEmpty()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Expires);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryexpires = reader.ReadInt32();
            if (tryexpires.IsError)
            {
                return ReadResult<IObject>.Move(tryexpires);
            }

            Expires = tryexpires.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "help.termsOfServiceUpdateEmpty";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TermsOfServiceUpdateEmpty();
            newClonedObject.Expires = Expires;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not TermsOfServiceUpdateEmpty castedOther)
            {
                return true;
            }

            if (Expires != castedOther.Expires)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
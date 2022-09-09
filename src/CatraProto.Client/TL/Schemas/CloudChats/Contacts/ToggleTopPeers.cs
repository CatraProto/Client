using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class ToggleTopPeers : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2062238246; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("enabled")]
        public bool Enabled { get; set; }


#nullable enable
        public ToggleTopPeers(bool enabled)
        {
            Enabled = enabled;
        }
#nullable disable

        internal ToggleTopPeers()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkenabled = writer.WriteBool(Enabled);
            if (checkenabled.IsError)
            {
                return checkenabled;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryenabled = reader.ReadBool();
            if (tryenabled.IsError)
            {
                return ReadResult<IObject>.Move(tryenabled);
            }

            Enabled = tryenabled.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "contacts.toggleTopPeers";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ToggleTopPeers();
            newClonedObject.Enabled = Enabled;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ToggleTopPeers castedOther)
            {
                return true;
            }

            if (Enabled != castedOther.Enabled)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
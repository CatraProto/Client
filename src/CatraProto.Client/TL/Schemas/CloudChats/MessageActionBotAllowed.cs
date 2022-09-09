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
    public partial class MessageActionBotAllowed : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1410748418; }

        [Newtonsoft.Json.JsonProperty("domain")]
        public string Domain { get; set; }


#nullable enable
        public MessageActionBotAllowed(string domain)
        {
            Domain = domain;
        }
#nullable disable
        internal MessageActionBotAllowed()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Domain);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydomain = reader.ReadString();
            if (trydomain.IsError)
            {
                return ReadResult<IObject>.Move(trydomain);
            }

            Domain = trydomain.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageActionBotAllowed";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageActionBotAllowed();
            newClonedObject.Domain = Domain;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageActionBotAllowed castedOther)
            {
                return true;
            }

            if (Domain != castedOther.Domain)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
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
    public partial class InputClientProxy : CatraProto.Client.TL.Schemas.CloudChats.InputClientProxyBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1968737087; }

        [Newtonsoft.Json.JsonProperty("address")]
        public sealed override string Address { get; set; }

        [Newtonsoft.Json.JsonProperty("port")] public sealed override int Port { get; set; }


#nullable enable
        public InputClientProxy(string address, int port)
        {
            Address = address;
            Port = port;
        }
#nullable disable
        internal InputClientProxy()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Address);
            writer.WriteInt32(Port);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryaddress = reader.ReadString();
            if (tryaddress.IsError)
            {
                return ReadResult<IObject>.Move(tryaddress);
            }

            Address = tryaddress.Value;
            var tryport = reader.ReadInt32();
            if (tryport.IsError)
            {
                return ReadResult<IObject>.Move(tryport);
            }

            Port = tryport.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputClientProxy";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputClientProxy();
            newClonedObject.Address = Address;
            newClonedObject.Port = Port;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputClientProxy castedOther)
            {
                return true;
            }

            if (Address != castedOther.Address)
            {
                return true;
            }

            if (Port != castedOther.Port)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
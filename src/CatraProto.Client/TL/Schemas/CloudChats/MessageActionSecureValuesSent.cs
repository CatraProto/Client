using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionSecureValuesSent : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -648257196; }

        [Newtonsoft.Json.JsonProperty("types")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase> Types { get; set; }


#nullable enable
        public MessageActionSecureValuesSent(List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase> types)
        {
            Types = types;

        }
#nullable disable
        internal MessageActionSecureValuesSent()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checktypes = writer.WriteVector(Types, false);
            if (checktypes.IsError)
            {
                return checktypes;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytypes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trytypes.IsError)
            {
                return ReadResult<IObject>.Move(trytypes);
            }
            Types = trytypes.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageActionSecureValuesSent";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
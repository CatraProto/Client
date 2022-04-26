using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class MsgContainer : CatraProto.Client.TL.Schemas.MTProto.MessageContainerBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1945237724; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public sealed override List<CatraProto.Client.TL.Schemas.MTProto.Message> Messages { get; set; }


#nullable enable
        public MsgContainer(List<CatraProto.Client.TL.Schemas.MTProto.Message> messages)
        {
            Messages = messages;

        }
#nullable disable
        internal MsgContainer()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkmessages = writer.WriteVector(Messages, true);
            if (checkmessages.IsError)
            {
                return checkmessages;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trymessages = reader.ReadVector<CatraProto.Client.TL.Schemas.MTProto.Message>(ParserTypes.Object, nakedVector: true, nakedObjects: true);
            if (trymessages.IsError)
            {
                return ReadResult<IObject>.Move(trymessages);
            }
            Messages = trymessages.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "msg_container";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MsgContainer();
            foreach (var messages in Messages)
            {
                var clonemessages = (CatraProto.Client.TL.Schemas.MTProto.Message?)messages.Clone();
                if (clonemessages is null)
                {
                    return null;
                }
                newClonedObject.Messages.Add(clonemessages);
            }
            return newClonedObject;

        }
#nullable disable
    }
}
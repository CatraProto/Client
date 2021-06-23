using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public class MsgContainer : MessageContainerBase
    {
        public static int ConstructorId { get; } = 1945237724;
        public override IList<MessageBase> Messages { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Messages);
        }

        public override void Deserialize(Reader reader)
        {
            Messages = reader.ReadVector<MessageBase>(() =>
            {
                var instance = (MessageBase) new Message();
                instance.Deserialize(reader);
                return instance;
            });
        }
    }
}
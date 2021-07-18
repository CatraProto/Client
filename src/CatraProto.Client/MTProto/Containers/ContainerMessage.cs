using System;
using CatraProto.Client.Connections;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.MTProto.Containers
{
    class ContainerMessage : IObject
    {


        public static int ConstructorId { get; } = 0;
        public MessageContainer MessageContainer { get; set; }
        public long MsgId { get; set; }
        public int Seqno { get; set; }
        public byte[] Body { get; set; }

        public void UpdateFlags()
        {

        }

        public void Serialize(Writer writer)
        {
            writer.Write(MsgId);
            writer.Write(Seqno);
            writer.Write(Body.Length);
            writer.Write(Body);

        }

        public void Deserialize(Reader reader)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.IO;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using CatraProto.TL.Exceptions;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.MTProto.Deserializers
{
    public class MsgContainerDeserializer : Message
    {
        public override long MsgId { get; set; }
        public override int Seqno { get; set; }
        public override int Bytes { get; set; }
        public override IObject Body { get; set; }

        public override void Deserialize(Reader reader)
        {
            MsgId = reader.Read<long>();
            Seqno = reader.Read<int>();
            Bytes = reader.Read<int>();
            var currentPosition = reader.Stream.Position;
            try
            {
                Body = reader.Read<IObject>();
            }
            catch (DeserializationException exception) when (exception.ErrorCode == DeserializationException.DeserializationErrors.ProviderReturnedNull)
            {
                var stream = reader.Stream;
                stream.Seek(currentPosition + Bytes, SeekOrigin.Begin);
            }
        }

        public override void Serialize(Writer writer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateFlags()
        {
        }
    }
}
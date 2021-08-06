using System.IO;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Session;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using CatraProto.TL.Exceptions;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Interfaces.Deserializers;
using Serilog;
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
                if (Body is GzipPacked packed)
                {
                    Body = GzipHandler.DeserializeGzip(packed.PackedData);
                }
            }
            catch (DeserializationException exception) when (exception.ErrorCode == DeserializationException.DeserializationErrors.ProviderReturnedNull)
            {
                var stream = reader.Stream;
                stream.Seek(currentPosition + Bytes, SeekOrigin.Begin);
            }
        }

        public override void Serialize(Writer writer)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateFlags()
        {
        }
    }
}
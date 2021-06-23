using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
    public class AnswerWebhookJSONQuery : IMethod
    {
        public static int ConstructorId { get; } = -434028723;

        public Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;
        public long QueryId { get; set; }
        public DataJSONBase Data { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(QueryId);
            writer.Write(Data);
        }

        public void Deserialize(Reader reader)
        {
            QueryId = reader.Read<long>();
            Data = reader.Read<DataJSONBase>();
        }
    }
}
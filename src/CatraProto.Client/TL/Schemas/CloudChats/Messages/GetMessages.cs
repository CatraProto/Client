using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class GetMessages : IMethod
    {
        public static int ConstructorId { get; } = 1673946374;

        public System.Type Type { get; init; } = typeof(MessagesBase);
        public bool IsVector { get; init; } = false;
        public IList<InputMessageBase> Id { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Id);
        }

        public void Deserialize(Reader reader)
        {
            Id = reader.ReadVector<InputMessageBase>();
        }
    }
}
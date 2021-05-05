using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class AcceptTermsOfService : IMethod<bool>
    {
        public static int ConstructorId { get; } = -294455398;
        public DataJSONBase Id { get; set; }

        public Type Type { get; init; } = typeof(AcceptTermsOfService);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Id);
        }

        public void Deserialize(Reader reader)
        {
            Id = reader.Read<DataJSONBase>();
        }
    }
}
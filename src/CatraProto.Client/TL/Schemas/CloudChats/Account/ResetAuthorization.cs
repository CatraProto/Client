using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public class ResetAuthorization : IMethod
    {
        public static int ConstructorId { get; } = -545786948;

        public Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;
        public long Hash { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            Hash = reader.Read<long>();
        }
    }
}
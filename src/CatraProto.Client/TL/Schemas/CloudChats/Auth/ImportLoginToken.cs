using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public class ImportLoginToken : IMethod
    {
        public static int ConstructorId { get; } = -1783866140;

        public Type Type { get; init; } = typeof(LoginTokenBase);
        public bool IsVector { get; init; } = false;
        public byte[] Token { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Token);
        }

        public void Deserialize(Reader reader)
        {
            Token = reader.Read<byte[]>();
        }
    }
}
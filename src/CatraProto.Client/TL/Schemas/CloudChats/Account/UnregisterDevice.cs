using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public class UnregisterDevice : IMethod
    {
        public static int ConstructorId { get; } = 813089983;

        public Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;
        public int TokenType { get; set; }
        public string Token { get; set; }
        public IList<int> OtherUids { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(TokenType);
            writer.Write(Token);
            writer.Write(OtherUids);
        }

        public void Deserialize(Reader reader)
        {
            TokenType = reader.Read<int>();
            Token = reader.Read<string>();
            OtherUids = reader.ReadVector<int>();
        }
    }
}
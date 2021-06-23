using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public class GetAuthorizationForm : IMethod
    {
        public static int ConstructorId { get; } = -1200903967;

        public Type Type { get; init; } = typeof(AuthorizationFormBase);
        public bool IsVector { get; init; } = false;
        public int BotId { get; set; }
        public string Scope { get; set; }
        public string PublicKey { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(BotId);
            writer.Write(Scope);
            writer.Write(PublicKey);
        }

        public void Deserialize(Reader reader)
        {
            BotId = reader.Read<int>();
            Scope = reader.Read<string>();
            PublicKey = reader.Read<string>();
        }
    }
}
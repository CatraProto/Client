using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class MessageActionSecureValuesSentMe : MessageActionBase
    {
        public static int ConstructorId { get; } = 455635795;
        public IList<SecureValueBase> Values { get; set; }
        public SecureCredentialsEncryptedBase Credentials { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Values);
            writer.Write(Credentials);
        }

        public override void Deserialize(Reader reader)
        {
            Values = reader.ReadVector<SecureValueBase>();
            Credentials = reader.Read<SecureCredentialsEncryptedBase>();
        }
    }
}
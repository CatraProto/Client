using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public class GetTmpPassword : IMethod
    {
        public static int ConstructorId { get; } = 1151208273;

        public Type Type { get; init; } = typeof(TmpPasswordBase);
        public bool IsVector { get; init; } = false;
        public InputCheckPasswordSRPBase Password { get; set; }
        public int Period { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Password);
            writer.Write(Period);
        }

        public void Deserialize(Reader reader)
        {
            Password = reader.Read<InputCheckPasswordSRPBase>();
            Period = reader.Read<int>();
        }
    }
}
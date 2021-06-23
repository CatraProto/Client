using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public class UpdateDeviceLocked : IMethod
    {
        public static int ConstructorId { get; } = 954152242;

        public Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;
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

            writer.Write(Period);
        }

        public void Deserialize(Reader reader)
        {
            Period = reader.Read<int>();
        }
    }
}
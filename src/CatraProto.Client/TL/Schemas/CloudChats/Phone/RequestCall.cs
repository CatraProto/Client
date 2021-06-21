using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class RequestCall : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Video = 1 << 0
        }

        public static int ConstructorId { get; } = 1124046573;
        public int Flags { get; set; }
        public bool Video { get; set; }
        public InputUserBase UserId { get; set; }
        public int RandomId { get; set; }
        public byte[] GAHash { get; set; }
        public PhoneCallProtocolBase Protocol { get; set; }

        public Type Type { get; init; } = typeof(PhoneCallBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
            Flags = Video ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(UserId);
            writer.Write(RandomId);
            writer.Write(GAHash);
            writer.Write(Protocol);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Video = FlagsHelper.IsFlagSet(Flags, 0);
            UserId = reader.Read<InputUserBase>();
            RandomId = reader.Read<int>();
            GAHash = reader.Read<byte[]>();
            Protocol = reader.Read<PhoneCallProtocolBase>();
        }
    }
}
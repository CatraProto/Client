using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class PhoneConnectionWebrtc : PhoneConnectionBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Turn = 1 << 0,
            Stun = 1 << 1
        }

        public static int ConstructorId { get; } = 1667228533;
        public int Flags { get; set; }
        public bool Turn { get; set; }
        public bool Stun { get; set; }
        public override long Id { get; set; }
        public override string Ip { get; set; }
        public override string Ipv6 { get; set; }
        public override int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override void UpdateFlags()
        {
            Flags = Turn ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Stun ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            writer.Write(Ip);
            writer.Write(Ipv6);
            writer.Write(Port);
            writer.Write(Username);
            writer.Write(Password);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Turn = FlagsHelper.IsFlagSet(Flags, 0);
            Stun = FlagsHelper.IsFlagSet(Flags, 1);
            Id = reader.Read<long>();
            Ip = reader.Read<string>();
            Ipv6 = reader.Read<string>();
            Port = reader.Read<int>();
            Username = reader.Read<string>();
            Password = reader.Read<string>();
        }
    }
}
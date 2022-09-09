using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PhoneConnectionWebrtc : CatraProto.Client.TL.Schemas.CloudChats.PhoneConnectionBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Turn = 1 << 0,
            Stun = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1667228533; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("turn")] public bool Turn { get; set; }

        [Newtonsoft.Json.JsonProperty("stun")] public bool Stun { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("ip")] public sealed override string Ip { get; set; }

        [Newtonsoft.Json.JsonProperty("ipv6")] public sealed override string Ipv6 { get; set; }

        [Newtonsoft.Json.JsonProperty("port")] public sealed override int Port { get; set; }

        [Newtonsoft.Json.JsonProperty("username")]
        public string Username { get; set; }

        [Newtonsoft.Json.JsonProperty("password")]
        public string Password { get; set; }


#nullable enable
        public PhoneConnectionWebrtc(long id, string ip, string ipv6, int port, string username, string password)
        {
            Id = id;
            Ip = ip;
            Ipv6 = ipv6;
            Port = port;
            Username = username;
            Password = password;
        }
#nullable disable
        internal PhoneConnectionWebrtc()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Turn ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Stun ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(Id);

            writer.WriteString(Ip);

            writer.WriteString(Ipv6);
            writer.WriteInt32(Port);

            writer.WriteString(Username);

            writer.WriteString(Password);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            Turn = FlagsHelper.IsFlagSet(Flags, 0);
            Stun = FlagsHelper.IsFlagSet(Flags, 1);
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var tryip = reader.ReadString();
            if (tryip.IsError)
            {
                return ReadResult<IObject>.Move(tryip);
            }

            Ip = tryip.Value;
            var tryipv6 = reader.ReadString();
            if (tryipv6.IsError)
            {
                return ReadResult<IObject>.Move(tryipv6);
            }

            Ipv6 = tryipv6.Value;
            var tryport = reader.ReadInt32();
            if (tryport.IsError)
            {
                return ReadResult<IObject>.Move(tryport);
            }

            Port = tryport.Value;
            var tryusername = reader.ReadString();
            if (tryusername.IsError)
            {
                return ReadResult<IObject>.Move(tryusername);
            }

            Username = tryusername.Value;
            var trypassword = reader.ReadString();
            if (trypassword.IsError)
            {
                return ReadResult<IObject>.Move(trypassword);
            }

            Password = trypassword.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "phoneConnectionWebrtc";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PhoneConnectionWebrtc();
            newClonedObject.Flags = Flags;
            newClonedObject.Turn = Turn;
            newClonedObject.Stun = Stun;
            newClonedObject.Id = Id;
            newClonedObject.Ip = Ip;
            newClonedObject.Ipv6 = Ipv6;
            newClonedObject.Port = Port;
            newClonedObject.Username = Username;
            newClonedObject.Password = Password;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PhoneConnectionWebrtc castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Turn != castedOther.Turn)
            {
                return true;
            }

            if (Stun != castedOther.Stun)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (Ip != castedOther.Ip)
            {
                return true;
            }

            if (Ipv6 != castedOther.Ipv6)
            {
                return true;
            }

            if (Port != castedOther.Port)
            {
                return true;
            }

            if (Username != castedOther.Username)
            {
                return true;
            }

            if (Password != castedOther.Password)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
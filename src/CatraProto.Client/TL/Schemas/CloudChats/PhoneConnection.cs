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
    public partial class PhoneConnection : CatraProto.Client.TL.Schemas.CloudChats.PhoneConnectionBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Tcp = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1665063993; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("tcp")] public bool Tcp { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("ip")] public sealed override string Ip { get; set; }

        [Newtonsoft.Json.JsonProperty("ipv6")] public sealed override string Ipv6 { get; set; }

        [Newtonsoft.Json.JsonProperty("port")] public sealed override int Port { get; set; }

        [Newtonsoft.Json.JsonProperty("peer_tag")]
        public byte[] PeerTag { get; set; }


#nullable enable
        public PhoneConnection(long id, string ip, string ipv6, int port, byte[] peerTag)
        {
            Id = id;
            Ip = ip;
            Ipv6 = ipv6;
            Port = port;
            PeerTag = peerTag;
        }
#nullable disable
        internal PhoneConnection()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Tcp ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
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

            writer.WriteBytes(PeerTag);

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
            Tcp = FlagsHelper.IsFlagSet(Flags, 0);
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
            var trypeerTag = reader.ReadBytes();
            if (trypeerTag.IsError)
            {
                return ReadResult<IObject>.Move(trypeerTag);
            }

            PeerTag = trypeerTag.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "phoneConnection";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PhoneConnection();
            newClonedObject.Flags = Flags;
            newClonedObject.Tcp = Tcp;
            newClonedObject.Id = Id;
            newClonedObject.Ip = Ip;
            newClonedObject.Ipv6 = Ipv6;
            newClonedObject.Port = Port;
            newClonedObject.PeerTag = PeerTag;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PhoneConnection castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Tcp != castedOther.Tcp)
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

            if (PeerTag != castedOther.PeerTag)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
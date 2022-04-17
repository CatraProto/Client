using System;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageEmpty : CatraProto.Client.TL.Schemas.CloudChats.MessageBase
    {
        [Flags]
        public enum FlagsEnum
        {
            PeerId = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1868117372; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("id")]
        public sealed override int Id { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("peer_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase PeerId { get; set; }


#nullable enable
        public MessageEmpty(int id)
        {
            Id = id;

        }
#nullable disable
        internal MessageEmpty()
        {
        }

        public override void UpdateFlags()
        {
            Flags = PeerId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Id);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkpeerId = writer.WriteObject(PeerId);
                if (checkpeerId.IsError)
                {
                    return checkpeerId;
                }
            }


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
            var tryid = reader.ReadInt32();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trypeerId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
                if (trypeerId.IsError)
                {
                    return ReadResult<IObject>.Move(trypeerId);
                }
                PeerId = trypeerId.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageEmpty";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
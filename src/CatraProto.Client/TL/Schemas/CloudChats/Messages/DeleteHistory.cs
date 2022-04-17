using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class DeleteHistory : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            JustClear = 1 << 0,
            Revoke = 1 << 1,
            MinDate = 1 << 2,
            MaxDate = 1 << 3
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1332768214; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("just_clear")]
        public bool JustClear { get; set; }

        [Newtonsoft.Json.JsonProperty("revoke")]
        public bool Revoke { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("max_id")]
        public int MaxId { get; set; }

        [Newtonsoft.Json.JsonProperty("min_date")]
        public int? MinDate { get; set; }

        [Newtonsoft.Json.JsonProperty("max_date")]
        public int? MaxDate { get; set; }


#nullable enable
        public DeleteHistory(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int maxId)
        {
            Peer = peer;
            MaxId = maxId;

        }
#nullable disable

        internal DeleteHistory()
        {
        }

        public void UpdateFlags()
        {
            Flags = JustClear ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Revoke ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = MinDate == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = MaxDate == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }
            writer.WriteInt32(MaxId);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteInt32(MinDate.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.WriteInt32(MaxDate.Value);
            }


            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            JustClear = FlagsHelper.IsFlagSet(Flags, 0);
            Revoke = FlagsHelper.IsFlagSet(Flags, 1);
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }
            Peer = trypeer.Value;
            var trymaxId = reader.ReadInt32();
            if (trymaxId.IsError)
            {
                return ReadResult<IObject>.Move(trymaxId);
            }
            MaxId = trymaxId.Value;
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryminDate = reader.ReadInt32();
                if (tryminDate.IsError)
                {
                    return ReadResult<IObject>.Move(tryminDate);
                }
                MinDate = tryminDate.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var trymaxDate = reader.ReadInt32();
                if (trymaxDate.IsError)
                {
                    return ReadResult<IObject>.Move(trymaxDate);
                }
                MaxDate = trymaxDate.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.deleteHistory";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
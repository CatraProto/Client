using System;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetNotifyExceptions : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            CompareSound = 1 << 1,
            Peer = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1398240377; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("compare_sound")]
        public bool CompareSound { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase Peer { get; set; }




        public GetNotifyExceptions()
        {
        }

        public void UpdateFlags()
        {
            Flags = CompareSound ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Peer == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkpeer = writer.WriteObject(Peer);
                if (checkpeer.IsError)
                {
                    return checkpeer;
                }
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
            CompareSound = FlagsHelper.IsFlagSet(Flags, 1);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase>();
                if (trypeer.IsError)
                {
                    return ReadResult<IObject>.Move(trypeer);
                }
                Peer = trypeer.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.getNotifyExceptions";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
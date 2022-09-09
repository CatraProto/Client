using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class SentCode : CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase
    {
        [Flags]
        public enum FlagsEnum
        {
            NextType = 1 << 1,
            Timeout = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1577067778; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("type")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase Type { get; set; }

        [Newtonsoft.Json.JsonProperty("phone_code_hash")]
        public sealed override string PhoneCodeHash { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("next_type")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.Auth.CodeTypeBase NextType { get; set; }

        [Newtonsoft.Json.JsonProperty("timeout")]
        public sealed override int? Timeout { get; set; }


#nullable enable
        public SentCode(CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase type, string phoneCodeHash)
        {
            Type = type;
            PhoneCodeHash = phoneCodeHash;
        }
#nullable disable
        internal SentCode()
        {
        }

        public override void UpdateFlags()
        {
            Flags = NextType == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Timeout == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checktype = writer.WriteObject(Type);
            if (checktype.IsError)
            {
                return checktype;
            }

            writer.WriteString(PhoneCodeHash);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checknextType = writer.WriteObject(NextType);
                if (checknextType.IsError)
                {
                    return checknextType;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteInt32(Timeout.Value);
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
            var trytype = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase>();
            if (trytype.IsError)
            {
                return ReadResult<IObject>.Move(trytype);
            }

            Type = trytype.Value;
            var tryphoneCodeHash = reader.ReadString();
            if (tryphoneCodeHash.IsError)
            {
                return ReadResult<IObject>.Move(tryphoneCodeHash);
            }

            PhoneCodeHash = tryphoneCodeHash.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trynextType = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.Auth.CodeTypeBase>();
                if (trynextType.IsError)
                {
                    return ReadResult<IObject>.Move(trynextType);
                }

                NextType = trynextType.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trytimeout = reader.ReadInt32();
                if (trytimeout.IsError)
                {
                    return ReadResult<IObject>.Move(trytimeout);
                }

                Timeout = trytimeout.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "auth.sentCode";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SentCode();
            newClonedObject.Flags = Flags;
            var cloneType = (CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase?)Type.Clone();
            if (cloneType is null)
            {
                return null;
            }

            newClonedObject.Type = cloneType;
            newClonedObject.PhoneCodeHash = PhoneCodeHash;
            if (NextType is not null)
            {
                var cloneNextType = (CatraProto.Client.TL.Schemas.CloudChats.Auth.CodeTypeBase?)NextType.Clone();
                if (cloneNextType is null)
                {
                    return null;
                }

                newClonedObject.NextType = cloneNextType;
            }

            newClonedObject.Timeout = Timeout;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SentCode castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Type.Compare(castedOther.Type))
            {
                return true;
            }

            if (PhoneCodeHash != castedOther.PhoneCodeHash)
            {
                return true;
            }

            if (NextType is null && castedOther.NextType is not null || NextType is not null && castedOther.NextType is null)
            {
                return true;
            }

            if (NextType is not null && castedOther.NextType is not null && NextType.Compare(castedOther.NextType))
            {
                return true;
            }

            if (Timeout != castedOther.Timeout)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
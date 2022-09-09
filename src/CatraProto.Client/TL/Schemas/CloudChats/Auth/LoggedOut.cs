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
    public partial class LoggedOut : CatraProto.Client.TL.Schemas.CloudChats.Auth.LoggedOutBase
    {
        [Flags]
        public enum FlagsEnum
        {
            FutureAuthToken = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1012759713; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("future_auth_token")]
        public sealed override byte[] FutureAuthToken { get; set; }


        public LoggedOut()
        {
        }

        public override void UpdateFlags()
        {
            Flags = FutureAuthToken == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteBytes(FutureAuthToken);
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
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryfutureAuthToken = reader.ReadBytes();
                if (tryfutureAuthToken.IsError)
                {
                    return ReadResult<IObject>.Move(tryfutureAuthToken);
                }

                FutureAuthToken = tryfutureAuthToken.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "auth.loggedOut";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new LoggedOut();
            newClonedObject.Flags = Flags;
            newClonedObject.FutureAuthToken = FutureAuthToken;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not LoggedOut castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (FutureAuthToken != castedOther.FutureAuthToken)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
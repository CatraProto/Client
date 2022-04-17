using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class CodeSettings : CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            AllowFlashcall = 1 << 0,
            CurrentNumber = 1 << 1,
            AllowAppHash = 1 << 4,
            AllowMissedCall = 1 << 5,
            LogoutTokens = 1 << 6
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1973130814; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("allow_flashcall")]
        public sealed override bool AllowFlashcall { get; set; }

        [Newtonsoft.Json.JsonProperty("current_number")]
        public sealed override bool CurrentNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("allow_app_hash")]
        public sealed override bool AllowAppHash { get; set; }

        [Newtonsoft.Json.JsonProperty("allow_missed_call")]
        public sealed override bool AllowMissedCall { get; set; }

        [Newtonsoft.Json.JsonProperty("logout_tokens")]
        public sealed override List<byte[]> LogoutTokens { get; set; }



        public CodeSettings()
        {
        }

        public override void UpdateFlags()
        {
            Flags = AllowFlashcall ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = CurrentNumber ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = AllowAppHash ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = AllowMissedCall ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = LogoutTokens == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 6))
            {

                writer.WriteVector(LogoutTokens, false);
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
            AllowFlashcall = FlagsHelper.IsFlagSet(Flags, 0);
            CurrentNumber = FlagsHelper.IsFlagSet(Flags, 1);
            AllowAppHash = FlagsHelper.IsFlagSet(Flags, 4);
            AllowMissedCall = FlagsHelper.IsFlagSet(Flags, 5);
            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                var trylogoutTokens = reader.ReadVector<byte[]>(ParserTypes.Bytes, nakedVector: false, nakedObjects: false);
                if (trylogoutTokens.IsError)
                {
                    return ReadResult<IObject>.Move(trylogoutTokens);
                }
                LogoutTokens = trylogoutTokens.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "codeSettings";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
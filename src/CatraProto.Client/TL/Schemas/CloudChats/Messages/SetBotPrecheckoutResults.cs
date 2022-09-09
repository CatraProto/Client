using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SetBotPrecheckoutResults : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Success = 1 << 1,
            Error = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 163765653; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("success")]
        public bool Success { get; set; }

        [Newtonsoft.Json.JsonProperty("query_id")]
        public long QueryId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("error")]
        public string Error { get; set; }


#nullable enable
        public SetBotPrecheckoutResults(long queryId)
        {
            QueryId = queryId;
        }
#nullable disable

        internal SetBotPrecheckoutResults()
        {
        }

        public void UpdateFlags()
        {
            Flags = Success ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Error == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(QueryId);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteString(Error);
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
            Success = FlagsHelper.IsFlagSet(Flags, 1);
            var tryqueryId = reader.ReadInt64();
            if (tryqueryId.IsError)
            {
                return ReadResult<IObject>.Move(tryqueryId);
            }

            QueryId = tryqueryId.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryerror = reader.ReadString();
                if (tryerror.IsError)
                {
                    return ReadResult<IObject>.Move(tryerror);
                }

                Error = tryerror.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.setBotPrecheckoutResults";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetBotPrecheckoutResults();
            newClonedObject.Flags = Flags;
            newClonedObject.Success = Success;
            newClonedObject.QueryId = QueryId;
            newClonedObject.Error = Error;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SetBotPrecheckoutResults castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Success != castedOther.Success)
            {
                return true;
            }

            if (QueryId != castedOther.QueryId)
            {
                return true;
            }

            if (Error != castedOther.Error)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
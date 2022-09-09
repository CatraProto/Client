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
    public partial class SetInlineBotResults : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Gallery = 1 << 0,
            Private = 1 << 1,
            NextOffset = 1 << 2,
            SwitchPm = 1 << 3
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -346119674; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("gallery")]
        public bool Gallery { get; set; }

        [Newtonsoft.Json.JsonProperty("private")]
        public bool Private { get; set; }

        [Newtonsoft.Json.JsonProperty("query_id")]
        public long QueryId { get; set; }

        [Newtonsoft.Json.JsonProperty("results")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase> Results { get; set; }

        [Newtonsoft.Json.JsonProperty("cache_time")]
        public int CacheTime { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("next_offset")]
        public string NextOffset { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("switch_pm")]
        public CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPMBase SwitchPm { get; set; }


#nullable enable
        public SetInlineBotResults(long queryId, List<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase> results, int cacheTime)
        {
            QueryId = queryId;
            Results = results;
            CacheTime = cacheTime;
        }
#nullable disable

        internal SetInlineBotResults()
        {
        }

        public void UpdateFlags()
        {
            Flags = Gallery ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Private ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = NextOffset == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = SwitchPm == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(QueryId);
            var checkresults = writer.WriteVector(Results, false);
            if (checkresults.IsError)
            {
                return checkresults;
            }

            writer.WriteInt32(CacheTime);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteString(NextOffset);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var checkswitchPm = writer.WriteObject(SwitchPm);
                if (checkswitchPm.IsError)
                {
                    return checkswitchPm;
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
            Gallery = FlagsHelper.IsFlagSet(Flags, 0);
            Private = FlagsHelper.IsFlagSet(Flags, 1);
            var tryqueryId = reader.ReadInt64();
            if (tryqueryId.IsError)
            {
                return ReadResult<IObject>.Move(tryqueryId);
            }

            QueryId = tryqueryId.Value;
            var tryresults = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryresults.IsError)
            {
                return ReadResult<IObject>.Move(tryresults);
            }

            Results = tryresults.Value;
            var trycacheTime = reader.ReadInt32();
            if (trycacheTime.IsError)
            {
                return ReadResult<IObject>.Move(trycacheTime);
            }

            CacheTime = trycacheTime.Value;
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trynextOffset = reader.ReadString();
                if (trynextOffset.IsError)
                {
                    return ReadResult<IObject>.Move(trynextOffset);
                }

                NextOffset = trynextOffset.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryswitchPm = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPMBase>();
                if (tryswitchPm.IsError)
                {
                    return ReadResult<IObject>.Move(tryswitchPm);
                }

                SwitchPm = tryswitchPm.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.setInlineBotResults";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetInlineBotResults();
            newClonedObject.Flags = Flags;
            newClonedObject.Gallery = Gallery;
            newClonedObject.Private = Private;
            newClonedObject.QueryId = QueryId;
            newClonedObject.Results = new List<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase>();
            foreach (var results in Results)
            {
                var cloneresults = (CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase?)results.Clone();
                if (cloneresults is null)
                {
                    return null;
                }

                newClonedObject.Results.Add(cloneresults);
            }

            newClonedObject.CacheTime = CacheTime;
            newClonedObject.NextOffset = NextOffset;
            if (SwitchPm is not null)
            {
                var cloneSwitchPm = (CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPMBase?)SwitchPm.Clone();
                if (cloneSwitchPm is null)
                {
                    return null;
                }

                newClonedObject.SwitchPm = cloneSwitchPm;
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SetInlineBotResults castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Gallery != castedOther.Gallery)
            {
                return true;
            }

            if (Private != castedOther.Private)
            {
                return true;
            }

            if (QueryId != castedOther.QueryId)
            {
                return true;
            }

            var resultssize = castedOther.Results.Count;
            if (resultssize != Results.Count)
            {
                return true;
            }

            for (var i = 0; i < resultssize; i++)
            {
                if (castedOther.Results[i].Compare(Results[i]))
                {
                    return true;
                }
            }

            if (CacheTime != castedOther.CacheTime)
            {
                return true;
            }

            if (NextOffset != castedOther.NextOffset)
            {
                return true;
            }

            if (SwitchPm is null && castedOther.SwitchPm is not null || SwitchPm is not null && castedOther.SwitchPm is null)
            {
                return true;
            }

            if (SwitchPm is not null && castedOther.SwitchPm is not null && SwitchPm.Compare(castedOther.SwitchPm))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
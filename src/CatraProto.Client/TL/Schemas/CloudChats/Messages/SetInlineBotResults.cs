/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -346119674; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

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
            var newClonedObject = new SetInlineBotResults
            {
                Flags = Flags,
                Gallery = Gallery,
                Private = Private,
                QueryId = QueryId
            };
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
#nullable disable
    }
}
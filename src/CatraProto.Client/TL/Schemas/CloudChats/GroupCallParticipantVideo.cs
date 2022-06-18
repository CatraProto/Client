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
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class GroupCallParticipantVideo : CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Paused = 1 << 0,
            AudioSource = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1735736008; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("paused")]
        public sealed override bool Paused { get; set; }

        [Newtonsoft.Json.JsonProperty("endpoint")]
        public sealed override string Endpoint { get; set; }

        [Newtonsoft.Json.JsonProperty("source_groups")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoSourceGroupBase> SourceGroups { get; set; }

        [Newtonsoft.Json.JsonProperty("audio_source")]
        public sealed override int? AudioSource { get; set; }


#nullable enable
        public GroupCallParticipantVideo(string endpoint, List<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoSourceGroupBase> sourceGroups)
        {
            Endpoint = endpoint;
            SourceGroups = sourceGroups;

        }
#nullable disable
        internal GroupCallParticipantVideo()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Paused ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = AudioSource == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Endpoint);
            var checksourceGroups = writer.WriteVector(SourceGroups, false);
            if (checksourceGroups.IsError)
            {
                return checksourceGroups;
            }
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(AudioSource.Value);
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
            Paused = FlagsHelper.IsFlagSet(Flags, 0);
            var tryendpoint = reader.ReadString();
            if (tryendpoint.IsError)
            {
                return ReadResult<IObject>.Move(tryendpoint);
            }
            Endpoint = tryendpoint.Value;
            var trysourceGroups = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoSourceGroupBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trysourceGroups.IsError)
            {
                return ReadResult<IObject>.Move(trysourceGroups);
            }
            SourceGroups = trysourceGroups.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryaudioSource = reader.ReadInt32();
                if (tryaudioSource.IsError)
                {
                    return ReadResult<IObject>.Move(tryaudioSource);
                }
                AudioSource = tryaudioSource.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "groupCallParticipantVideo";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new GroupCallParticipantVideo
            {
                Flags = Flags,
                Paused = Paused,
                Endpoint = Endpoint,
                SourceGroups = new List<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoSourceGroupBase>()
            };
            foreach (var sourceGroups in SourceGroups)
            {
                var clonesourceGroups = (CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoSourceGroupBase?)sourceGroups.Clone();
                if (clonesourceGroups is null)
                {
                    return null;
                }
                newClonedObject.SourceGroups.Add(clonesourceGroups);
            }
            newClonedObject.AudioSource = AudioSource;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not GroupCallParticipantVideo castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (Paused != castedOther.Paused)
            {
                return true;
            }
            if (Endpoint != castedOther.Endpoint)
            {
                return true;
            }
            var sourceGroupssize = castedOther.SourceGroups.Count;
            if (sourceGroupssize != SourceGroups.Count)
            {
                return true;
            }
            for (var i = 0; i < sourceGroupssize; i++)
            {
                if (castedOther.SourceGroups[i].Compare(SourceGroups[i]))
                {
                    return true;
                }
            }
            if (AudioSource != castedOther.AudioSource)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
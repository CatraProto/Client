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
    public partial class PhoneCallProtocol : CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase
    {
        [Flags]
        public enum FlagsEnum
        {
            UdpP2p = 1 << 0,
            UdpReflector = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -58224696; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("udp_p2p")]
        public sealed override bool UdpP2p { get; set; }

        [Newtonsoft.Json.JsonProperty("udp_reflector")]
        public sealed override bool UdpReflector { get; set; }

        [Newtonsoft.Json.JsonProperty("min_layer")]
        public sealed override int MinLayer { get; set; }

        [Newtonsoft.Json.JsonProperty("max_layer")]
        public sealed override int MaxLayer { get; set; }

        [Newtonsoft.Json.JsonProperty("library_versions")]
        public sealed override List<string> LibraryVersions { get; set; }


#nullable enable
        public PhoneCallProtocol(int minLayer, int maxLayer, List<string> libraryVersions)
        {
            MinLayer = minLayer;
            MaxLayer = maxLayer;
            LibraryVersions = libraryVersions;

        }
#nullable disable
        internal PhoneCallProtocol()
        {
        }

        public override void UpdateFlags()
        {
            Flags = UdpP2p ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = UdpReflector ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(MinLayer);
            writer.WriteInt32(MaxLayer);

            writer.WriteVector(LibraryVersions, false);

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
            UdpP2p = FlagsHelper.IsFlagSet(Flags, 0);
            UdpReflector = FlagsHelper.IsFlagSet(Flags, 1);
            var tryminLayer = reader.ReadInt32();
            if (tryminLayer.IsError)
            {
                return ReadResult<IObject>.Move(tryminLayer);
            }
            MinLayer = tryminLayer.Value;
            var trymaxLayer = reader.ReadInt32();
            if (trymaxLayer.IsError)
            {
                return ReadResult<IObject>.Move(trymaxLayer);
            }
            MaxLayer = trymaxLayer.Value;
            var trylibraryVersions = reader.ReadVector<string>(ParserTypes.String, nakedVector: false, nakedObjects: false);
            if (trylibraryVersions.IsError)
            {
                return ReadResult<IObject>.Move(trylibraryVersions);
            }
            LibraryVersions = trylibraryVersions.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "phoneCallProtocol";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PhoneCallProtocol
            {
                Flags = Flags,
                UdpP2p = UdpP2p,
                UdpReflector = UdpReflector,
                MinLayer = MinLayer,
                MaxLayer = MaxLayer,
                LibraryVersions = new List<string>()
            };
            foreach (var libraryVersions in LibraryVersions)
            {
                newClonedObject.LibraryVersions.Add(libraryVersions);
            }
            return newClonedObject;

        }
#nullable disable
    }
}
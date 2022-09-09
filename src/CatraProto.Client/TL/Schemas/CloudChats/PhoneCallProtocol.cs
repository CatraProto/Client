using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -58224696; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

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
            var newClonedObject = new PhoneCallProtocol();
            newClonedObject.Flags = Flags;
            newClonedObject.UdpP2p = UdpP2p;
            newClonedObject.UdpReflector = UdpReflector;
            newClonedObject.MinLayer = MinLayer;
            newClonedObject.MaxLayer = MaxLayer;
            newClonedObject.LibraryVersions = new List<string>();
            foreach (var libraryVersions in LibraryVersions)
            {
                newClonedObject.LibraryVersions.Add(libraryVersions);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PhoneCallProtocol castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (UdpP2p != castedOther.UdpP2p)
            {
                return true;
            }

            if (UdpReflector != castedOther.UdpReflector)
            {
                return true;
            }

            if (MinLayer != castedOther.MinLayer)
            {
                return true;
            }

            if (MaxLayer != castedOther.MaxLayer)
            {
                return true;
            }

            var libraryVersionssize = castedOther.LibraryVersions.Count;
            if (libraryVersionssize != LibraryVersions.Count)
            {
                return true;
            }

            for (var i = 0; i < libraryVersionssize; i++)
            {
                if (castedOther.LibraryVersions[i] != LibraryVersions[i])
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}
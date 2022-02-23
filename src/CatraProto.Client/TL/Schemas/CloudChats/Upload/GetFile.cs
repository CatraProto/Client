using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
    public partial class GetFile : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Precise = 1 << 0,
            CdnSupported = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1319462148;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Upload.FileBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("precise")]
        public bool Precise { get; set; }

        [Newtonsoft.Json.JsonProperty("cdn_supported")]
        public bool CdnSupported { get; set; }

        [Newtonsoft.Json.JsonProperty("location")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase Location { get; set; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public int Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }


    #nullable enable
        public GetFile(CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase location, int offset, int limit)
        {
            Location = location;
            Offset = offset;
            Limit = limit;
        }
    #nullable disable

        internal GetFile()
        {
        }

        public void UpdateFlags()
        {
            Flags = Precise ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = CdnSupported ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Location);
            writer.Write(Offset);
            writer.Write(Limit);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Precise = FlagsHelper.IsFlagSet(Flags, 0);
            CdnSupported = FlagsHelper.IsFlagSet(Flags, 1);
            Location = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase>();
            Offset = reader.Read<int>();
            Limit = reader.Read<int>();
        }

        public override string ToString()
        {
            return "upload.getFile";
        }
    }
}
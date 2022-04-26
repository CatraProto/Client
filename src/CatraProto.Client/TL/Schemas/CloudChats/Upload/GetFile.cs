using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

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
        public static int ConstructorId { get => -1319462148; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

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

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checklocation = writer.WriteObject(Location);
            if (checklocation.IsError)
            {
                return checklocation;
            }
            writer.WriteInt32(Offset);
            writer.WriteInt32(Limit);

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
            Precise = FlagsHelper.IsFlagSet(Flags, 0);
            CdnSupported = FlagsHelper.IsFlagSet(Flags, 1);
            var trylocation = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase>();
            if (trylocation.IsError)
            {
                return ReadResult<IObject>.Move(trylocation);
            }
            Location = trylocation.Value;
            var tryoffset = reader.ReadInt32();
            if (tryoffset.IsError)
            {
                return ReadResult<IObject>.Move(tryoffset);
            }
            Offset = tryoffset.Value;
            var trylimit = reader.ReadInt32();
            if (trylimit.IsError)
            {
                return ReadResult<IObject>.Move(trylimit);
            }
            Limit = trylimit.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "upload.getFile";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetFile
            {
                Flags = Flags,
                Precise = Precise,
                CdnSupported = CdnSupported
            };
            var cloneLocation = (CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase?)Location.Clone();
            if (cloneLocation is null)
            {
                return null;
            }
            newClonedObject.Location = cloneLocation;
            newClonedObject.Offset = Offset;
            newClonedObject.Limit = Limit;
            return newClonedObject;

        }
#nullable disable
    }
}
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class LangPackDifference : CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -209337866; }

        [Newtonsoft.Json.JsonProperty("lang_code")]
        public sealed override string LangCode { get; set; }

        [Newtonsoft.Json.JsonProperty("from_version")]
        public sealed override int FromVersion { get; set; }

        [Newtonsoft.Json.JsonProperty("version")]
        public sealed override int Version { get; set; }

        [Newtonsoft.Json.JsonProperty("strings")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase> Strings { get; set; }


#nullable enable
        public LangPackDifference(string langCode, int fromVersion, int version, List<CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase> strings)
        {
            LangCode = langCode;
            FromVersion = fromVersion;
            Version = version;
            Strings = strings;

        }
#nullable disable
        internal LangPackDifference()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(LangCode);
            writer.WriteInt32(FromVersion);
            writer.WriteInt32(Version);
            var checkstrings = writer.WriteVector(Strings, false);
            if (checkstrings.IsError)
            {
                return checkstrings;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trylangCode = reader.ReadString();
            if (trylangCode.IsError)
            {
                return ReadResult<IObject>.Move(trylangCode);
            }
            LangCode = trylangCode.Value;
            var tryfromVersion = reader.ReadInt32();
            if (tryfromVersion.IsError)
            {
                return ReadResult<IObject>.Move(tryfromVersion);
            }
            FromVersion = tryfromVersion.Value;
            var tryversion = reader.ReadInt32();
            if (tryversion.IsError)
            {
                return ReadResult<IObject>.Move(tryversion);
            }
            Version = tryversion.Value;
            var trystrings = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trystrings.IsError)
            {
                return ReadResult<IObject>.Move(trystrings);
            }
            Strings = trystrings.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "langPackDifference";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new LangPackDifference
            {
                LangCode = LangCode,
                FromVersion = FromVersion,
                Version = Version
            };
            foreach (var strings in Strings)
            {
                var clonestrings = (CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase?)strings.Clone();
                if (clonestrings is null)
                {
                    return null;
                }
                newClonedObject.Strings.Add(clonestrings);
            }
            return newClonedObject;

        }
#nullable disable
    }
}
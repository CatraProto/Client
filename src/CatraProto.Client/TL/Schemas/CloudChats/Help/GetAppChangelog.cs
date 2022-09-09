using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class GetAppChangelog : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1877938321; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("prev_app_version")]
        public string PrevAppVersion { get; set; }


#nullable enable
        public GetAppChangelog(string prevAppVersion)
        {
            PrevAppVersion = prevAppVersion;
        }
#nullable disable

        internal GetAppChangelog()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(PrevAppVersion);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryprevAppVersion = reader.ReadString();
            if (tryprevAppVersion.IsError)
            {
                return ReadResult<IObject>.Move(tryprevAppVersion);
            }

            PrevAppVersion = tryprevAppVersion.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "help.getAppChangelog";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetAppChangelog();
            newClonedObject.PrevAppVersion = PrevAppVersion;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetAppChangelog castedOther)
            {
                return true;
            }

            if (PrevAppVersion != castedOther.PrevAppVersion)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
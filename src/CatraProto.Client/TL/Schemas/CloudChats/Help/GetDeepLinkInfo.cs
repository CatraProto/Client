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
    public partial class GetDeepLinkInfo : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1072547679; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("path")] public string Path { get; set; }


#nullable enable
        public GetDeepLinkInfo(string path)
        {
            Path = path;
        }
#nullable disable

        internal GetDeepLinkInfo()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Path);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypath = reader.ReadString();
            if (trypath.IsError)
            {
                return ReadResult<IObject>.Move(trypath);
            }

            Path = trypath.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "help.getDeepLinkInfo";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetDeepLinkInfo();
            newClonedObject.Path = Path;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetDeepLinkInfo castedOther)
            {
                return true;
            }

            if (Path != castedOther.Path)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
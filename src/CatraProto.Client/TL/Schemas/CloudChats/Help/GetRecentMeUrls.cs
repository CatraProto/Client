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
    public partial class GetRecentMeUrls : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1036054804; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("referer")]
        public string Referer { get; set; }


#nullable enable
        public GetRecentMeUrls(string referer)
        {
            Referer = referer;
        }
#nullable disable

        internal GetRecentMeUrls()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Referer);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryreferer = reader.ReadString();
            if (tryreferer.IsError)
            {
                return ReadResult<IObject>.Move(tryreferer);
            }

            Referer = tryreferer.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "help.getRecentMeUrls";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetRecentMeUrls();
            newClonedObject.Referer = Referer;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetRecentMeUrls castedOther)
            {
                return true;
            }

            if (Referer != castedOther.Referer)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
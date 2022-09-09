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
    public partial class GetAppUpdate : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1378703997; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("source")]
        public string Source { get; set; }


#nullable enable
        public GetAppUpdate(string source)
        {
            Source = source;
        }
#nullable disable

        internal GetAppUpdate()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Source);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysource = reader.ReadString();
            if (trysource.IsError)
            {
                return ReadResult<IObject>.Move(trysource);
            }

            Source = trysource.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "help.getAppUpdate";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetAppUpdate();
            newClonedObject.Source = Source;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetAppUpdate castedOther)
            {
                return true;
            }

            if (Source != castedOther.Source)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
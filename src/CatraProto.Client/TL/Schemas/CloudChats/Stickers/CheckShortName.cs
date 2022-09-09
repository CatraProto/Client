using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
    public partial class CheckShortName : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 676017721; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("short_name")]
        public string ShortName { get; set; }


#nullable enable
        public CheckShortName(string shortName)
        {
            ShortName = shortName;
        }
#nullable disable

        internal CheckShortName()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(ShortName);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryshortName = reader.ReadString();
            if (tryshortName.IsError)
            {
                return ReadResult<IObject>.Move(tryshortName);
            }

            ShortName = tryshortName.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "stickers.checkShortName";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new CheckShortName();
            newClonedObject.ShortName = ShortName;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not CheckShortName castedOther)
            {
                return true;
            }

            if (ShortName != castedOther.ShortName)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
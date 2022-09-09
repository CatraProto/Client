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
    public partial class SuggestShortName : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1303364867; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }


#nullable enable
        public SuggestShortName(string title)
        {
            Title = title;
        }
#nullable disable

        internal SuggestShortName()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Title);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }

            Title = trytitle.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "stickers.suggestShortName";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SuggestShortName();
            newClonedObject.Title = Title;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SuggestShortName castedOther)
            {
                return true;
            }

            if (Title != castedOther.Title)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
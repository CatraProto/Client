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
    public partial class BotMenuButton : CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -944407322; }

        [Newtonsoft.Json.JsonProperty("text")] public string Text { get; set; }

        [Newtonsoft.Json.JsonProperty("url")] public string Url { get; set; }


#nullable enable
        public BotMenuButton(string text, string url)
        {
            Text = text;
            Url = url;
        }
#nullable disable
        internal BotMenuButton()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Text);

            writer.WriteString(Url);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytext = reader.ReadString();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }

            Text = trytext.Value;
            var tryurl = reader.ReadString();
            if (tryurl.IsError)
            {
                return ReadResult<IObject>.Move(tryurl);
            }

            Url = tryurl.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "botMenuButton";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BotMenuButton();
            newClonedObject.Text = Text;
            newClonedObject.Url = Url;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not BotMenuButton castedOther)
            {
                return true;
            }

            if (Text != castedOther.Text)
            {
                return true;
            }

            if (Url != castedOther.Url)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
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
    public partial class MessageActionWebViewDataSentMe : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1205698681; }

        [Newtonsoft.Json.JsonProperty("text")] public string Text { get; set; }

        [Newtonsoft.Json.JsonProperty("data")] public string Data { get; set; }


#nullable enable
        public MessageActionWebViewDataSentMe(string text, string data)
        {
            Text = text;
            Data = data;
        }
#nullable disable
        internal MessageActionWebViewDataSentMe()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Text);

            writer.WriteString(Data);

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
            var trydata = reader.ReadString();
            if (trydata.IsError)
            {
                return ReadResult<IObject>.Move(trydata);
            }

            Data = trydata.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageActionWebViewDataSentMe";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageActionWebViewDataSentMe();
            newClonedObject.Text = Text;
            newClonedObject.Data = Data;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageActionWebViewDataSentMe castedOther)
            {
                return true;
            }

            if (Text != castedOther.Text)
            {
                return true;
            }

            if (Data != castedOther.Data)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
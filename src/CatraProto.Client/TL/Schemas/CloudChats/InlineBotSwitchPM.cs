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
    public partial class InlineBotSwitchPM : CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPMBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1008755359; }

        [Newtonsoft.Json.JsonProperty("text")] public sealed override string Text { get; set; }

        [Newtonsoft.Json.JsonProperty("start_param")]
        public sealed override string StartParam { get; set; }


#nullable enable
        public InlineBotSwitchPM(string text, string startParam)
        {
            Text = text;
            StartParam = startParam;
        }
#nullable disable
        internal InlineBotSwitchPM()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Text);

            writer.WriteString(StartParam);

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
            var trystartParam = reader.ReadString();
            if (trystartParam.IsError)
            {
                return ReadResult<IObject>.Move(trystartParam);
            }

            StartParam = trystartParam.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inlineBotSwitchPM";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InlineBotSwitchPM();
            newClonedObject.Text = Text;
            newClonedObject.StartParam = StartParam;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InlineBotSwitchPM castedOther)
            {
                return true;
            }

            if (Text != castedOther.Text)
            {
                return true;
            }

            if (StartParam != castedOther.StartParam)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
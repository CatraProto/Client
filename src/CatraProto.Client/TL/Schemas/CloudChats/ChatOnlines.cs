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
    public partial class ChatOnlines : CatraProto.Client.TL.Schemas.CloudChats.ChatOnlinesBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -264117680; }

        [Newtonsoft.Json.JsonProperty("onlines")]
        public sealed override int Onlines { get; set; }


#nullable enable
        public ChatOnlines(int onlines)
        {
            Onlines = onlines;
        }
#nullable disable
        internal ChatOnlines()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Onlines);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryonlines = reader.ReadInt32();
            if (tryonlines.IsError)
            {
                return ReadResult<IObject>.Move(tryonlines);
            }

            Onlines = tryonlines.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "chatOnlines";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatOnlines();
            newClonedObject.Onlines = Onlines;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChatOnlines castedOther)
            {
                return true;
            }

            if (Onlines != castedOther.Onlines)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
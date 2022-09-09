using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SetDefaultReaction : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -647969580; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("reaction")]
        public string Reaction { get; set; }


#nullable enable
        public SetDefaultReaction(string reaction)
        {
            Reaction = reaction;
        }
#nullable disable

        internal SetDefaultReaction()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Reaction);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryreaction = reader.ReadString();
            if (tryreaction.IsError)
            {
                return ReadResult<IObject>.Move(tryreaction);
            }

            Reaction = tryreaction.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.setDefaultReaction";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetDefaultReaction();
            newClonedObject.Reaction = Reaction;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SetDefaultReaction castedOther)
            {
                return true;
            }

            if (Reaction != castedOther.Reaction)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
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
    public partial class BotCommand : CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1032140601; }

        [Newtonsoft.Json.JsonProperty("command")]
        public sealed override string Command { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public sealed override string Description { get; set; }


#nullable enable
        public BotCommand(string command, string description)
        {
            Command = command;
            Description = description;
        }
#nullable disable
        internal BotCommand()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Command);

            writer.WriteString(Description);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycommand = reader.ReadString();
            if (trycommand.IsError)
            {
                return ReadResult<IObject>.Move(trycommand);
            }

            Command = trycommand.Value;
            var trydescription = reader.ReadString();
            if (trydescription.IsError)
            {
                return ReadResult<IObject>.Move(trydescription);
            }

            Description = trydescription.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "botCommand";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BotCommand();
            newClonedObject.Command = Command;
            newClonedObject.Description = Description;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not BotCommand castedOther)
            {
                return true;
            }

            if (Command != castedOther.Command)
            {
                return true;
            }

            if (Description != castedOther.Description)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class BotInfo : CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -468280483; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public sealed override string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("commands")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> Commands { get; set; }

        [Newtonsoft.Json.JsonProperty("menu_button")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase MenuButton { get; set; }


#nullable enable
        public BotInfo(long userId, string description, List<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> commands, CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase menuButton)
        {
            UserId = userId;
            Description = description;
            Commands = commands;
            MenuButton = menuButton;

        }
#nullable disable
        internal BotInfo()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);

            writer.WriteString(Description);
            var checkcommands = writer.WriteVector(Commands, false);
            if (checkcommands.IsError)
            {
                return checkcommands;
            }
            var checkmenuButton = writer.WriteObject(MenuButton);
            if (checkmenuButton.IsError)
            {
                return checkmenuButton;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }
            UserId = tryuserId.Value;
            var trydescription = reader.ReadString();
            if (trydescription.IsError)
            {
                return ReadResult<IObject>.Move(trydescription);
            }
            Description = trydescription.Value;
            var trycommands = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trycommands.IsError)
            {
                return ReadResult<IObject>.Move(trycommands);
            }
            Commands = trycommands.Value;
            var trymenuButton = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase>();
            if (trymenuButton.IsError)
            {
                return ReadResult<IObject>.Move(trymenuButton);
            }
            MenuButton = trymenuButton.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "botInfo";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BotInfo
            {
                UserId = UserId,
                Description = Description,
                Commands = new List<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase>()
            };
            foreach (var commands in Commands)
            {
                var clonecommands = (CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase?)commands.Clone();
                if (clonecommands is null)
                {
                    return null;
                }
                newClonedObject.Commands.Add(clonecommands);
            }
            var cloneMenuButton = (CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase?)MenuButton.Clone();
            if (cloneMenuButton is null)
            {
                return null;
            }
            newClonedObject.MenuButton = cloneMenuButton;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not BotInfo castedOther)
            {
                return true;
            }
            if (UserId != castedOther.UserId)
            {
                return true;
            }
            if (Description != castedOther.Description)
            {
                return true;
            }
            var commandssize = castedOther.Commands.Count;
            if (commandssize != Commands.Count)
            {
                return true;
            }
            for (var i = 0; i < commandssize; i++)
            {
                if (castedOther.Commands[i].Compare(Commands[i]))
                {
                    return true;
                }
            }
            if (MenuButton.Compare(castedOther.MenuButton))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
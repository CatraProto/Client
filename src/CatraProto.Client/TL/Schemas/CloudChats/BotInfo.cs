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
        public static int ConstructorId { get => 460632885; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public sealed override string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("commands")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> Commands { get; set; }


#nullable enable
        public BotInfo(long userId, string description, List<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> commands)
        {
            UserId = userId;
            Description = description;
            Commands = commands;

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
                Description = Description
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
            return newClonedObject;

        }
#nullable disable
    }
}
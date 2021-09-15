using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
    public partial class SetBotCommands : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -2141370634;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("commands")] public IList<BotCommandBase> Commands { get; set; }

        public override string ToString()
        {
            return "bots.setBotCommands";
        }


        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Commands);
        }

        public void Deserialize(Reader reader)
        {
            Commands = reader.ReadVector<BotCommandBase>();
        }
    }
}
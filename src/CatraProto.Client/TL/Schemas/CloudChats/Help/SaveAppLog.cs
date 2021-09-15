using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class SaveAppLog : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1862465352;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("events")] public IList<InputAppEventBase> Events { get; set; }

        public override string ToString()
        {
            return "help.saveAppLog";
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

            writer.Write(Events);
        }

        public void Deserialize(Reader reader)
        {
            Events = reader.ReadVector<InputAppEventBase>();
        }
    }
}
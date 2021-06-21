using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class SaveAppLog : IMethod
    {
        public static int ConstructorId { get; } = 1862465352;
        public IList<InputAppEventBase> Events { get; set; }

        public Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Events);
        }

        public void Deserialize(Reader reader)
        {
            Events = reader.ReadVector<InputAppEventBase>();
        }
    }
}
using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class GetAppChangelog : IMethod<UpdatesBase>
    {
        public static int ConstructorId { get; } = -1877938321;
        public string PrevAppVersion { get; set; }

        public Type Type { get; init; } = typeof(GetAppChangelog);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(PrevAppVersion);
        }

        public void Deserialize(Reader reader)
        {
            PrevAppVersion = reader.Read<string>();
        }
    }
}
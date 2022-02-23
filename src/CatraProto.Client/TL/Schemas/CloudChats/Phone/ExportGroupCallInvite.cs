using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class ExportGroupCallInvite : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            CanSelfUnmute = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -425040769;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Phone.ExportedGroupCallInviteBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("can_self_unmute")]
        public bool CanSelfUnmute { get; set; }

        [Newtonsoft.Json.JsonProperty("call")] public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }


    #nullable enable
        public ExportGroupCallInvite(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call)
        {
            Call = call;
        }
    #nullable disable

        internal ExportGroupCallInvite()
        {
        }

        public void UpdateFlags()
        {
            Flags = CanSelfUnmute ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Call);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            CanSelfUnmute = FlagsHelper.IsFlagSet(Flags, 0);
            Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
        }

        public override string ToString()
        {
            return "phone.exportGroupCallInvite";
        }
    }
}
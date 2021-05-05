using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class GetLocated : IMethod<UpdatesBase>
    {
        [Flags]
        public enum FlagsEnum
        {
            Background = 1 << 1,
            SelfExpires = 1 << 0
        }

        public static int ConstructorId { get; } = -750207932;
        public int Flags { get; set; }
        public bool Background { get; set; }
        public InputGeoPointBase GeoPoint { get; set; }
        public int? SelfExpires { get; set; }

        public Type Type { get; init; } = typeof(GetLocated);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
            Flags = Background ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = SelfExpires == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(GeoPoint);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(SelfExpires.Value);
            }
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Background = FlagsHelper.IsFlagSet(Flags, 1);
            GeoPoint = reader.Read<InputGeoPointBase>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                SelfExpires = reader.Read<int>();
            }
        }
    }
}
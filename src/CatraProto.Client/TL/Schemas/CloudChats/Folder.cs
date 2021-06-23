using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class Folder : FolderBase
    {
        [Flags]
        public enum FlagsEnum
        {
            AutofillNewBroadcasts = 1 << 0,
            AutofillPublicGroups = 1 << 1,
            AutofillNewCorrespondents = 1 << 2,
            Photo = 1 << 3
        }

        public static int ConstructorId { get; } = -11252123;
        public int Flags { get; set; }
        public override bool AutofillNewBroadcasts { get; set; }
        public override bool AutofillPublicGroups { get; set; }
        public override bool AutofillNewCorrespondents { get; set; }
        public override int Id { get; set; }
        public override string Title { get; set; }
        public override ChatPhotoBase Photo { get; set; }

        public override void UpdateFlags()
        {
            Flags = AutofillNewBroadcasts ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = AutofillPublicGroups ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = AutofillNewCorrespondents ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = Photo == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            writer.Write(Title);
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.Write(Photo);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            AutofillNewBroadcasts = FlagsHelper.IsFlagSet(Flags, 0);
            AutofillPublicGroups = FlagsHelper.IsFlagSet(Flags, 1);
            AutofillNewCorrespondents = FlagsHelper.IsFlagSet(Flags, 2);
            Id = reader.Read<int>();
            Title = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                Photo = reader.Read<ChatPhotoBase>();
            }
        }
    }
}
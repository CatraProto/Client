using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateShortSentMessage : UpdatesBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Out = 1 << 1,
            Media = 1 << 9,
            Entities = 1 << 7
        }

        public static int ConstructorId { get; } = 301019932;
        public int Flags { get; set; }
        public bool Out { get; set; }
        public int Id { get; set; }
        public int Pts { get; set; }
        public int PtsCount { get; set; }
        public int Date { get; set; }
        public MessageMediaBase Media { get; set; }
        public IList<MessageEntityBase> Entities { get; set; }

        public override void UpdateFlags()
        {
            Flags = Out ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Media == null ? FlagsHelper.UnsetFlag(Flags, 9) : FlagsHelper.SetFlag(Flags, 9);
            Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 7) : FlagsHelper.SetFlag(Flags, 7);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            writer.Write(Pts);
            writer.Write(PtsCount);
            writer.Write(Date);
            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                writer.Write(Media);
            }

            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                writer.Write(Entities);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Out = FlagsHelper.IsFlagSet(Flags, 1);
            Id = reader.Read<int>();
            Pts = reader.Read<int>();
            PtsCount = reader.Read<int>();
            Date = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                Media = reader.Read<MessageMediaBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                Entities = reader.ReadVector<MessageEntityBase>();
            }
        }
    }
}
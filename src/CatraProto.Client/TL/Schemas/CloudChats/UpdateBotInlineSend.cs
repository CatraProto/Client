using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class UpdateBotInlineSend : UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Geo = 1 << 0,
            MsgId = 1 << 1
        }

        public static int ConstructorId { get; } = 239663460;
        public int Flags { get; set; }
        public int UserId { get; set; }
        public string Query { get; set; }
        public GeoPointBase Geo { get; set; }
        public string Id { get; set; }
        public InputBotInlineMessageIDBase MsgId { get; set; }

        public override void UpdateFlags()
        {
            Flags = Geo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = MsgId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(UserId);
            writer.Write(Query);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Geo);
            }

            writer.Write(Id);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(MsgId);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            UserId = reader.Read<int>();
            Query = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Geo = reader.Read<GeoPointBase>();
            }

            Id = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                MsgId = reader.Read<InputBotInlineMessageIDBase>();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class HistoryImportParsed : CatraProto.Client.TL.Schemas.CloudChats.Messages.HistoryImportParsedBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Pm = 1 << 0,
            Group = 1 << 1,
            Title = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1578088377; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("pm")] public sealed override bool Pm { get; set; }

        [Newtonsoft.Json.JsonProperty("group")]
        public sealed override bool Group { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("title")]
        public sealed override string Title { get; set; }


        public HistoryImportParsed()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Pm ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Group ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteString(Title);
            }


            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            Pm = FlagsHelper.IsFlagSet(Flags, 0);
            Group = FlagsHelper.IsFlagSet(Flags, 1);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trytitle = reader.ReadString();
                if (trytitle.IsError)
                {
                    return ReadResult<IObject>.Move(trytitle);
                }

                Title = trytitle.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.historyImportParsed";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new HistoryImportParsed();
            newClonedObject.Flags = Flags;
            newClonedObject.Pm = Pm;
            newClonedObject.Group = Group;
            newClonedObject.Title = Title;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not HistoryImportParsed castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Pm != castedOther.Pm)
            {
                return true;
            }

            if (Group != castedOther.Group)
            {
                return true;
            }

            if (Title != castedOther.Title)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
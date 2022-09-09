using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class BotInfo : CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase
    {
        [Flags]
        public enum FlagsEnum
        {
            UserId = 1 << 0,
            Description = 1 << 1,
            DescriptionPhoto = 1 << 4,
            DescriptionDocument = 1 << 5,
            Commands = 1 << 2,
            MenuButton = 1 << 3
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1892676777; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long? UserId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("description")]
        public sealed override string Description { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("description_photo")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PhotoBase DescriptionPhoto { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("description_document")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.DocumentBase DescriptionDocument { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("commands")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> Commands { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("menu_button")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase MenuButton { get; set; }


        public BotInfo()
        {
        }

        public override void UpdateFlags()
        {
            Flags = UserId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Description == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = DescriptionPhoto == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = DescriptionDocument == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
            Flags = Commands == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = MenuButton == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt64(UserId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(Description);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var checkdescriptionPhoto = writer.WriteObject(DescriptionPhoto);
                if (checkdescriptionPhoto.IsError)
                {
                    return checkdescriptionPhoto;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var checkdescriptionDocument = writer.WriteObject(DescriptionDocument);
                if (checkdescriptionDocument.IsError)
                {
                    return checkdescriptionDocument;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checkcommands = writer.WriteVector(Commands, false);
                if (checkcommands.IsError)
                {
                    return checkcommands;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var checkmenuButton = writer.WriteObject(MenuButton);
                if (checkmenuButton.IsError)
                {
                    return checkmenuButton;
                }
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
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryuserId = reader.ReadInt64();
                if (tryuserId.IsError)
                {
                    return ReadResult<IObject>.Move(tryuserId);
                }

                UserId = tryuserId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trydescription = reader.ReadString();
                if (trydescription.IsError)
                {
                    return ReadResult<IObject>.Move(trydescription);
                }

                Description = trydescription.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var trydescriptionPhoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
                if (trydescriptionPhoto.IsError)
                {
                    return ReadResult<IObject>.Move(trydescriptionPhoto);
                }

                DescriptionPhoto = trydescriptionPhoto.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var trydescriptionDocument = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
                if (trydescriptionDocument.IsError)
                {
                    return ReadResult<IObject>.Move(trydescriptionDocument);
                }

                DescriptionDocument = trydescriptionDocument.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trycommands = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (trycommands.IsError)
                {
                    return ReadResult<IObject>.Move(trycommands);
                }

                Commands = trycommands.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var trymenuButton = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase>();
                if (trymenuButton.IsError)
                {
                    return ReadResult<IObject>.Move(trymenuButton);
                }

                MenuButton = trymenuButton.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "botInfo";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BotInfo();
            newClonedObject.Flags = Flags;
            newClonedObject.UserId = UserId;
            newClonedObject.Description = Description;
            if (DescriptionPhoto is not null)
            {
                var cloneDescriptionPhoto = (CatraProto.Client.TL.Schemas.CloudChats.PhotoBase?)DescriptionPhoto.Clone();
                if (cloneDescriptionPhoto is null)
                {
                    return null;
                }

                newClonedObject.DescriptionPhoto = cloneDescriptionPhoto;
            }

            if (DescriptionDocument is not null)
            {
                var cloneDescriptionDocument = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)DescriptionDocument.Clone();
                if (cloneDescriptionDocument is null)
                {
                    return null;
                }

                newClonedObject.DescriptionDocument = cloneDescriptionDocument;
            }

            if (Commands is not null)
            {
                newClonedObject.Commands = new List<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase>();
                foreach (var commands in Commands)
                {
                    var clonecommands = (CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase?)commands.Clone();
                    if (clonecommands is null)
                    {
                        return null;
                    }

                    newClonedObject.Commands.Add(clonecommands);
                }
            }

            if (MenuButton is not null)
            {
                var cloneMenuButton = (CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase?)MenuButton.Clone();
                if (cloneMenuButton is null)
                {
                    return null;
                }

                newClonedObject.MenuButton = cloneMenuButton;
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not BotInfo castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            if (Description != castedOther.Description)
            {
                return true;
            }

            if (DescriptionPhoto is null && castedOther.DescriptionPhoto is not null || DescriptionPhoto is not null && castedOther.DescriptionPhoto is null)
            {
                return true;
            }

            if (DescriptionPhoto is not null && castedOther.DescriptionPhoto is not null && DescriptionPhoto.Compare(castedOther.DescriptionPhoto))
            {
                return true;
            }

            if (DescriptionDocument is null && castedOther.DescriptionDocument is not null || DescriptionDocument is not null && castedOther.DescriptionDocument is null)
            {
                return true;
            }

            if (DescriptionDocument is not null && castedOther.DescriptionDocument is not null && DescriptionDocument.Compare(castedOther.DescriptionDocument))
            {
                return true;
            }

            if (Commands is null && castedOther.Commands is not null || Commands is not null && castedOther.Commands is null)
            {
                return true;
            }

            if (Commands is not null && castedOther.Commands is not null)
            {
                var commandssize = castedOther.Commands.Count;
                if (commandssize != Commands.Count)
                {
                    return true;
                }

                for (var i = 0; i < commandssize; i++)
                {
                    if (castedOther.Commands[i].Compare(Commands[i]))
                    {
                        return true;
                    }
                }
            }

            if (MenuButton is null && castedOther.MenuButton is not null || MenuButton is not null && castedOther.MenuButton is null)
            {
                return true;
            }

            if (MenuButton is not null && castedOther.MenuButton is not null && MenuButton.Compare(castedOther.MenuButton))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
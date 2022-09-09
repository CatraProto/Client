using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class InstallTheme : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Dark = 1 << 0,
            Theme = 1 << 1,
            Format = 1 << 2,
            BaseTheme = 1 << 3
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -953697477; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("dark")] public bool Dark { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("theme")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase Theme { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("format")]
        public string Format { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("base_theme")]
        public CatraProto.Client.TL.Schemas.CloudChats.BaseThemeBase BaseTheme { get; set; }


        public InstallTheme()
        {
        }

        public void UpdateFlags()
        {
            Flags = Dark ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Theme == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Format == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = BaseTheme == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checktheme = writer.WriteObject(Theme);
                if (checktheme.IsError)
                {
                    return checktheme;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteString(Format);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var checkbaseTheme = writer.WriteObject(BaseTheme);
                if (checkbaseTheme.IsError)
                {
                    return checkbaseTheme;
                }
            }


            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            Dark = FlagsHelper.IsFlagSet(Flags, 0);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trytheme = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase>();
                if (trytheme.IsError)
                {
                    return ReadResult<IObject>.Move(trytheme);
                }

                Theme = trytheme.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryformat = reader.ReadString();
                if (tryformat.IsError)
                {
                    return ReadResult<IObject>.Move(tryformat);
                }

                Format = tryformat.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var trybaseTheme = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.BaseThemeBase>();
                if (trybaseTheme.IsError)
                {
                    return ReadResult<IObject>.Move(trybaseTheme);
                }

                BaseTheme = trybaseTheme.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.installTheme";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new InstallTheme();
            newClonedObject.Flags = Flags;
            newClonedObject.Dark = Dark;
            if (Theme is not null)
            {
                var cloneTheme = (CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase?)Theme.Clone();
                if (cloneTheme is null)
                {
                    return null;
                }

                newClonedObject.Theme = cloneTheme;
            }

            newClonedObject.Format = Format;
            if (BaseTheme is not null)
            {
                var cloneBaseTheme = (CatraProto.Client.TL.Schemas.CloudChats.BaseThemeBase?)BaseTheme.Clone();
                if (cloneBaseTheme is null)
                {
                    return null;
                }

                newClonedObject.BaseTheme = cloneBaseTheme;
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not InstallTheme castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Dark != castedOther.Dark)
            {
                return true;
            }

            if (Theme is null && castedOther.Theme is not null || Theme is not null && castedOther.Theme is null)
            {
                return true;
            }

            if (Theme is not null && castedOther.Theme is not null && Theme.Compare(castedOther.Theme))
            {
                return true;
            }

            if (Format != castedOther.Format)
            {
                return true;
            }

            if (BaseTheme is null && castedOther.BaseTheme is not null || BaseTheme is not null && castedOther.BaseTheme is null)
            {
                return true;
            }

            if (BaseTheme is not null && castedOther.BaseTheme is not null && BaseTheme.Compare(castedOther.BaseTheme))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
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
    public partial class AttachMenuBotIcon : CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Colors = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1297663893; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("name")] public sealed override string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("icon")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Icon { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("colors")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconColorBase> Colors { get; set; }


#nullable enable
        public AttachMenuBotIcon(string name, CatraProto.Client.TL.Schemas.CloudChats.DocumentBase icon)
        {
            Name = name;
            Icon = icon;
        }
#nullable disable
        internal AttachMenuBotIcon()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Colors == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Name);
            var checkicon = writer.WriteObject(Icon);
            if (checkicon.IsError)
            {
                return checkicon;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkcolors = writer.WriteVector(Colors, false);
                if (checkcolors.IsError)
                {
                    return checkcolors;
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
            var tryname = reader.ReadString();
            if (tryname.IsError)
            {
                return ReadResult<IObject>.Move(tryname);
            }

            Name = tryname.Value;
            var tryicon = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
            if (tryicon.IsError)
            {
                return ReadResult<IObject>.Move(tryicon);
            }

            Icon = tryicon.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trycolors = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconColorBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (trycolors.IsError)
                {
                    return ReadResult<IObject>.Move(trycolors);
                }

                Colors = trycolors.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "attachMenuBotIcon";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new AttachMenuBotIcon();
            newClonedObject.Flags = Flags;
            newClonedObject.Name = Name;
            var cloneIcon = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)Icon.Clone();
            if (cloneIcon is null)
            {
                return null;
            }

            newClonedObject.Icon = cloneIcon;
            if (Colors is not null)
            {
                newClonedObject.Colors = new List<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconColorBase>();
                foreach (var colors in Colors)
                {
                    var clonecolors = (CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconColorBase?)colors.Clone();
                    if (clonecolors is null)
                    {
                        return null;
                    }

                    newClonedObject.Colors.Add(clonecolors);
                }
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not AttachMenuBotIcon castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Name != castedOther.Name)
            {
                return true;
            }

            if (Icon.Compare(castedOther.Icon))
            {
                return true;
            }

            if (Colors is null && castedOther.Colors is not null || Colors is not null && castedOther.Colors is null)
            {
                return true;
            }

            if (Colors is not null && castedOther.Colors is not null)
            {
                var colorssize = castedOther.Colors.Count;
                if (colorssize != Colors.Count)
                {
                    return true;
                }

                for (var i = 0; i < colorssize; i++)
                {
                    if (castedOther.Colors[i].Compare(Colors[i]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

#nullable disable
    }
}
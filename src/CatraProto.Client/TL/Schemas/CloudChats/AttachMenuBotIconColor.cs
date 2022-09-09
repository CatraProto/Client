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
    public partial class AttachMenuBotIconColor : CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconColorBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1165423600; }

        [Newtonsoft.Json.JsonProperty("name")] public sealed override string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("color")]
        public sealed override int Color { get; set; }


#nullable enable
        public AttachMenuBotIconColor(string name, int color)
        {
            Name = name;
            Color = color;
        }
#nullable disable
        internal AttachMenuBotIconColor()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Name);
            writer.WriteInt32(Color);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryname = reader.ReadString();
            if (tryname.IsError)
            {
                return ReadResult<IObject>.Move(tryname);
            }

            Name = tryname.Value;
            var trycolor = reader.ReadInt32();
            if (trycolor.IsError)
            {
                return ReadResult<IObject>.Move(trycolor);
            }

            Color = trycolor.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "attachMenuBotIconColor";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new AttachMenuBotIconColor();
            newClonedObject.Name = Name;
            newClonedObject.Color = Color;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not AttachMenuBotIconColor castedOther)
            {
                return true;
            }

            if (Name != castedOther.Name)
            {
                return true;
            }

            if (Color != castedOther.Color)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
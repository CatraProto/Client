using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class SupportName : CatraProto.Client.TL.Schemas.CloudChats.Help.SupportNameBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1945767479; }

        [Newtonsoft.Json.JsonProperty("name")] public sealed override string Name { get; set; }


#nullable enable
        public SupportName(string name)
        {
            Name = name;
        }
#nullable disable
        internal SupportName()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Name);

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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "help.supportName";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SupportName();
            newClonedObject.Name = Name;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SupportName castedOther)
            {
                return true;
            }

            if (Name != castedOther.Name)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
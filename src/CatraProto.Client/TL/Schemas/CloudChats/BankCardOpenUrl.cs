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
    public partial class BankCardOpenUrl : CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrlBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -177732982; }

        [Newtonsoft.Json.JsonProperty("url")] public sealed override string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("name")] public sealed override string Name { get; set; }


#nullable enable
        public BankCardOpenUrl(string url, string name)
        {
            Url = url;
            Name = name;
        }
#nullable disable
        internal BankCardOpenUrl()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Url);

            writer.WriteString(Name);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryurl = reader.ReadString();
            if (tryurl.IsError)
            {
                return ReadResult<IObject>.Move(tryurl);
            }

            Url = tryurl.Value;
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
            return "bankCardOpenUrl";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BankCardOpenUrl();
            newClonedObject.Url = Url;
            newClonedObject.Name = Name;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not BankCardOpenUrl castedOther)
            {
                return true;
            }

            if (Url != castedOther.Url)
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
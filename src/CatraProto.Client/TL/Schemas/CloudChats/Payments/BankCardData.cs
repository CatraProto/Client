using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public partial class BankCardData : CatraProto.Client.TL.Schemas.CloudChats.Payments.BankCardDataBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1042605427; }

        [Newtonsoft.Json.JsonProperty("title")]
        public sealed override string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("open_urls")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrlBase> OpenUrls { get; set; }


#nullable enable
        public BankCardData(string title, List<CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrlBase> openUrls)
        {
            Title = title;
            OpenUrls = openUrls;
        }
#nullable disable
        internal BankCardData()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Title);
            var checkopenUrls = writer.WriteVector(OpenUrls, false);
            if (checkopenUrls.IsError)
            {
                return checkopenUrls;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }

            Title = trytitle.Value;
            var tryopenUrls = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrlBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryopenUrls.IsError)
            {
                return ReadResult<IObject>.Move(tryopenUrls);
            }

            OpenUrls = tryopenUrls.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "payments.bankCardData";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BankCardData();
            newClonedObject.Title = Title;
            newClonedObject.OpenUrls = new List<CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrlBase>();
            foreach (var openUrls in OpenUrls)
            {
                var cloneopenUrls = (CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrlBase?)openUrls.Clone();
                if (cloneopenUrls is null)
                {
                    return null;
                }

                newClonedObject.OpenUrls.Add(cloneopenUrls);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not BankCardData castedOther)
            {
                return true;
            }

            if (Title != castedOther.Title)
            {
                return true;
            }

            var openUrlssize = castedOther.OpenUrls.Count;
            if (openUrlssize != OpenUrls.Count)
            {
                return true;
            }

            for (var i = 0; i < openUrlssize; i++)
            {
                if (castedOther.OpenUrls[i].Compare(OpenUrls[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}
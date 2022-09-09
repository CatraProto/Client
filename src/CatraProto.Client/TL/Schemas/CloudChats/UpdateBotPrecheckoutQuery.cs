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
    public partial class UpdateBotPrecheckoutQuery : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Info = 1 << 0,
            ShippingOptionId = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1934976362; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("query_id")]
        public long QueryId { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("payload")]
        public byte[] Payload { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("info")]
        public CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase Info { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("shipping_option_id")]
        public string ShippingOptionId { get; set; }

        [Newtonsoft.Json.JsonProperty("currency")]
        public string Currency { get; set; }

        [Newtonsoft.Json.JsonProperty("total_amount")]
        public long TotalAmount { get; set; }


#nullable enable
        public UpdateBotPrecheckoutQuery(long queryId, long userId, byte[] payload, string currency, long totalAmount)
        {
            QueryId = queryId;
            UserId = userId;
            Payload = payload;
            Currency = currency;
            TotalAmount = totalAmount;
        }
#nullable disable
        internal UpdateBotPrecheckoutQuery()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Info == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = ShippingOptionId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(QueryId);
            writer.WriteInt64(UserId);

            writer.WriteBytes(Payload);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkinfo = writer.WriteObject(Info);
                if (checkinfo.IsError)
                {
                    return checkinfo;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(ShippingOptionId);
            }


            writer.WriteString(Currency);
            writer.WriteInt64(TotalAmount);

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
            var tryqueryId = reader.ReadInt64();
            if (tryqueryId.IsError)
            {
                return ReadResult<IObject>.Move(tryqueryId);
            }

            QueryId = tryqueryId.Value;
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            var trypayload = reader.ReadBytes();
            if (trypayload.IsError)
            {
                return ReadResult<IObject>.Move(trypayload);
            }

            Payload = trypayload.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryinfo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase>();
                if (tryinfo.IsError)
                {
                    return ReadResult<IObject>.Move(tryinfo);
                }

                Info = tryinfo.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryshippingOptionId = reader.ReadString();
                if (tryshippingOptionId.IsError)
                {
                    return ReadResult<IObject>.Move(tryshippingOptionId);
                }

                ShippingOptionId = tryshippingOptionId.Value;
            }

            var trycurrency = reader.ReadString();
            if (trycurrency.IsError)
            {
                return ReadResult<IObject>.Move(trycurrency);
            }

            Currency = trycurrency.Value;
            var trytotalAmount = reader.ReadInt64();
            if (trytotalAmount.IsError)
            {
                return ReadResult<IObject>.Move(trytotalAmount);
            }

            TotalAmount = trytotalAmount.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateBotPrecheckoutQuery";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateBotPrecheckoutQuery();
            newClonedObject.Flags = Flags;
            newClonedObject.QueryId = QueryId;
            newClonedObject.UserId = UserId;
            newClonedObject.Payload = Payload;
            if (Info is not null)
            {
                var cloneInfo = (CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase?)Info.Clone();
                if (cloneInfo is null)
                {
                    return null;
                }

                newClonedObject.Info = cloneInfo;
            }

            newClonedObject.ShippingOptionId = ShippingOptionId;
            newClonedObject.Currency = Currency;
            newClonedObject.TotalAmount = TotalAmount;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateBotPrecheckoutQuery castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (QueryId != castedOther.QueryId)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            if (Payload != castedOther.Payload)
            {
                return true;
            }

            if (Info is null && castedOther.Info is not null || Info is not null && castedOther.Info is null)
            {
                return true;
            }

            if (Info is not null && castedOther.Info is not null && Info.Compare(castedOther.Info))
            {
                return true;
            }

            if (ShippingOptionId != castedOther.ShippingOptionId)
            {
                return true;
            }

            if (Currency != castedOther.Currency)
            {
                return true;
            }

            if (TotalAmount != castedOther.TotalAmount)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
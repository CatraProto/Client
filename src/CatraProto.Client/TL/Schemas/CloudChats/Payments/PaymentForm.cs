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
    public partial class PaymentForm : CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentFormBase
    {
        [Flags]
        public enum FlagsEnum
        {
            CanSaveCredentials = 1 << 2,
            PasswordMissing = 1 << 3,
            Photo = 1 << 5,
            NativeProvider = 1 << 4,
            NativeParams = 1 << 4,
            SavedInfo = 1 << 0,
            SavedCredentials = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1340916937; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("can_save_credentials")]
        public sealed override bool CanSaveCredentials { get; set; }

        [Newtonsoft.Json.JsonProperty("password_missing")]
        public sealed override bool PasswordMissing { get; set; }

        [Newtonsoft.Json.JsonProperty("form_id")]
        public sealed override long FormId { get; set; }

        [Newtonsoft.Json.JsonProperty("bot_id")]
        public sealed override long BotId { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public sealed override string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public sealed override string Description { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("photo")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase Photo { get; set; }

        [Newtonsoft.Json.JsonProperty("invoice")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase Invoice { get; set; }

        [Newtonsoft.Json.JsonProperty("provider_id")]
        public sealed override long ProviderId { get; set; }

        [Newtonsoft.Json.JsonProperty("url")] public sealed override string Url { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("native_provider")]
        public sealed override string NativeProvider { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("native_params")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase NativeParams { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("saved_info")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase SavedInfo { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("saved_credentials")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PaymentSavedCredentialsBase SavedCredentials { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public PaymentForm(long formId, long botId, string title, string description, CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase invoice, long providerId, string url, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            FormId = formId;
            BotId = botId;
            Title = title;
            Description = description;
            Invoice = invoice;
            ProviderId = providerId;
            Url = url;
            Users = users;
        }
#nullable disable
        internal PaymentForm()
        {
        }

        public override void UpdateFlags()
        {
            Flags = CanSaveCredentials ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = PasswordMissing ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = Photo == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
            Flags = NativeProvider == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = NativeParams == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = SavedInfo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = SavedCredentials == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(FormId);
            writer.WriteInt64(BotId);

            writer.WriteString(Title);

            writer.WriteString(Description);
            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var checkphoto = writer.WriteObject(Photo);
                if (checkphoto.IsError)
                {
                    return checkphoto;
                }
            }

            var checkinvoice = writer.WriteObject(Invoice);
            if (checkinvoice.IsError)
            {
                return checkinvoice;
            }

            writer.WriteInt64(ProviderId);

            writer.WriteString(Url);
            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.WriteString(NativeProvider);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var checknativeParams = writer.WriteObject(NativeParams);
                if (checknativeParams.IsError)
                {
                    return checknativeParams;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checksavedInfo = writer.WriteObject(SavedInfo);
                if (checksavedInfo.IsError)
                {
                    return checksavedInfo;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checksavedCredentials = writer.WriteObject(SavedCredentials);
                if (checksavedCredentials.IsError)
                {
                    return checksavedCredentials;
                }
            }

            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
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
            CanSaveCredentials = FlagsHelper.IsFlagSet(Flags, 2);
            PasswordMissing = FlagsHelper.IsFlagSet(Flags, 3);
            var tryformId = reader.ReadInt64();
            if (tryformId.IsError)
            {
                return ReadResult<IObject>.Move(tryformId);
            }

            FormId = tryformId.Value;
            var trybotId = reader.ReadInt64();
            if (trybotId.IsError)
            {
                return ReadResult<IObject>.Move(trybotId);
            }

            BotId = trybotId.Value;
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }

            Title = trytitle.Value;
            var trydescription = reader.ReadString();
            if (trydescription.IsError)
            {
                return ReadResult<IObject>.Move(trydescription);
            }

            Description = trydescription.Value;
            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var tryphoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase>();
                if (tryphoto.IsError)
                {
                    return ReadResult<IObject>.Move(tryphoto);
                }

                Photo = tryphoto.Value;
            }

            var tryinvoice = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase>();
            if (tryinvoice.IsError)
            {
                return ReadResult<IObject>.Move(tryinvoice);
            }

            Invoice = tryinvoice.Value;
            var tryproviderId = reader.ReadInt64();
            if (tryproviderId.IsError)
            {
                return ReadResult<IObject>.Move(tryproviderId);
            }

            ProviderId = tryproviderId.Value;
            var tryurl = reader.ReadString();
            if (tryurl.IsError)
            {
                return ReadResult<IObject>.Move(tryurl);
            }

            Url = tryurl.Value;
            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var trynativeProvider = reader.ReadString();
                if (trynativeProvider.IsError)
                {
                    return ReadResult<IObject>.Move(trynativeProvider);
                }

                NativeProvider = trynativeProvider.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var trynativeParams = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
                if (trynativeParams.IsError)
                {
                    return ReadResult<IObject>.Move(trynativeParams);
                }

                NativeParams = trynativeParams.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trysavedInfo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase>();
                if (trysavedInfo.IsError)
                {
                    return ReadResult<IObject>.Move(trysavedInfo);
                }

                SavedInfo = trysavedInfo.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trysavedCredentials = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PaymentSavedCredentialsBase>();
                if (trysavedCredentials.IsError)
                {
                    return ReadResult<IObject>.Move(trysavedCredentials);
                }

                SavedCredentials = trysavedCredentials.Value;
            }

            var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }

            Users = tryusers.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "payments.paymentForm";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PaymentForm();
            newClonedObject.Flags = Flags;
            newClonedObject.CanSaveCredentials = CanSaveCredentials;
            newClonedObject.PasswordMissing = PasswordMissing;
            newClonedObject.FormId = FormId;
            newClonedObject.BotId = BotId;
            newClonedObject.Title = Title;
            newClonedObject.Description = Description;
            if (Photo is not null)
            {
                var clonePhoto = (CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase?)Photo.Clone();
                if (clonePhoto is null)
                {
                    return null;
                }

                newClonedObject.Photo = clonePhoto;
            }

            var cloneInvoice = (CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase?)Invoice.Clone();
            if (cloneInvoice is null)
            {
                return null;
            }

            newClonedObject.Invoice = cloneInvoice;
            newClonedObject.ProviderId = ProviderId;
            newClonedObject.Url = Url;
            newClonedObject.NativeProvider = NativeProvider;
            if (NativeParams is not null)
            {
                var cloneNativeParams = (CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase?)NativeParams.Clone();
                if (cloneNativeParams is null)
                {
                    return null;
                }

                newClonedObject.NativeParams = cloneNativeParams;
            }

            if (SavedInfo is not null)
            {
                var cloneSavedInfo = (CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase?)SavedInfo.Clone();
                if (cloneSavedInfo is null)
                {
                    return null;
                }

                newClonedObject.SavedInfo = cloneSavedInfo;
            }

            if (SavedCredentials is not null)
            {
                var cloneSavedCredentials = (CatraProto.Client.TL.Schemas.CloudChats.PaymentSavedCredentialsBase?)SavedCredentials.Clone();
                if (cloneSavedCredentials is null)
                {
                    return null;
                }

                newClonedObject.SavedCredentials = cloneSavedCredentials;
            }

            newClonedObject.Users = new List<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
            foreach (var users in Users)
            {
                var cloneusers = (CatraProto.Client.TL.Schemas.CloudChats.UserBase?)users.Clone();
                if (cloneusers is null)
                {
                    return null;
                }

                newClonedObject.Users.Add(cloneusers);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PaymentForm castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (CanSaveCredentials != castedOther.CanSaveCredentials)
            {
                return true;
            }

            if (PasswordMissing != castedOther.PasswordMissing)
            {
                return true;
            }

            if (FormId != castedOther.FormId)
            {
                return true;
            }

            if (BotId != castedOther.BotId)
            {
                return true;
            }

            if (Title != castedOther.Title)
            {
                return true;
            }

            if (Description != castedOther.Description)
            {
                return true;
            }

            if (Photo is null && castedOther.Photo is not null || Photo is not null && castedOther.Photo is null)
            {
                return true;
            }

            if (Photo is not null && castedOther.Photo is not null && Photo.Compare(castedOther.Photo))
            {
                return true;
            }

            if (Invoice.Compare(castedOther.Invoice))
            {
                return true;
            }

            if (ProviderId != castedOther.ProviderId)
            {
                return true;
            }

            if (Url != castedOther.Url)
            {
                return true;
            }

            if (NativeProvider != castedOther.NativeProvider)
            {
                return true;
            }

            if (NativeParams is null && castedOther.NativeParams is not null || NativeParams is not null && castedOther.NativeParams is null)
            {
                return true;
            }

            if (NativeParams is not null && castedOther.NativeParams is not null && NativeParams.Compare(castedOther.NativeParams))
            {
                return true;
            }

            if (SavedInfo is null && castedOther.SavedInfo is not null || SavedInfo is not null && castedOther.SavedInfo is null)
            {
                return true;
            }

            if (SavedInfo is not null && castedOther.SavedInfo is not null && SavedInfo.Compare(castedOther.SavedInfo))
            {
                return true;
            }

            if (SavedCredentials is null && castedOther.SavedCredentials is not null || SavedCredentials is not null && castedOther.SavedCredentials is null)
            {
                return true;
            }

            if (SavedCredentials is not null && castedOther.SavedCredentials is not null && SavedCredentials.Compare(castedOther.SavedCredentials))
            {
                return true;
            }

            var userssize = castedOther.Users.Count;
            if (userssize != Users.Count)
            {
                return true;
            }

            for (var i = 0; i < userssize; i++)
            {
                if (castedOther.Users[i].Compare(Users[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}
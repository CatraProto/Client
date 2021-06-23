using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public class PaymentForm : PaymentFormBase
    {
        [Flags]
        public enum FlagsEnum
        {
            CanSaveCredentials = 1 << 2,
            PasswordMissing = 1 << 3,
            NativeProvider = 1 << 4,
            NativeParams = 1 << 4,
            SavedInfo = 1 << 0,
            SavedCredentials = 1 << 1
        }

        public static int ConstructorId { get; } = 1062645411;
        public int Flags { get; set; }
        public override bool CanSaveCredentials { get; set; }
        public override bool PasswordMissing { get; set; }
        public override int BotId { get; set; }
        public override InvoiceBase Invoice { get; set; }
        public override int ProviderId { get; set; }
        public override string Url { get; set; }
        public override string NativeProvider { get; set; }
        public override DataJSONBase NativeParams { get; set; }
        public override PaymentRequestedInfoBase SavedInfo { get; set; }
        public override PaymentSavedCredentialsBase SavedCredentials { get; set; }
        public override IList<UserBase> Users { get; set; }

        public override void UpdateFlags()
        {
            Flags = CanSaveCredentials ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = PasswordMissing ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = NativeProvider == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = NativeParams == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = SavedInfo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = SavedCredentials == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(BotId);
            writer.Write(Invoice);
            writer.Write(ProviderId);
            writer.Write(Url);
            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.Write(NativeProvider);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.Write(NativeParams);
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(SavedInfo);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(SavedCredentials);
            }

            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            CanSaveCredentials = FlagsHelper.IsFlagSet(Flags, 2);
            PasswordMissing = FlagsHelper.IsFlagSet(Flags, 3);
            BotId = reader.Read<int>();
            Invoice = reader.Read<InvoiceBase>();
            ProviderId = reader.Read<int>();
            Url = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                NativeProvider = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                NativeParams = reader.Read<DataJSONBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                SavedInfo = reader.Read<PaymentRequestedInfoBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                SavedCredentials = reader.Read<PaymentSavedCredentialsBase>();
            }

            Users = reader.ReadVector<UserBase>();
        }
    }
}
using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputBotInlineMessageMediaContact : CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase
    {
        [Flags]
        public enum FlagsEnum
        {
            ReplyMarkup = 1 << 2
        }

        public static int StaticConstructorId
        {
            get => -1494368259;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("first_name")]
        public string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty("last_name")]
        public string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty("vcard")]
        public string Vcard { get; set; }

        [Newtonsoft.Json.JsonProperty("reply_markup")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase ReplyMarkup { get; set; }


    #nullable enable
        public InputBotInlineMessageMediaContact(string phoneNumber, string firstName, string lastName, string vcard)
        {
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            Vcard = vcard;
        }
    #nullable disable
        internal InputBotInlineMessageMediaContact()
        {
        }

        public override void UpdateFlags()
        {
            Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(PhoneNumber);
            writer.Write(FirstName);
            writer.Write(LastName);
            writer.Write(Vcard);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(ReplyMarkup);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            PhoneNumber = reader.Read<string>();
            FirstName = reader.Read<string>();
            LastName = reader.Read<string>();
            Vcard = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                ReplyMarkup = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase>();
            }
        }

        public override string ToString()
        {
            return "inputBotInlineMessageMediaContact";
        }
    }
}
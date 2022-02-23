using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class DeleteAccount : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1099779595;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(bool);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("reason")]
        public string Reason { get; set; }


    #nullable enable
        public DeleteAccount(string reason)
        {
            Reason = reason;
        }
    #nullable disable

        internal DeleteAccount()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Reason);
        }

        public void Deserialize(Reader reader)
        {
            Reason = reader.Read<string>();
        }

        public override string ToString()
        {
            return "account.deleteAccount";
        }
    }
}
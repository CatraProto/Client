using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPaymentCredentials : InputPaymentCredentialsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Save = 1 << 0
		}

        public static int StaticConstructorId { get => 873977640; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("save")]
		public bool Save { get; set; }

[JsonPropertyName("data")]
		public DataJSONBase Data { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Save ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Data);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Save = FlagsHelper.IsFlagSet(Flags, 0);
			Data = reader.Read<DataJSONBase>();
		}

		public override string ToString()
		{
			return "inputPaymentCredentials";
		}
	}
}
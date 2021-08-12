using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UpdateProfile : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			FirstName = 1 << 0,
			LastName = 1 << 1,
			About = 1 << 2
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 2018596725; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(UserBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("first_name")]
		public string FirstName { get; set; }

[JsonPropertyName("last_name")]
		public string LastName { get; set; }

[JsonPropertyName("about")]
		public string About { get; set; }


		public void UpdateFlags() 
		{
			Flags = FirstName == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = LastName == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = About == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(FirstName);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(LastName);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(About);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				FirstName = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				LastName = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				About = reader.Read<string>();
			}
		}

		public override string ToString()
		{
			return "account.updateProfile";
		}
	}
}
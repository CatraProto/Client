using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class AddContact : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			AddPhonePrivacyException = 1 << 0
		}

        public static int ConstructorId { get; } = -386636848;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Contacts.AddContact);
		public bool IsVector { get; init; } = false;
		public int Flags { get; set; }
		public bool AddPhonePrivacyException { get; set; }
		public InputUserBase Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }

		public void UpdateFlags() 
		{
			Flags = AddPhonePrivacyException ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(FirstName);
			writer.Write(LastName);
			writer.Write(Phone);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			AddPhonePrivacyException = FlagsHelper.IsFlagSet(Flags, 0);
			Id = reader.Read<InputUserBase>();
			FirstName = reader.Read<string>();
			LastName = reader.Read<string>();
			Phone = reader.Read<string>();

		}
	}
}
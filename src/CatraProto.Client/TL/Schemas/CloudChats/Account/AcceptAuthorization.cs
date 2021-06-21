using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class AcceptAuthorization : IMethod
	{
		public static int ConstructorId { get; } = -419267436;
		public int BotId { get; set; }
		public string Scope { get; set; }
		public string PublicKey { get; set; }
		public IList<SecureValueHashBase> ValueHashes { get; set; }
		public SecureCredentialsEncryptedBase Credentials { get; set; }

		public Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(BotId);
			writer.Write(Scope);
			writer.Write(PublicKey);
			writer.Write(ValueHashes);
			writer.Write(Credentials);
		}

		public void Deserialize(Reader reader)
		{
			BotId = reader.Read<int>();
			Scope = reader.Read<string>();
			PublicKey = reader.Read<string>();
			ValueHashes = reader.ReadVector<SecureValueHashBase>();
			Credentials = reader.Read<SecureCredentialsEncryptedBase>();
		}
	}
}
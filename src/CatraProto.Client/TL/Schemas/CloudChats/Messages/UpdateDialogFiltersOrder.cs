using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class UpdateDialogFiltersOrder : IMethod<bool>
	{


        public static int ConstructorId { get; } = -983318044;

		public IList<int> Order { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Order);

		}

		public void Deserialize(Reader reader)
		{
			Order = reader.ReadVector<int>();

		}
	}
}
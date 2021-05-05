using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetSuggestedDialogFilters : IMethod<DialogFilterSuggestedBase>
	{


        public static int ConstructorId { get; } = -1566780372;

		public Type Type { get; init; } = typeof(GetSuggestedDialogFilters);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);

		}

		public void Deserialize(Reader reader)
		{

		}
	}
}
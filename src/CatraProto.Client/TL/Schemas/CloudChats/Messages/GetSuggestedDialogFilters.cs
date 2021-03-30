using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetSuggestedDialogFilters : IMethod<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterSuggestedBase>
	{


        public static int ConstructorId { get; } = -1566780372;


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
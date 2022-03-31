using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ReorderPinnedDialogs : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Force = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 991616823; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("force")]
		public bool Force { get; set; }

[Newtonsoft.Json.JsonProperty("folder_id")]
		public int FolderId { get; set; }

[Newtonsoft.Json.JsonProperty("order")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase> Order { get; set; }

        
        #nullable enable
 public ReorderPinnedDialogs (int folderId,IList<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase> order)
{
 FolderId = folderId;
Order = order;
 
}
#nullable disable
                
        internal ReorderPinnedDialogs() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Force ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(FolderId);
			writer.Write(Order);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Force = FlagsHelper.IsFlagSet(Flags, 0);
			FolderId = reader.Read<int>();
			Order = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase>();

		}

		public override string ToString()
		{
		    return "messages.reorderPinnedDialogs";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
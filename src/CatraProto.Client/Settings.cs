namespace CatraProto.Client
{
	public class Settings
	{
		public Settings(string sessionName)
		{
			SessionName = sessionName;
		}

		public string DatacenterAddress { get; set; } = "149.154.167.51";
		public string SessionName { get; init; }
	}
}
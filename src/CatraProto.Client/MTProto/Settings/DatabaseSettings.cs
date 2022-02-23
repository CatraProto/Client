namespace CatraProto.Client.MTProto.Settings
{
    public class DatabaseSettings
    {
        public string Path { get; }

        public DatabaseSettings(string path)
        {
            Path = path;
        }
    }
}
namespace CatraProto.Client.MTProto.Settings
{
    public class DatabaseSettings
    {
        public string Path { get; }
        public uint PeerCacheSize { get; }
        public DatabaseSettings(string path, uint peerCacheSize = 50)
        {
            PeerCacheSize = peerCacheSize;
            Path = path;
        }
    }
}
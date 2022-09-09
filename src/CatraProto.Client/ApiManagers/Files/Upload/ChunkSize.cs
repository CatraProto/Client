namespace CatraProto.Client.ApiManagers.Files;

// Values from TDesktop
internal enum ChunkSize
{
    TinyDocument = 32 * 1024, // <= 1MB
    LittleDocument = 64 * 1024, // <= 32MB
    SmallDocument = 128 * 1024, // <= 375MB
    MediumDocument = 256 * 1024, // <= 750MB
    LargeDocument = 512 * 1024 // <= 1500MB
}
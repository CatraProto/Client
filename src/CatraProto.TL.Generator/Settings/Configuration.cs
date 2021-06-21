namespace CatraProto.TL.Generator.Settings
{
    internal static class Configuration
    {
        public static string DefaultNamespace { get; set; } = "CatraProto.Client.TL.Schemas.CloudChats";
        public static string Namespace { get; set; } = DefaultNamespace;
        public static string AbstractTemplatePath { get; set; } = "Templates/Abstract.template";
        public static string ConstructorTemplatePath { get; set; } = "Templates/Constructor.template";
        public static string ApiTemplatePath { get; set; } = "Templates/Request.template";
        public static string DictionaryTemplatePath { get; set; } = "Templates/Dictionary.template";
        public static string MethodTemplatePath { get; set; } = "Templates/Method.template";
        public static string DictionaryNamespace { get; set; } = "CatraProto.Client.TL.Schemas";
        public static string DictionaryWritePath { get; set; } = "CatraProto/Client/TL/Schemas/MergedProvider.cs";
        public static string DictionaryProviderName { get; set; } = "MergedProvider";
    }
}
namespace CatraProto.TL.Generator.DeclarationInfo
{
    public class NamingInfo
    {
        public string OriginalNamespacedName { get; set; } 
        public string OriginalName { get; set; }
        public string PascalCaseName { get; set; }
        public string CamelCaseName { get; set; }

        public static implicit operator NamingInfo(string original)
        {
            var pascalCase = StringTools.PascalCase(original);
            var camelCase = StringTools.FixLanguageWord(char.ToLower(pascalCase[0]) + pascalCase[1..]);
            return new NamingInfo
            {
                OriginalName = original,
                CamelCaseName = camelCase,
                PascalCaseName = pascalCase
            };
        }
    }
}
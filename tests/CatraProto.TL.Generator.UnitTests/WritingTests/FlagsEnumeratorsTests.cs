using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CatraProto.TL.Generator.UnitTests.WritingTests
{
    public class FlagsEnumeratorsTests
    {
        [Fact]
        public async Task MultipleFlagsTest()
        {
            string[] schema = {
                "message_gay#2 flags:# pony:# message:flags.1?string mammt:flags.2?int sorreta:pony.1?int = int;",
            };
            var analyzed = await CodeGeneration.Parsing.Parser.StartAnalyzing(schema);

            var builder = new StringBuilder();
            analyzed[0].WriteFlagsEnums(builder);

            var written = builder.ToString();
            var excepted =
                $"{StringTools.TwoTabs}[Flags]\n{StringTools.TwoTabs}public enum FlagsEnum \n{StringTools.TwoTabs}{{\n{StringTools.ThreeTabs}Message = 1 << 1,\n{StringTools.ThreeTabs}Mammt = 1 << 2\n{StringTools.TwoTabs}}}\n\n{StringTools.TwoTabs}[Flags]\n{StringTools.TwoTabs}public enum PonyEnum \n{StringTools.TwoTabs}{{\n{StringTools.ThreeTabs}Sorreta = 1 << 1\n{StringTools.TwoTabs}}}";
            Assert.Equal(excepted, written);
        }
    }
}
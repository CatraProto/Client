using CatraProto.TL.Generator.Objects;
using Xunit;

namespace CatraProto.TL.Generator.UnitTests.ParserTests
{
    public class FlagParsingTest
    {
        [Theory]
        [InlineData("flags.1?Type", true, "Type", "Flags", 1)]
        [InlineData("flags.13?Type", true, "Type", "Flags", 13)]
        [InlineData("pony.1?Type", true, "Type", "Pony", 1)]
        [InlineData("pony.13?Pony", true, "Pony", "Pony", 13)]
        [InlineData("Type", false, "Type", "Flags", 1)]
        public void FindFlag(string input, bool expected, string expectedCleanType, string flagName, int flagBit)
        {
            var result = Parameter.FindFlag(input, out var cleanType, out Flag flag);
            if (!result && !expected)
            {
                Assert.False(result);
                return;
            }
            
            Assert.Equal(expected, result);
            Assert.Equal(expectedCleanType, cleanType);
            Assert.Equal(flagName, flag.Name);
            Assert.Equal(flagBit, flag.Bit);
        }
    }
}
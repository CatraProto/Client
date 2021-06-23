using CatraProto.TL.Generator.CodeGeneration.Parsing;
using Xunit;

namespace CatraProto.TL.Generator.UnitTests.ParserTests
{
	public class XParsingTest
	{
		[Fact]
		public void XReadingTest()
		{
			var analyzer = new Parser("test#432324 {X:Type} {X:#}");
			var found = analyzer.FindPolymorphicTypes();
			Assert.NotEmpty(found);
			Assert.Equal("X:Type", found[0]);
			Assert.Equal("X:#", found[1]);
		}
	}
}
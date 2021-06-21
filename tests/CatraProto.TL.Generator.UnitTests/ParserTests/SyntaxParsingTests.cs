using System.Collections.Generic;
using CatraProto.TL.Generator.CodeGeneration.Parsing;
using Xunit;

namespace CatraProto.TL.Generator.UnitTests.ParserTests
{
    public class SyntaxParsingTests
    {
        [Fact]
        public void SignatureTest()
        {
            var analyzer = new Parser("test#7B");
            var id = analyzer.FindId();
            var name = analyzer.FindName();

            Assert.Equal(123, id);
            Assert.Equal("test", name);
        }

        [Fact]
        public void NakedObjectTest()
        {
            var analyzer = new Parser("test");
            var id = analyzer.FindId();
            var name = analyzer.FindName();

            Assert.Null(id);
            Assert.Equal("test", name);
        }

        [Fact]
        public void ParametersTest()
        {
            var analyzer = new Parser("test#123 flags:# flaggedVector:flags.1?Vector<int> vector:Vector<int> int:int");
            var args = analyzer.FindParameters();

            var statuses = new Dictionary<int, string>
            {
                { 0, "flags:#" },
                { 1, "flaggedVector:flags.1?Vector<int>" },
                { 2, "vector:Vector<int>" },
                { 3, "int:int" }
            };

            for (var i = 0; i < args.Length; i++)
            {
                var p = args[i];
                Assert.Equal(p, statuses[i]);
            }
        }

        [Fact]
        public void TypeTest()
        {
            var analyzer = new Parser("test#123 flags:# = EtheriaType;");
            var type = analyzer.FindType();

            Assert.Equal("EtheriaType", type);
        }
    }
}
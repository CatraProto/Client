using CatraProto.TL.Generator.CodeGeneration;
using CatraProto.TL.Generator.CodeGeneration.Parsing;
using Xunit;

namespace CatraProto.TL.Generator.UnitTests.ParserTests
{
    public class TypeCreationTests
    {
        [Fact]
        public void BaseTypeTest()
        {
            var analyzer = new Parser("test#123 flags:# = auth.EtheriaType;");
            var type = analyzer.FindType();

            var createdType = Tools.CreateType(type, true);
            Assert.Equal("EtheriaTypeBase", createdType.Name);
            Assert.Equal("CatraProto.Client.TL.Schemas.CloudChats.Auth.EtheriaTypeBase", createdType.Namespace.FullNamespace);
            Assert.Equal("CatraProto.Client.TL.Schemas.CloudChats.Auth", createdType.Namespace.PartialNamespace);
        }
    }
}
using CatraProto.TL.Generator.CodeGeneration;
using CatraProto.TL.Generator.CodeGeneration.Parsing;
using CatraProto.TL.Generator.DeclarationInfo;
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

			var createdType = Tools.CreateType(type, new TypeInfo());
			Assert.Equal("EtheriaTypeBase", createdType.GetTypeName(NamingType.PascalCase, null, false));
			Assert.Equal("CatraProto.Client.TL.Schemas.CloudChats.Auth.EtheriaType", createdType.Namespace.FullNamespace);
			Assert.Equal("CatraProto.Client.TL.Schemas.CloudChats.Auth.EtheriaTypeBase", createdType.GetTypeName(NamingType.FullNamespace, null, false));
			Assert.Equal("CatraProto.Client.TL.Schemas.CloudChats.Auth", createdType.Namespace.PartialNamespace);
		}
	}
}
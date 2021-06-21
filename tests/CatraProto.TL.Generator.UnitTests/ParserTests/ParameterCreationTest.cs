using System;
using CatraProto.TL.Generator.CodeGeneration.Parsing;
using CatraProto.TL.Generator.Objects;
using CatraProto.TL.Generator.Objects.Types;
using Xunit;

namespace CatraProto.TL.Generator.UnitTests.ParserTests
{
    public class ParameterCreationTest
    {
        private const string DefaultNamespace = "CatraProto.Client.TL.Schemas.CloudChats.PonyBase";

        [Theory]
        [InlineData("test#123 parameterName:Bool = EtheriaType;", "ParameterName", false, false, typeof(BoolType), true, "bool")]
        [InlineData("test#123 parameterName:true = EtheriaType;", "ParameterName", false, false, typeof(BoolType), true, "bool")]
        [InlineData("test#123 parameterName:false = EtheriaType;", "ParameterName", false, false, typeof(BoolType), true, "bool")]
        [InlineData("test#123 parameterName:flags.1?Bool = EtheriaType;", "ParameterName", false, false, typeof(BoolType), true, "bool", 1)]
        [InlineData("test#123 parameterName:flags.1?true = EtheriaType;", "ParameterName", false, false, typeof(BoolType), true, "bool", 1)]
        [InlineData("test#123 parameterName:flags.1?false = EtheriaType;", "ParameterName", false, false, typeof(BoolType), true, "bool", 1)]
        [InlineData("test#123 parameterName:flags.1?Vector<Bool> = EtheriaType;", "ParameterName", false, true, typeof(BoolType), true, "bool", 1)]
        [InlineData("test#123 parameterName:Vector<Bool> = EtheriaType;", "ParameterName", false, true, typeof(BoolType), true, "bool")]
        [InlineData("test#123 parameterName:Pony = EtheriaType;", "ParameterName", false, false, typeof(GenericType), false, "PonyBase", null, DefaultNamespace)]
        [InlineData("test#123 parameterName:Vector<Pony> = EtheriaType;", "ParameterName", false, true, typeof(GenericType), false, "PonyBase", null, DefaultNamespace)]
        [InlineData("test#123 parameterName:flags.1?Pony = EtheriaType;", "ParameterName", false, false, typeof(GenericType), false, "PonyBase", 1, DefaultNamespace)]
        [InlineData("test#123 parameterName:flags.1?Vector<Pony> = EtheriaType;", "ParameterName", false, true, typeof(GenericType), false, "PonyBase", 1, DefaultNamespace)]
        [InlineData("test#123 parameterName:bytes = EtheriaType;", "ParameterName", false, false, typeof(BytesType), true, "byte[]", null)]
        [InlineData("test#123 parameterName:Vector<bytes> = EtheriaType;", "ParameterName", false, true, typeof(BytesType), true, "byte[]", null)]
        [InlineData("test#123 parameterName:flags.1?bytes = EtheriaType;", "ParameterName", false, false, typeof(BytesType), true, "byte[]", 1)]
        [InlineData("test#123 parameterName:flags.1?Vector<bytes> = EtheriaType;", "ParameterName", false, true, typeof(BytesType), true, "byte[]", 1)]
        [InlineData("test#123 parameterName:double = EtheriaType;", "ParameterName", false, false, typeof(DoubleType), true, "double", null)]
        [InlineData("test#123 parameterName:Vector<double> = EtheriaType;", "ParameterName", false, true, typeof(DoubleType), true, "double", null)]
        [InlineData("test#123 parameterName:flags.1?double = EtheriaType;", "ParameterName", false, false, typeof(DoubleType), true, "double", 1)]
        [InlineData("test#123 parameterName:flags.1?Vector<double> = EtheriaType;", "ParameterName", false, true, typeof(DoubleType), true, "double", 1)]
        [InlineData("test#123 parameterName:# = EtheriaType;", "ParameterName", false, false, typeof(FlagType), true, "flag")]
        public void CreationTest(string testString, string expectedName, bool expectedIsNaked, bool expectedIsVector,
            Type expectedType, bool expectedIsBare, string expectedTypeName, int? expectedFlagBit = null, string expectedNamespace = null)
        {
            var analyzer = new Parser(testString);
            var args = analyzer.FindParameters();

            Assert.Single(args);
            var parameter = Parameter.Create(args[0]);
            Assert.Equal(expectedName, parameter.Name);
            Assert.Equal(expectedTypeName, parameter.Type.Name);
            Assert.Equal(expectedIsNaked, parameter.IsNaked);
            Assert.Equal(expectedIsVector, parameter.IsVector);
            Assert.Equal(expectedIsBare, parameter.Type.IsBare);
            Assert.Equal(expectedType, parameter.Type.GetType());

            if (expectedNamespace == null)
            {
                Assert.Null(parameter.Type.Namespace);
            }
            else
            {
                Assert.Equal(expectedNamespace, parameter.Type.Namespace.FullNamespace);
            }

            if (expectedFlagBit != null)
            {
                Assert.True(parameter.HasFlag);
                Assert.NotNull(parameter.Flag);
                Assert.Equal(parameter.Flag?.Bit, expectedFlagBit);
            }
            else
            {
                Assert.False(parameter.HasFlag);
                Assert.Null(parameter.Flag);
            }
        }

        /// <remarks>
        /// Integers can have different BitSizes, therefore, a different approach for testing is required.
        ///
        /// </remarks>
        [Theory]
        [InlineData("test#123 parameterName:int = EtheriaType;", 32, false, "int")]
        [InlineData("test#123 parameterName:flags.1?int = EtheriaType;", 32, false, "int", 1)]
        [InlineData("test#123 parameterName:Vector<int> = EtheriaType;", 32, true, "int")]
        [InlineData("test#123 parameterName:flags.1?Vector<int> = EtheriaType;", 32, true, "int", 1)]
        [InlineData("test#123 parameterName:long = EtheriaType;", 64, false, "long")]
        [InlineData("test#123 parameterName:flags.1?long = EtheriaType;", 64, false, "long", 1)]
        [InlineData("test#123 parameterName:Vector<long> = EtheriaType;", 64, true, "long")]
        [InlineData("test#123 parameterName:flags.1?Vector<long> = EtheriaType;", 64, true, "long", 1)]
        [InlineData("test#123 parameterName:int128 = EtheriaType;", 128, false, "BigInteger")]
        [InlineData("test#123 parameterName:flags.1?int128 = EtheriaType;", 128, false, "BigInteger", 1)]
        [InlineData("test#123 parameterName:Vector<int128> = EtheriaType;", 128, true, "BigInteger")]
        [InlineData("test#123 parameterName:flags.1?Vector<int128> = EtheriaType;", 128, true, "BigInteger", 1)]
        public void IntegerCreationTests(string testString, int expectedBitSize, bool expectedIsVector,
            string expectedTypeName, int? expectedFlagBit = null)
        {
            var analyzer = new Parser(testString);
            var args = analyzer.FindParameters();

            Assert.Single(args);
            var parameter = Parameter.Create(args[0]);
            Assert.Equal("ParameterName", parameter.Name);
            Assert.Equal(expectedTypeName, parameter.Type.Name);
            Assert.False(parameter.IsNaked);
            Assert.Equal(expectedIsVector, parameter.IsVector);
            Assert.True(parameter.Type.IsBare);
            Assert.IsType<IntegerType>(parameter.Type);
            Assert.Equal(expectedBitSize, ((IntegerType)parameter.Type).BitSize);
            Assert.Null(parameter.Type.Namespace);

            if (expectedFlagBit != null)
            {
                Assert.True(parameter.HasFlag);
                Assert.NotNull(parameter.Flag);
                Assert.Equal(parameter.Flag?.Bit, expectedFlagBit);
            }
            else
            {
                Assert.False(parameter.HasFlag);
                Assert.Null(parameter.Flag);
            }
        }
    }
}
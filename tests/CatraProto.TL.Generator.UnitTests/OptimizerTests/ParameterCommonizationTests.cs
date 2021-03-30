using System.Collections.Generic;
using System.Threading.Tasks;
using CatraProto.TL.Generator.CodeGeneration.Optimization;
using CatraProto.TL.Generator.CodeGeneration.Parsing;
using Xunit;
using Xunit.Abstractions;

namespace CatraProto.TL.Generator.UnitTests.OptimizerTests
{
    public class TypeCommonizationTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public TypeCommonizationTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData(new []
        {
            "PoniesDummy#5 flags:# mammt:int = Ponies;",
            
            "Peer#3 flags:# message:string mammt:int dummyParameter:Ponies = Peer;",
            "EmptyPeer#4 flags:# message:string mammt:int = Peer;",
            "---functions---",
            "MethodPeer#5 flags:# message:string mammt:int = Peer;"
        }, new[]
        {
           "Mammt",
           "Message"
        })]
        public async Task CommonizationTest(string[] schema, string[] expectedCommon)
        {
            //TODO: This test should be rewritten to check hashcodes and so on, not just the name.
            //Parser into objects every TL Constructor (and function), in the same order as they were written.
            var parser = await Parser.StartAnalyzing(schema);
            var optimizer = new Optimizer(parser);
            optimizer.FindCommonParameters();

            var objs = optimizer.Objects;
            var mergedCommonParameters = new List<string>();
            foreach (var obj in objs)
            {
                foreach (var objParameter in obj.Parameters)
                {
                    if (objParameter.IsCommon && !mergedCommonParameters.Contains(objParameter.Name))
                    {
                        _testOutputHelper.WriteLine(objParameter.Name);
                        mergedCommonParameters.Add(objParameter.Name);
                    }
                }
            }
            
            Assert.Equal(expectedCommon.Length, mergedCommonParameters.Count);
            foreach (var typeName in expectedCommon)
            {
                Assert.Contains(mergedCommonParameters, parameter => parameter == typeName);
            }
        }
    }
}
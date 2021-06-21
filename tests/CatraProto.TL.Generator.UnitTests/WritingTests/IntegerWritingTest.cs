using System.Text;
using System.Threading.Tasks;
using CatraProto.TL.Generator.CodeGeneration.Optimization;
using CatraProto.TL.Generator.CodeGeneration.Parsing;
using CatraProto.TL.Generator.CodeGeneration.Writing;
using Xunit;
using Xunit.Abstractions;

namespace CatraProto.TL.Generator.UnitTests.WritingTests
{
    public class IntegerWritingTest
    {
        public IntegerWritingTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        private readonly ITestOutputHelper _testOutputHelper;

        [Fact]
        public async Task Test()
        {
            string[] schema =
            {
                "message_gay#2 first:Mammt second:Vector<Mammt> third:flags.1?Mammt fourth:flags.1?Vector<Mammt> = int;",
                "Mammt#1 flags:int = Mammt;"
            };
            var analyzed = await Parser.StartAnalyzing(schema);
            analyzed = Optimizer.Optimize(analyzed);
            var builder = new StringBuilder();
            foreach (var para in analyzed[0].Parameters)
            {
                para.Type.WriteParameter(builder, para);
                para.Type.WriteSerializer(builder, para);
                para.Type.WriteDeserializer(builder, para);
                builder.AppendLine("Base Parameters");
                para.Type.WriteBaseParameters(builder);
            }

            var writer = await Writer.Create(analyzed);
            await writer.Write();
            _testOutputHelper.WriteLine(builder.ToString());
        }
    }
}
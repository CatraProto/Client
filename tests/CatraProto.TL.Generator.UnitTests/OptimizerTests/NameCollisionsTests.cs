using System.Threading.Tasks;
using CatraProto.TL.Generator.CodeGeneration.Optimization;
using CatraProto.TL.Generator.CodeGeneration.Parsing;
using Xunit;

namespace CatraProto.TL.Generator.UnitTests.OptimizerTests
{
    public class NameCollisionsTests
    {
        [Fact]
        public async Task ParameterNameCollision()
        {
            string[] schema = {
                "message#1 flags:# message:string mammt:int = int;",
                "message_gay#2 flags:# message:string mammt:int = int;",
                "Peer#3 Peer:string mammt:int = Peer;",
                "EmptyPeer#4 flags:# message:string mammt:int = Peer;",
                "---functions---",
                "MethodPeer#5 flags:# message:string mammt:int = Peer;"
            };

            var parser = await Parser.StartAnalyzing(schema);
            var optimizer = new Optimizer(parser);

            optimizer.FixNamesCollission();
            Assert.Equal("PPeer", optimizer.Objects[2].Parameters[0].Name);
        }
        
        [Fact]
        public async Task NamespaceCollissionTest()
        {
            string[] schema = {
                "Updates.Updates#1 flags:# message:string mammt:int = int;",
                "Updates#2 flags:# message:string mammt:int = int;"
            };

            var parser = await Parser.StartAnalyzing(schema);
            var optimizer = new Optimizer(parser);
            
            optimizer.FixNamesCollission();
            Assert.Equal("OUpdates", optimizer.Objects[0].Name);
            Assert.Equal("OUpdates", optimizer.Objects[1].Name);
        }
    }
}
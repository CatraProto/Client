using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CatraProto.TL.Generator.CodeGeneration.Optimization;
using CatraProto.TL.Generator.CodeGeneration.Parsing;
using CatraProto.TL.Generator.CodeGeneration.Writing;

namespace CatraProto.TL.Generator
{
    internal class Start
    {
        public static async Task Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            Console.WriteLine("Please follow the instruction below and provide the requested data");
            Console.WriteLine("[Analyzer] Analyzing the schema, this shouldn't take long.");
            
            var analyzed = await Parser.StartAnalyzing();
            
            Console.WriteLine("[Optimizer] Optimizing schema, this shouldn't take long.");
            
            var optimizedObjects = Optimizer.Optimize(analyzed);
            
            var writer = await Writer.Create(Optimizer.Optimize(optimizedObjects));
            await writer.Write();
            
            var dictionaryWriter = await DictionaryWriter.Create(optimizedObjects);
            await dictionaryWriter.WriteDictionary();

            stopwatch.Stop();
                
            Console.WriteLine($"Done! {stopwatch.Elapsed.Seconds.ToString()}s");
        }
    }
}
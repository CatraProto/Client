/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using CatraProto.TL.Generator.CodeGeneration.Optimization;
using CatraProto.TL.Generator.CodeGeneration.Parsing;
using CatraProto.TL.Generator.CodeGeneration.Writing;

namespace CatraProto.TL.Generator
{
    class Start
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
            var writer = await Writer.Create(optimizedObjects);
            var dictionaryWriter = await ProviderWriter.CreateAsync(optimizedObjects);
            var updateToolsWriter = new UpdateExtractorsWriter(optimizedObjects);
            var taskList = new List<Task>
            {
                writer.Write(),
                writer.WriteMethods(),
                dictionaryWriter.WriteDictionary(),
                updateToolsWriter.WriteAsync()
            };

            await Task.WhenAll(taskList);
            stopwatch.Stop();

            Console.WriteLine($"Done! {stopwatch.Elapsed.Seconds.ToString()}s");
        }
    }
}
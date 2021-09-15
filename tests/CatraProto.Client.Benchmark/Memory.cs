using System;
using System.IO;
using BenchmarkDotNet.Attributes;

namespace CatraProto.Client.Benchmark
{
    [MemoryDiagnoser]
    public class Memory
    {
        [Benchmark]
        public void MemoryStreamConcat()
        {
            using var writer = new MemoryStream();
            for (int i = 0; i < 2000; i++)
            {
                writer.WriteByte(4);
            }
            
            using var writer2 = new MemoryStream();
            writer2.WriteByte(2);
            writer2.WriteByte(3);
            writer2.WriteByte(1);
            writer2.Write(writer.ToArray());
        }
        
        [Benchmark]
        public void MemoryStreamCopy()
        {
            using var writer = new MemoryStream();
            for (int i = 0; i < 2000; i++)
            {
                writer.WriteByte(4);
            }

            var array = new byte[2003];
            array[0] = 2;
            array[1] = 3;
            array[2] = 1;
            Array.Copy(writer.ToArray(), 0, array, 3, writer.Length);
        }
        
        [Benchmark]
        public void MemoryStreamCopyTo()
        {
            using var writer = new MemoryStream();
            for (int i = 0; i < 2000; i++)
            {
                writer.WriteByte(4);
            }
            
            using var writer2 = new MemoryStream();
            writer2.WriteByte(2);
            writer2.WriteByte(3);
            writer2.WriteByte(1);
            writer.Position = 0;
            writer.CopyTo(writer2);
        }
        
        [Benchmark]
        public void MemoryStreamRead()
        {
            using var writer = new MemoryStream();
            for (int i = 0; i < 2000; i++)
            {
                writer.WriteByte(4);
            }

            var array = new byte[2003];
            array[0] = 2;
            array[1] = 3;
            array[2] = 1;
            writer.Position = 0;
            writer.Read(array, 3, (int)writer.Length);
        }
    }
}
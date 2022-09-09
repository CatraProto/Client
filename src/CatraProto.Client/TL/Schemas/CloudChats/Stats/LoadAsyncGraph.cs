using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
    public partial class LoadAsyncGraph : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            X = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1646092192; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("token")]
        public string Token { get; set; }

        [Newtonsoft.Json.JsonProperty("x")] public long? X { get; set; }


#nullable enable
        public LoadAsyncGraph(string token)
        {
            Token = token;
        }
#nullable disable

        internal LoadAsyncGraph()
        {
        }

        public void UpdateFlags()
        {
            Flags = X == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Token);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt64(X.Value);
            }


            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            var trytoken = reader.ReadString();
            if (trytoken.IsError)
            {
                return ReadResult<IObject>.Move(trytoken);
            }

            Token = trytoken.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryx = reader.ReadInt64();
                if (tryx.IsError)
                {
                    return ReadResult<IObject>.Move(tryx);
                }

                X = tryx.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "stats.loadAsyncGraph";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new LoadAsyncGraph();
            newClonedObject.Flags = Flags;
            newClonedObject.Token = Token;
            newClonedObject.X = X;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not LoadAsyncGraph castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Token != castedOther.Token)
            {
                return true;
            }

            if (X != castedOther.X)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
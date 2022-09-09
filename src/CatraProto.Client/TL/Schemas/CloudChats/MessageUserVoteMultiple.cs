using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageUserVoteMultiple : CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1973033641; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("options")]
        public List<byte[]> Options { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public sealed override int Date { get; set; }


#nullable enable
        public MessageUserVoteMultiple(long userId, List<byte[]> options, int date)
        {
            UserId = userId;
            Options = options;
            Date = date;
        }
#nullable disable
        internal MessageUserVoteMultiple()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);

            writer.WriteVector(Options, false);
            writer.WriteInt32(Date);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            var tryoptions = reader.ReadVector<byte[]>(ParserTypes.Bytes, nakedVector: false, nakedObjects: false);
            if (tryoptions.IsError)
            {
                return ReadResult<IObject>.Move(tryoptions);
            }

            Options = tryoptions.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageUserVoteMultiple";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageUserVoteMultiple();
            newClonedObject.UserId = UserId;
            newClonedObject.Options = new List<byte[]>();
            foreach (var options in Options)
            {
                newClonedObject.Options.Add(options);
            }

            newClonedObject.Date = Date;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageUserVoteMultiple castedOther)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            var optionssize = castedOther.Options.Count;
            if (optionssize != Options.Count)
            {
                return true;
            }

            for (var i = 0; i < optionssize; i++)
            {
                if (castedOther.Options[i] != Options[i])
                {
                    return true;
                }
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
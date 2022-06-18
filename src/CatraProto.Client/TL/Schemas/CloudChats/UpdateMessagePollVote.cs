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

using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateMessagePollVote : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 274961865; }

        [Newtonsoft.Json.JsonProperty("poll_id")]
        public long PollId { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("options")]
        public List<byte[]> Options { get; set; }

        [Newtonsoft.Json.JsonProperty("qts")]
        public int Qts { get; set; }


#nullable enable
        public UpdateMessagePollVote(long pollId, long userId, List<byte[]> options, int qts)
        {
            PollId = pollId;
            UserId = userId;
            Options = options;
            Qts = qts;

        }
#nullable disable
        internal UpdateMessagePollVote()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(PollId);
            writer.WriteInt64(UserId);

            writer.WriteVector(Options, false);
            writer.WriteInt32(Qts);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypollId = reader.ReadInt64();
            if (trypollId.IsError)
            {
                return ReadResult<IObject>.Move(trypollId);
            }
            PollId = trypollId.Value;
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
            var tryqts = reader.ReadInt32();
            if (tryqts.IsError)
            {
                return ReadResult<IObject>.Move(tryqts);
            }
            Qts = tryqts.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateMessagePollVote";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateMessagePollVote
            {
                PollId = PollId,
                UserId = UserId,
                Options = new List<byte[]>()
            };
            foreach (var options in Options)
            {
                newClonedObject.Options.Add(options);
            }
            newClonedObject.Qts = Qts;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateMessagePollVote castedOther)
            {
                return true;
            }
            if (PollId != castedOther.PollId)
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
            if (Qts != castedOther.Qts)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
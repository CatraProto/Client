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

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class NotificationSoundLocal : CatraProto.Client.TL.Schemas.CloudChats.NotificationSoundBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2096391452; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("data")]
        public string Data { get; set; }


#nullable enable
        public NotificationSoundLocal(string title, string data)
        {
            Title = title;
            Data = data;

        }
#nullable disable
        internal NotificationSoundLocal()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Title);

            writer.WriteString(Data);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }
            Title = trytitle.Value;
            var trydata = reader.ReadString();
            if (trydata.IsError)
            {
                return ReadResult<IObject>.Move(trydata);
            }
            Data = trydata.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "notificationSoundLocal";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new NotificationSoundLocal
            {
                Title = Title,
                Data = Data
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not NotificationSoundLocal castedOther)
            {
                return true;
            }
            if (Title != castedOther.Title)
            {
                return true;
            }
            if (Data != castedOther.Data)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
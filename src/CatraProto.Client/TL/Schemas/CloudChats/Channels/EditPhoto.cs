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

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class EditPhoto : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -248621111; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("channel")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

        [Newtonsoft.Json.JsonProperty("photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase Photo { get; set; }


#nullable enable
        public EditPhoto(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase photo)
        {
            Channel = channel;
            Photo = photo;

        }
#nullable disable

        internal EditPhoto()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkchannel = writer.WriteObject(Channel);
            if (checkchannel.IsError)
            {
                return checkchannel;
            }
            var checkphoto = writer.WriteObject(Photo);
            if (checkphoto.IsError)
            {
                return checkphoto;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychannel = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
            if (trychannel.IsError)
            {
                return ReadResult<IObject>.Move(trychannel);
            }
            Channel = trychannel.Value;
            var tryphoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase>();
            if (tryphoto.IsError)
            {
                return ReadResult<IObject>.Move(tryphoto);
            }
            Photo = tryphoto.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channels.editPhoto";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new EditPhoto();
            var cloneChannel = (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase?)Channel.Clone();
            if (cloneChannel is null)
            {
                return null;
            }
            newClonedObject.Channel = cloneChannel;
            var clonePhoto = (CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase?)Photo.Clone();
            if (clonePhoto is null)
            {
                return null;
            }
            newClonedObject.Photo = clonePhoto;
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not EditPhoto castedOther)
            {
                return true;
            }
            if (Channel.Compare(castedOther.Channel))
            {
                return true;
            }
            if (Photo.Compare(castedOther.Photo))
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}
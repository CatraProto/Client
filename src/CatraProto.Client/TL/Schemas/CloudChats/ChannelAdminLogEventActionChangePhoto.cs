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
    public partial class ChannelAdminLogEventActionChangePhoto : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1129042607; }

        [Newtonsoft.Json.JsonProperty("prev_photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase PrevPhoto { get; set; }

        [Newtonsoft.Json.JsonProperty("new_photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase NewPhoto { get; set; }


#nullable enable
        public ChannelAdminLogEventActionChangePhoto(CatraProto.Client.TL.Schemas.CloudChats.PhotoBase prevPhoto, CatraProto.Client.TL.Schemas.CloudChats.PhotoBase newPhoto)
        {
            PrevPhoto = prevPhoto;
            NewPhoto = newPhoto;

        }
#nullable disable
        internal ChannelAdminLogEventActionChangePhoto()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkprevPhoto = writer.WriteObject(PrevPhoto);
            if (checkprevPhoto.IsError)
            {
                return checkprevPhoto;
            }
            var checknewPhoto = writer.WriteObject(NewPhoto);
            if (checknewPhoto.IsError)
            {
                return checknewPhoto;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryprevPhoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
            if (tryprevPhoto.IsError)
            {
                return ReadResult<IObject>.Move(tryprevPhoto);
            }
            PrevPhoto = tryprevPhoto.Value;
            var trynewPhoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
            if (trynewPhoto.IsError)
            {
                return ReadResult<IObject>.Move(trynewPhoto);
            }
            NewPhoto = trynewPhoto.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channelAdminLogEventActionChangePhoto";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelAdminLogEventActionChangePhoto();
            var clonePrevPhoto = (CatraProto.Client.TL.Schemas.CloudChats.PhotoBase?)PrevPhoto.Clone();
            if (clonePrevPhoto is null)
            {
                return null;
            }
            newClonedObject.PrevPhoto = clonePrevPhoto;
            var cloneNewPhoto = (CatraProto.Client.TL.Schemas.CloudChats.PhotoBase?)NewPhoto.Clone();
            if (cloneNewPhoto is null)
            {
                return null;
            }
            newClonedObject.NewPhoto = cloneNewPhoto;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelAdminLogEventActionChangePhoto castedOther)
            {
                return true;
            }
            if (PrevPhoto.Compare(castedOther.PrevPhoto))
            {
                return true;
            }
            if (NewPhoto.Compare(castedOther.NewPhoto))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
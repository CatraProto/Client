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
    public partial class ChannelAdminLogEventActionChangeStickerSet : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1312568665; }

        [Newtonsoft.Json.JsonProperty("prev_stickerset")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase PrevStickerset { get; set; }

        [Newtonsoft.Json.JsonProperty("new_stickerset")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase NewStickerset { get; set; }


#nullable enable
        public ChannelAdminLogEventActionChangeStickerSet(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase prevStickerset, CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase newStickerset)
        {
            PrevStickerset = prevStickerset;
            NewStickerset = newStickerset;

        }
#nullable disable
        internal ChannelAdminLogEventActionChangeStickerSet()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkprevStickerset = writer.WriteObject(PrevStickerset);
            if (checkprevStickerset.IsError)
            {
                return checkprevStickerset;
            }
            var checknewStickerset = writer.WriteObject(NewStickerset);
            if (checknewStickerset.IsError)
            {
                return checknewStickerset;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryprevStickerset = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
            if (tryprevStickerset.IsError)
            {
                return ReadResult<IObject>.Move(tryprevStickerset);
            }
            PrevStickerset = tryprevStickerset.Value;
            var trynewStickerset = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
            if (trynewStickerset.IsError)
            {
                return ReadResult<IObject>.Move(trynewStickerset);
            }
            NewStickerset = trynewStickerset.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channelAdminLogEventActionChangeStickerSet";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelAdminLogEventActionChangeStickerSet();
            var clonePrevStickerset = (CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase?)PrevStickerset.Clone();
            if (clonePrevStickerset is null)
            {
                return null;
            }
            newClonedObject.PrevStickerset = clonePrevStickerset;
            var cloneNewStickerset = (CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase?)NewStickerset.Clone();
            if (cloneNewStickerset is null)
            {
                return null;
            }
            newClonedObject.NewStickerset = cloneNewStickerset;
            return newClonedObject;

        }
#nullable disable
    }
}
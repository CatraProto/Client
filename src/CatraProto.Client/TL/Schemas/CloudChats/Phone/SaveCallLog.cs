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

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class SaveCallLog : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1092913030; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("file")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase File { get; set; }


#nullable enable
        public SaveCallLog(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputFileBase file)
        {
            Peer = peer;
            File = file;

        }
#nullable disable

        internal SaveCallLog()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }
            var checkfile = writer.WriteObject(File);
            if (checkfile.IsError)
            {
                return checkfile;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }
            Peer = trypeer.Value;
            var tryfile = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputFileBase>();
            if (tryfile.IsError)
            {
                return ReadResult<IObject>.Move(tryfile);
            }
            File = tryfile.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "phone.saveCallLog";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SaveCallLog();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }
            newClonedObject.Peer = clonePeer;
            var cloneFile = (CatraProto.Client.TL.Schemas.CloudChats.InputFileBase?)File.Clone();
            if (cloneFile is null)
            {
                return null;
            }
            newClonedObject.File = cloneFile;
            return newClonedObject;

        }
#nullable disable
    }
}
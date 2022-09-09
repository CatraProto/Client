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
    public partial class NotificationSoundLocal : CatraProto.Client.TL.Schemas.CloudChats.NotificationSoundBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2096391452; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("data")] public string Data { get; set; }


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
            var newClonedObject = new NotificationSoundLocal();
            newClonedObject.Title = Title;
            newClonedObject.Data = Data;
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
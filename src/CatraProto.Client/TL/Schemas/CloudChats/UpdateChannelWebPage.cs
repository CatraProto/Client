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
    public partial class UpdateChannelWebPage : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 791390623; }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("webpage")]
        public CatraProto.Client.TL.Schemas.CloudChats.WebPageBase Webpage { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")] public int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("pts_count")]
        public int PtsCount { get; set; }


#nullable enable
        public UpdateChannelWebPage(long channelId, CatraProto.Client.TL.Schemas.CloudChats.WebPageBase webpage, int pts, int ptsCount)
        {
            ChannelId = channelId;
            Webpage = webpage;
            Pts = pts;
            PtsCount = ptsCount;
        }
#nullable disable
        internal UpdateChannelWebPage()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ChannelId);
            var checkwebpage = writer.WriteObject(Webpage);
            if (checkwebpage.IsError)
            {
                return checkwebpage;
            }

            writer.WriteInt32(Pts);
            writer.WriteInt32(PtsCount);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychannelId = reader.ReadInt64();
            if (trychannelId.IsError)
            {
                return ReadResult<IObject>.Move(trychannelId);
            }

            ChannelId = trychannelId.Value;
            var trywebpage = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.WebPageBase>();
            if (trywebpage.IsError)
            {
                return ReadResult<IObject>.Move(trywebpage);
            }

            Webpage = trywebpage.Value;
            var trypts = reader.ReadInt32();
            if (trypts.IsError)
            {
                return ReadResult<IObject>.Move(trypts);
            }

            Pts = trypts.Value;
            var tryptsCount = reader.ReadInt32();
            if (tryptsCount.IsError)
            {
                return ReadResult<IObject>.Move(tryptsCount);
            }

            PtsCount = tryptsCount.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateChannelWebPage";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateChannelWebPage();
            newClonedObject.ChannelId = ChannelId;
            var cloneWebpage = (CatraProto.Client.TL.Schemas.CloudChats.WebPageBase?)Webpage.Clone();
            if (cloneWebpage is null)
            {
                return null;
            }

            newClonedObject.Webpage = cloneWebpage;
            newClonedObject.Pts = Pts;
            newClonedObject.PtsCount = PtsCount;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateChannelWebPage castedOther)
            {
                return true;
            }

            if (ChannelId != castedOther.ChannelId)
            {
                return true;
            }

            if (Webpage.Compare(castedOther.Webpage))
            {
                return true;
            }

            if (Pts != castedOther.Pts)
            {
                return true;
            }

            if (PtsCount != castedOther.PtsCount)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
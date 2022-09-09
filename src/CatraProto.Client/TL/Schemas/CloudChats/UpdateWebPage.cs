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
    public partial class UpdateWebPage : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 2139689491; }

        [Newtonsoft.Json.JsonProperty("webpage")]
        public CatraProto.Client.TL.Schemas.CloudChats.WebPageBase Webpage { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")] public int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("pts_count")]
        public int PtsCount { get; set; }


#nullable enable
        public UpdateWebPage(CatraProto.Client.TL.Schemas.CloudChats.WebPageBase webpage, int pts, int ptsCount)
        {
            Webpage = webpage;
            Pts = pts;
            PtsCount = ptsCount;
        }
#nullable disable
        internal UpdateWebPage()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
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
            return "updateWebPage";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateWebPage();
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
            if (other is not UpdateWebPage castedOther)
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
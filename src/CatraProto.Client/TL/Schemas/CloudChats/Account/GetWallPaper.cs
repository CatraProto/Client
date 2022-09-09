using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetWallPaper : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -57811990; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("wallpaper")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase Wallpaper { get; set; }


#nullable enable
        public GetWallPaper(CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase wallpaper)
        {
            Wallpaper = wallpaper;
        }
#nullable disable

        internal GetWallPaper()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkwallpaper = writer.WriteObject(Wallpaper);
            if (checkwallpaper.IsError)
            {
                return checkwallpaper;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trywallpaper = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase>();
            if (trywallpaper.IsError)
            {
                return ReadResult<IObject>.Move(trywallpaper);
            }

            Wallpaper = trywallpaper.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.getWallPaper";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetWallPaper();
            var cloneWallpaper = (CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase?)Wallpaper.Clone();
            if (cloneWallpaper is null)
            {
                return null;
            }

            newClonedObject.Wallpaper = cloneWallpaper;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetWallPaper castedOther)
            {
                return true;
            }

            if (Wallpaper.Compare(castedOther.Wallpaper))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
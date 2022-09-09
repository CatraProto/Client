using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class PremiumPromo : CatraProto.Client.TL.Schemas.CloudChats.Help.PremiumPromoBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1974518743; }

        [Newtonsoft.Json.JsonProperty("status_text")]
        public sealed override string StatusText { get; set; }

        [Newtonsoft.Json.JsonProperty("status_entities")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> StatusEntities { get; set; }

        [Newtonsoft.Json.JsonProperty("video_sections")]
        public sealed override List<string> VideoSections { get; set; }

        [Newtonsoft.Json.JsonProperty("videos")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Videos { get; set; }

        [Newtonsoft.Json.JsonProperty("currency")]
        public sealed override string Currency { get; set; }

        [Newtonsoft.Json.JsonProperty("monthly_amount")]
        public sealed override long MonthlyAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public PremiumPromo(string statusText, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> statusEntities, List<string> videoSections, List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> videos, string currency, long monthlyAmount, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            StatusText = statusText;
            StatusEntities = statusEntities;
            VideoSections = videoSections;
            Videos = videos;
            Currency = currency;
            MonthlyAmount = monthlyAmount;
            Users = users;
        }
#nullable disable
        internal PremiumPromo()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(StatusText);
            var checkstatusEntities = writer.WriteVector(StatusEntities, false);
            if (checkstatusEntities.IsError)
            {
                return checkstatusEntities;
            }

            writer.WriteVector(VideoSections, false);
            var checkvideos = writer.WriteVector(Videos, false);
            if (checkvideos.IsError)
            {
                return checkvideos;
            }

            writer.WriteString(Currency);
            writer.WriteInt64(MonthlyAmount);
            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trystatusText = reader.ReadString();
            if (trystatusText.IsError)
            {
                return ReadResult<IObject>.Move(trystatusText);
            }

            StatusText = trystatusText.Value;
            var trystatusEntities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trystatusEntities.IsError)
            {
                return ReadResult<IObject>.Move(trystatusEntities);
            }

            StatusEntities = trystatusEntities.Value;
            var tryvideoSections = reader.ReadVector<string>(ParserTypes.String, nakedVector: false, nakedObjects: false);
            if (tryvideoSections.IsError)
            {
                return ReadResult<IObject>.Move(tryvideoSections);
            }

            VideoSections = tryvideoSections.Value;
            var tryvideos = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryvideos.IsError)
            {
                return ReadResult<IObject>.Move(tryvideos);
            }

            Videos = tryvideos.Value;
            var trycurrency = reader.ReadString();
            if (trycurrency.IsError)
            {
                return ReadResult<IObject>.Move(trycurrency);
            }

            Currency = trycurrency.Value;
            var trymonthlyAmount = reader.ReadInt64();
            if (trymonthlyAmount.IsError)
            {
                return ReadResult<IObject>.Move(trymonthlyAmount);
            }

            MonthlyAmount = trymonthlyAmount.Value;
            var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }

            Users = tryusers.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "help.premiumPromo";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PremiumPromo();
            newClonedObject.StatusText = StatusText;
            newClonedObject.StatusEntities = new List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
            foreach (var statusEntities in StatusEntities)
            {
                var clonestatusEntities = (CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase?)statusEntities.Clone();
                if (clonestatusEntities is null)
                {
                    return null;
                }

                newClonedObject.StatusEntities.Add(clonestatusEntities);
            }

            newClonedObject.VideoSections = new List<string>();
            foreach (var videoSections in VideoSections)
            {
                newClonedObject.VideoSections.Add(videoSections);
            }

            newClonedObject.Videos = new List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
            foreach (var videos in Videos)
            {
                var clonevideos = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)videos.Clone();
                if (clonevideos is null)
                {
                    return null;
                }

                newClonedObject.Videos.Add(clonevideos);
            }

            newClonedObject.Currency = Currency;
            newClonedObject.MonthlyAmount = MonthlyAmount;
            newClonedObject.Users = new List<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
            foreach (var users in Users)
            {
                var cloneusers = (CatraProto.Client.TL.Schemas.CloudChats.UserBase?)users.Clone();
                if (cloneusers is null)
                {
                    return null;
                }

                newClonedObject.Users.Add(cloneusers);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PremiumPromo castedOther)
            {
                return true;
            }

            if (StatusText != castedOther.StatusText)
            {
                return true;
            }

            var statusEntitiessize = castedOther.StatusEntities.Count;
            if (statusEntitiessize != StatusEntities.Count)
            {
                return true;
            }

            for (var i = 0; i < statusEntitiessize; i++)
            {
                if (castedOther.StatusEntities[i].Compare(StatusEntities[i]))
                {
                    return true;
                }
            }

            var videoSectionssize = castedOther.VideoSections.Count;
            if (videoSectionssize != VideoSections.Count)
            {
                return true;
            }

            for (var i = 0; i < videoSectionssize; i++)
            {
                if (castedOther.VideoSections[i] != VideoSections[i])
                {
                    return true;
                }
            }

            var videossize = castedOther.Videos.Count;
            if (videossize != Videos.Count)
            {
                return true;
            }

            for (var i = 0; i < videossize; i++)
            {
                if (castedOther.Videos[i].Compare(Videos[i]))
                {
                    return true;
                }
            }

            if (Currency != castedOther.Currency)
            {
                return true;
            }

            if (MonthlyAmount != castedOther.MonthlyAmount)
            {
                return true;
            }

            var userssize = castedOther.Users.Count;
            if (userssize != Users.Count)
            {
                return true;
            }

            for (var i = 0; i < userssize; i++)
            {
                if (castedOther.Users[i].Compare(Users[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}
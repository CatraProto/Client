using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class GetGroupsForDiscussion : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -170208392; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;


        public GetGroupsForDiscussion()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channels.getGroupsForDiscussion";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetGroupsForDiscussion();
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetGroupsForDiscussion castedOther)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
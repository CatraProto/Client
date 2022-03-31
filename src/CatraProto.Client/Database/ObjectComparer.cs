using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatraProto.Client.TL.Schemas.CloudChats;

namespace CatraProto.Client.Database
{
    internal static class ObjectComparer
    {
        public static bool AreDifferent(Chat chat, Chat other)
        {
            //Creator, Kicked, Left, Deactivated, CallActive, CallNotEmpty, Noforwards are all values controlled by Flags
            if(chat.Flags != other.Flags)
            {
                return true;
            }

            if(chat.Id != other.Id)
            {
                return true;
            }

            if(chat.Version != other.Version)
            {
                return true;
            }

            if(chat.ParticipantsCount != other.ParticipantsCount)
            {
                return true;
            }

            if(chat.Kicked != other.Kicked)
            {
                return true;
            }

            if(chat.Left != other.Left)
            {
                return true;
            }

            if(chat.MigratedTo != other.MigratedTo)
            {
                return true;
            }

            if(chat.Title != other.Title)
            {
                return true;
            }

            if(chat.Date != other.Date)
            {
                return true;
            }

            return false;
        }
    }
}

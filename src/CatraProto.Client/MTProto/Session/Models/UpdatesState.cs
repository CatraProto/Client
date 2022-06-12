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

using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Models
{
    internal class UpdatesState : SessionModel
    {
        private int _pts = 1;
        private int _qts = 0;
        private int _seq;
        private int _date = 1;
        private bool _state = false;

        public UpdatesState(object mutex) : base(mutex)
        {
        }

        public (int pts, int qts, int seq, int date, bool isActive) GetData()
        {
            lock (Mutex)
            {
                return (_pts, _qts, _seq, _date, _state);
            }
        }

        public void SetData(int? pts = null, int? qts = null, int? seq = null, int? date = null, bool? isActive = null)
        {
            lock (Mutex)
            {
                var (currentPts, currentQts, currentSeq, currentDate, currentActive) = GetData();
                _pts = pts ?? currentPts;
                _qts = qts ?? currentQts;
                _seq = seq ?? currentSeq;
                _date = date ?? currentDate;
                _state = isActive ?? currentActive;
            }
        }

        public void Read(Reader reader)
        {
            lock (Mutex)
            {
                _pts = reader.ReadInt32().Value;
                _qts = reader.ReadInt32().Value;
                _seq = reader.ReadInt32().Value;
                _date = reader.ReadInt32().Value;
                _state = reader.ReadBool().Value;
            }
        }

        public void Save(Writer writer)
        {
            lock (Mutex)
            {
                writer.WriteInt32(_pts);
                writer.WriteInt32(_qts);
                writer.WriteInt32(_seq);
                writer.WriteInt32(_date);
                writer.WriteBool(_state);
            }
        }
    }
}
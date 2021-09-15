using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Models
{
    class UpdatesState
    {
        private readonly object _mutex;
        private int _pts = 1;
        private int _qts = -1;
        private int _seq;
        private int _date = 1;

        public UpdatesState(object mutex)
        {
            _mutex = mutex;
        }

        public (int pts, int qts, int seq, int date) GetData()
        {
            lock (_mutex)
            {
                return (_pts, _qts, _seq, _date);
            }
        }

        public void SetData(int? pts = null, int? qts = null, int? seq = null, int? date = null)
        {
            lock (_mutex)
            {
                var (currentPts, currentQts, currentSeq, currentDate) = GetData();
                _pts = pts ?? currentPts;
                _qts = qts ?? currentQts;
                _seq = seq ?? currentSeq;
                _date = date ?? currentDate;
            }
        }

        public void Read(Reader reader)
        {
            lock (_mutex)
            {
                _pts = reader.Read<int>();
                _qts = reader.Read<int>();
                _seq = reader.Read<int>();
                _date = reader.Read<int>();
            }
        }

        public void Save(Writer writer)
        {
            lock (_mutex)
            {
                writer.Write(_pts);
                writer.Write(_qts);
                writer.Write(_seq);
                writer.Write(_date);
            }
        }
    }
}
using System;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Enums.Generic;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.Async.Signalers;

namespace CatraProto.Client.Async.Loops
{
    public abstract class ResumableLoop : BaseLoop<ResumableLoopState, ResumableSignalState>
    {
        private ResumableLoopState _loopState = ResumableLoopState.Stopped;
        protected ResumableLoop() : base(new AsyncStateSignaler<ResumableSignalState>(ResumableSignalState.Stop))
        {
        }
        
        public virtual bool Suspend()
        {
            lock (SharedLock)
            {
                if (_loopState != ResumableLoopState.Running)
                {
                    return false;
                }
                
                StateSignaler.Signal(ResumableSignalState.Suspend);
                _loopState = ResumableLoopState.Suspended;
                return true;
            }
        }
        
        public virtual bool Resume()
        {
            lock (SharedLock)
            {
                if (_loopState != ResumableLoopState.Suspended)
                {
                    return false;
                }   
                
                StateSignaler.Signal(ResumableSignalState.Resume);
                _loopState = ResumableLoopState.Running;
                return true;
            }
        }
        
        protected override bool CanStartLoop()
        {
            lock (SharedLock)
            {
                return _loopState == ResumableLoopState.Stopped;
            }
        }

        protected override bool CanStopLoop()
        {
            lock (SharedLock)
            {
                return _loopState != ResumableLoopState.Stopped;
            }
        }

        protected override void OnLoopNewState(bool stopped)
        {
            lock (SharedLock)
            {
                if (stopped)
                {
                    _loopState = ResumableLoopState.Stopped;
                    StateSignaler.Signal(ResumableSignalState.Stop);
                }
                else
                {
                    _loopState = ResumableLoopState.Running;
                    StateSignaler.Signal(ResumableSignalState.Start);  
                }
            }
        }

        public override ResumableLoopState GetCurrentState()
        {
            lock (SharedLock)
            {
                return _loopState;
            }
        }

        protected void ChangeLoopState(ResumableLoopState newState)
        {
            lock (SharedLock)
            {
                _loopState = newState;
            }
        }
        
        protected override void SetLoopStopped()
        {
            lock (SharedLock)
            {
                _loopState = ResumableLoopState.Stopped;
                base.SetLoopStopped();
            }
        }
    }
}
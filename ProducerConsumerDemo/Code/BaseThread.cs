﻿/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System.Threading;

namespace ProducerConsumerDemo.Code
{
    /// <summary>
    /// Adapted from 
    /// https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/
    /// </summary>
    abstract class BaseThread
    {
        private Thread _thread;

        protected BaseThread()
        {
            _thread = new Thread(new ThreadStart(this.RunThread));
        }

        // Thread methods / properties
        public void Start() => _thread.Start();
        public void Join() => _thread.Join();
        public bool IsAlive => _thread.IsAlive;
        public void Abort() => _thread.Abort();     // I added this. 

        // Override in base class
        public abstract void RunThread();
    }
}

﻿using System.Threading;

namespace Multithreading_06
{
    internal abstract class ThreadObject
    {
        public Thread MyThread { get; private set; }
        public bool IsRunning { get; set; }

        public ThreadObject()
        {
            IsRunning = false;
        }

        public void StartThread()
        {
            MyThread = new Thread(new ThreadStart(Update));
            MyThread.IsBackground = true;

            MyThread.Start();
            IsRunning = true;
        }

        //Main method for thread, ideally contain while-loop with IsRunning
        public abstract void Update();
    }
}
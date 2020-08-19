using System;

namespace Multithreading_07
{
    internal static class StaticRandom
    {
        private static readonly Random myRandom = new Random();
        private static readonly object mySyncLock = new object();

        public static int RandomNumber(int min, int max)
        {
            lock (mySyncLock)
            {
                return myRandom.Next(min, max);
            }
        }
    }
}
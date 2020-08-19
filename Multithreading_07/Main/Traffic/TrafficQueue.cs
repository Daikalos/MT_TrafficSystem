using System.Collections.Generic;
using System.Linq;

namespace Multithreading_07
{
    class TrafficQueue
    {
        private readonly Queue<LeftCar> myLeftCarQueue;  //Queue of cars waiting to enter the tunnel
        private readonly Queue<RightCar> myRightCarQueue;

        private readonly object mySyncLeftCarQueue = new object(); //Sync access to queue to prevent out-of-sync error
        private readonly object mySyncRightCarQueue = new object();

        private readonly int myLeftMaxCount; //Max count used to control amount of cars allowed to spawn in traffic
        private readonly int myRightMaxCount;

        public Queue<LeftCar> LeftCarQueue => myLeftCarQueue;
        public Queue<RightCar> RightCarQueue => myRightCarQueue;

        public int LeftMaxCount => myLeftMaxCount;
        public int RightMaxCount => myRightMaxCount;

        public TrafficQueue()
        {
            myLeftMaxCount = 4;
            myRightMaxCount = 4;

            myLeftCarQueue = new Queue<LeftCar>();
            myRightCarQueue = new Queue<RightCar>();
        }
        
        public void AddToLeftQueue(LeftCar car)
        {
            lock (mySyncLeftCarQueue)
            {
                myLeftCarQueue.Enqueue(car);
            }
        }
        public void RemoveFromLeftQueue()
        {
            lock (mySyncLeftCarQueue)
            {
                myLeftCarQueue.Dequeue();
            }
        }
        public int PositionInLeftQueue(LeftCar car)
        {
            lock (mySyncLeftCarQueue)
            {
                for (int i = myLeftCarQueue.Count - 1; i >= 0; i--)
                {
                    if (myLeftCarQueue.ElementAt(i) == car)
                    {
                        return i;
                    }
                }
            }
            return 0;

        }

        public void AddToRightQueue(RightCar car)
        {
            lock (mySyncRightCarQueue)
            {
                myRightCarQueue.Enqueue(car);
            }
        }
        public void RemoveFromRightQueue()
        {
            lock (mySyncRightCarQueue)
            {
                myRightCarQueue.Dequeue();
            }
        }
        public int PositionInRightQueue(RightCar car)
        {
            lock (mySyncRightCarQueue)
            {
                for (int i = myRightCarQueue.Count - 1; i >= 0; i--)
                {
                    if (myRightCarQueue.ElementAt(i) == car)
                    {
                        return i;
                    }
                }
            }
            return 0;
        }
    }
}

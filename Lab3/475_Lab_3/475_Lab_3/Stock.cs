using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _475_Lab_3
{
    // Publisher class that raises events
    class Stock
    {
        public event EventHandler<StockNotification> StockEvent; // defines an event using built-in EventHandler delegate type

        public event EventHandler<FileReachedEventArgs> FileReachedEvent; // defines a event to notify when a file receives stock info

        private readonly Thread _thread;

        private string Name { get; set;}
        private int InitValue { get; set; }
        public int CurrentValue { get; set; }
        private int MaxChange { get; set; }
        private int NotificationThreshold { get; set; }
        public int NumChanges { get; set; }

        /// <summary>
        /// Stock class that contains all the information and changes of the stock
        /// </summary>
        /// <param name="name">Stock name</param>
        /// <param name="initValue">Starting stock value</param>
        /// <param name="maxChange">The max value change of the stock</param>
        /// <param name="notificationThreshold">The range for the stock</param>
        public Stock(String name, int initValue, int maxChange, int notificationThreshold)
        {
            this.Name = name;
            this.InitValue = initValue;
            this.MaxChange = maxChange;
            this.NotificationThreshold = notificationThreshold;
        }

        /// <summary>
        /// Activates the threads synchronizations
        /// </summary>
        public void Activate(StockNotification args)
        {
            for (int i = 0; i < 25; i++)
            {
                Thread.Sleep(500); // Thread pauses for 1/2 second (500 milliseconds)
                //Call the function ChangeStockValue
                ChangeStockValue(args);
            }
        }

       

        /// <summary>
        /// Changes the stock value and also raising the event of stock value changes
        /// </summary>
        public void ChangeStockValue(StockNotification args)
        {
            var rand = new Random();
            CurrentValue += rand.Next(1, MaxChange);
            if ((CurrentValue - InitValue) > NotificationThreshold)
            {
                StockEvent?.Invoke(this, args);
            }
        }


        /// <summary>
        /// An event to notify saving the following info to a text file when the threshold is reached:
        /// date & time, stock name, initial value, and current value
        /// </summary>
        public void StockChangeFile(FileReachedEventArgs args)
        {
            if ((CurrentValue - InitValue) > NotificationThreshold)
            {
                FileReachedEvent?.Invoke(this, args);
            }
        }

    }
}

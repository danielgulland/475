using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _475_Lab_3
{
    class Stock
    {
        public event EventHandler<StockNotification> StockEvent;

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
        public void Activate()
        {
            for (int i = 0; i < 25; i++)
            {
                Thread.Sleep(500); // Thread pauses for 1/2 second (500 milliseconds)
                //Call the function ChangeStockValue
                ChangeStockValue();
            }
        }
        /// <summary>
        /// Changes the stock value and also raising the event of stock value changes
        /// </summary>
        public void ChangeStockValue()
        {
            var rand = new Random();
            CurrentValue += ;
            if ((CurrentValue - InitValue) > NotificationThreshold)
            {
                StockEvent?.Invoke

            }
        }
    }
}

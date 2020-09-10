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


        public string Name { get; set; }
        public int InitValue { get; set; }
        public int CurrentValue { get; set; }
        public int MaxChange { get; set; }
        public int NotificationThreshold { get; set; }
        public int NumChanges { get; set; }
        public DateTime DateAndTime { get; set; }


        /// <summary>
        /// Stock class that contains all the information and changes of the stock
        /// </summary>
        /// <param name="name">Stock name</param>
        /// <param name="initValue">Starting stock value</param>
        /// <param name="maxChange">The max value change of the stock</param>
        /// <param name="notificationThreshold">The range for the stock</param>
        public Stock(String name, int initValue, int maxChange, int notificationThreshold)
        {
            Name = name;
            InitValue = initValue;
            MaxChange = maxChange;
            NotificationThreshold = notificationThreshold;
            CurrentValue = initValue;
            DateAndTime = DateTime.Now;
            _thread = new Thread(Activate);    //creates a new thread & executes it
            _thread.Start();
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
            CurrentValue += rand.Next(1, MaxChange + 1);

            NumChanges++;

            if ((CurrentValue - InitValue) > NotificationThreshold)
            {
                StockNotification args = new StockNotification();   //create event
                // Create event data
                args.StockName = Name;
                args.CurrentValue = CurrentValue;
                args.NumChanges = NumChanges;

                StockEvent?.Invoke(this, args); //raises event by invoking delegate
                StockChangeFile();
            }
        }

        /// <summary>
        /// An event to notify saving the following info to a text file when the threshold is reached:
        /// date & time, stock name, initial value, and current value
        /// </summary>
        public void StockChangeFile()
        {
            FileReachedEventArgs args = new FileReachedEventArgs(); //create event
            // Create event data
            args.DateAndTime = DateAndTime;
            args.StockName = Name;
            args.InitValue = InitValue;
            args.CurrentValue = CurrentValue;

            FileReachedEvent?.Invoke(this, args);
        }


    }
}

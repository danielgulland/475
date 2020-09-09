using System;
namespace _475_Lab_3
{
    // A EventArgs class that notifys saving event data to a text file when the
    // stock's threshold is reached: date and time, stock name, inital value and current value.
    public class FileReachedEventArgs : EventArgs
    {
        public DateTime DateAndTime { get; set; }
        public string StockName { get; set; }
        public int InitValue { get; set; }
        public int CurrentValue { get; set; }


        /// <summary>
        /// Event Notfication when text file receives the following info
        /// </summary>
        /// <param name="dateAndTime">The date and time a stock reaches its threshold</param>
        /// <param name="stockName">Name of stock</param>
        /// <param name="initValue">Starting stock value</param>
        /// <param name="currentValue">Current vallue of the stock</param>
        //public FileReachedEventArgs(DateTime dateAndTime, string stockName, int initValue, int currentValue)
        //{
        //    this.DateAndTime = DateAndTime;
        //    this.StockName = StockName;
        //    this.InitValue = InitValue;
        //    this.CurrentValue = CurrentValue;
        //}

    }
}

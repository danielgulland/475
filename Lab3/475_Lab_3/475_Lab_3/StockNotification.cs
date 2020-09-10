using System;
using System.Collections.Generic;
using System.Text;

namespace _475_Lab_3
{
    // A custom EventArgs class that holds event data.
    // Event data that is passed to EventHandler is the stock's name, current value, and the number of changes stock goes through
    public class StockNotification : EventArgs
    {
        public string StockName { get; set; }
        public int CurrentValue { get; set; }
        public int NumChanges { get; set; }

    }
}

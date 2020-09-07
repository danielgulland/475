using System;
using System.Collections.Generic;
using System.Text;

namespace _475_Lab_3
{
    class Stock
    {
        private string Name { get; set;}
        private int InitValue { get; set; }
        private int MaxChange { get; set; }
        private int NotificationThreshold { get; set; }

        public Stock(String name, int initValue, int maxChange, int notificationThreshold)
        {
            this.Name = name;
            this.InitValue = initValue;
            this.MaxChange = maxChange;
            this.NotificationThreshold = notificationThreshold;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _475_Lab_3
{
    class StockBroker
    {
        private string Name { get; set; }

        public List<Stock> stocks = new List<Stock>();


        //public static ReaderWriterLockSlim myLock = new ReaderWriterLockSlim();
        //readonly string docPath = @"C:\Users\Documents\CECS 475\Lab3_output.txt";

        //public string titles = "Broker".PadRight(10) + "Stock".PadRight(15) +
        //                        "Value".PadRight(10) + "Changes".PadRight(10) + "Date and Time";

        public StockBroker(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Adds stock objects to the stock list
        /// </summary>
        /// <param name="stock">Stock object</param>
        public void AddStock(Stock stock)
        {
            stocks.Add(stock);
            stock.StockEvent += EventHandler;  // register with an event
        }

        /// <summary>
        /// The eventhandler that raises the event of a change
        /// </summary>
        /// <param name="sender">The sender that indicated a change</param>
        /// <param name="e">Event arguments</param>
        void EventHandler(Object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Broker Stock Value Changes");
                
                Stock newStock = (Stock)sender;
                string statement;
             

            }
        }
    }
}

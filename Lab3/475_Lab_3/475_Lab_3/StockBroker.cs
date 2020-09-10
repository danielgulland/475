using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace _475_Lab_3
{
    // Subsriber class that receives the notifications
    class StockBroker
    {
        static int x = 0;
        private string Name { get; set; }

        public List<Stock> stocks = new List<Stock>();


        public static ReaderWriterLockSlim myLock = new ReaderWriterLockSlim();
        readonly string docPath = @"C:\Users\Daniel\schoolProjects\475\Lab3\475_Lab_3\475_Lab_3\Lab3_output.txt";


        public string titles = "Broker".PadRight(10) + "Stock".PadRight(15) +
                                "Value".PadRight(10) + "Changes".PadRight(10) + "Date and Time";

        /// <summary>
        /// The stockbroker object
        /// </summary>
        /// <param name="name">The stockbroker's name</param>

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
            stocks.Add(stock);  // Adds stock to list
            stock.StockEvent += StockEventHandler;  // register with an event
            stock.FileReachedEvent += FileEventHandler;
            //Console.WriteLine(titles);

        }

        /// <summary>
        /// The eventhandler that raises the event of a change
        /// </summary>
        /// <param name="sender">The sender that indicated a change</param>
        /// <param name="e">Event arguments</param>
        public void StockEventHandler(Object sender, StockNotification e)
        {
            string statement = Name + " " + e.StockName + " " + e.CurrentValue + " " + e.NumChanges;
            Console.WriteLine(statement);
        }

        public void FileEventHandler(Object sender, FileReachedEventArgs e)
        {
            myLock.EnterWriteLock();

            string statement = e.DateAndTime + " " + e.StockName + " " + e.InitValue + " " + e.CurrentValue;

            try
            {
                using (StreamWriter outputFile = new StreamWriter(docPath, true))
                {
                    outputFile.WriteLine(statement);
                    outputFile.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myLock.ExitWriteLock();

            }

        }
    }
}

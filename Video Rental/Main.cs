using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Project1
{
    public class Run
    {
        public Run()
        {
        }

        public static void Main()
        {

            VideoStore Blockbuster = new VideoStore();
            List<Customer> customers = Blockbuster.getCustomers();
            for (int i = 1; i <= 35; i++)
            {
                Blockbuster.simulateDay(i);


            }

            Blockbuster.printLog();
        }
    }
            
}

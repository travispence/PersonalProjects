using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1
{
    class Rental
    {
        List<Video> rentalList = new List<Video>();
        private int dueDate;
        private int rentalDate;
        private Tuple<string, string> customerName;
        public Rental(List<Video> newRental, int due, int rent, Tuple<string, string> name)
        {
            rentalList = newRental;
            dueDate = due;
            rentalDate = rent;
            customerName = name;

        }

        public List<Video> getVideos()
        {
            return rentalList;
        }
        public int getDueDate()
        {
            return dueDate;
        }
        public int getRentalDate()
        {
            return rentalDate;
        }
        public Tuple<string, string> getCustomerNameandType()
        {
            return customerName;
        }
        public double getTotalCost()
        {
            double cost = 0;
            foreach (Video video in rentalList)
            {
                cost += video.getCost();

            }
            return cost;
        }

        public String getRentalInfo()
        {
            String info;

            int rentalPeriod = this.getDueDate() - this.getRentalDate();


            info = this.customerName + "rented "+ this.rentalList.Count() + " movie(s) on day " + getRentalDate() + " for " + rentalPeriod + " nights." + Environment.NewLine;

            foreach (Video v in this.getVideos())
            {
                info += "Video<" + v.getName() + ",Category<" + v.getType() + "," + v.getCost()+">>"+Environment.NewLine;
            }

            info += "Total Cost of Rental: $" + this.getTotalCost() + Environment.NewLine;

            return info;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1
{
    abstract class Video
    {
        protected string name;
        protected double cost;
        protected string type;
        protected int date;
        public Video(string title)
        {
            name = title;
            cost = 0.0;
            date = 0;
        }
        public double getCost()
        {
            return cost;
        }
        public string getName()
        {
            return name;
        }
        public string getType()
        {
            return type;
        }
        public int getDueDate()
        {
            return date;
        }
        public void setDueDate(int day)
        {
            date = day;
        }
    }

    class Comedy : Video
    {

        public Comedy(string title) : base(title)
        {
            name = title;
            cost = 3.75;
            type = "Comedy";
        }
    }
    class New_Release : Video
    {
        public New_Release(string title)
            : base(title)
        {
            name = title;
            cost = 5.00;
            type = "New Release";
        }
    }
    class Drama : Video
    {
        public Drama(string title)
            : base(title)
        {
            name = title;
            cost = 4.50;
            type = "Drama";
        }
    }
    class Romance : Video
    {
        public Romance(string title)
            : base(title)
        {
            name = title;
            cost = 4.75;
            type = "Romance";
        }
    }
    class Horror : Video
    {
        public Horror(string title): base(title)
        {
            name = title;
            cost = 4.00;
            type = "Horror";
        }
    }
}

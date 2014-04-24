using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;


namespace Project1
{

    class VideoStore
    {
        double totalRevenue;
        private List<Video> inventory = new List<Video>();
        private List<Rental> activeRental = new List<Rental>();
        private List<Customer> customerDatabase = new List<Customer>();
        private int date;
        private List<String> history = new List<String>();
        private List<String> completedRentals = new List<String>();






        public VideoStore()
        {
            totalRevenue = 0.0;
            makeCustomers();
            makeMovies();
            date = 0;
        }
        public void simulateDay(int day)
        {
            setDay(day);
            Random range = new Random();
            int randRange = range.Next(1, 15);
            Random r = new Random();
            int randVal;
            Customer person;



            //At the start of each day, each customer checks to see if they need to return movies.
            //The function returnMovies() also handles the returning of the movies.
            foreach (Customer c in customerDatabase)
            {
                c.returnMovies(this);
            }
            if (day != 1)
            {
                writeToLog("End of Night " + (day - 1) + ":" + Environment.NewLine + "------------------------------------" + Environment.NewLine);


            }
            writeToLog("Start of day " + day + ":" + Environment.NewLine + "------------------------------------" + Environment.NewLine);


            for (int i = 0; i < randRange; i++)
            {
                randVal = r.Next(10);
                person = customerDatabase.ElementAt(randVal);
                if (person.ableToRent(inventory.Count))
                {
                    checkout(person);
                }
            }

            writeToLog("End of day " + day + ":" + Environment.NewLine + "------------------------------------" + Environment.NewLine);

            writeToLog("Start of Night " + day + ":" + Environment.NewLine + "------------------------------------" + Environment.NewLine);



        }

        public void makeMovies()
        {

            Random random = new Random();
            int maxValue = 5;
            int r;
            System.IO.StreamReader comedyFile = new System.IO.StreamReader("Comedy.txt");
            System.IO.StreamReader newFile = new System.IO.StreamReader("NewReleases.txt");
            System.IO.StreamReader horrorFile = new System.IO.StreamReader("Horror.txt");
            System.IO.StreamReader dramaFile = new System.IO.StreamReader("Drama.txt");
            System.IO.StreamReader romanceFile = new System.IO.StreamReader("Romance.txt");

            for(int i = 0; i < 20; i++)
            {
                r = random.Next(maxValue);
                Debug.WriteLine(r);
                if (r == 0)
                {
                    Comedy newComedy = new Comedy(comedyFile.ReadLine());
                    inventory.Add(newComedy);
                }
                else if (r == 1)
                {
                    Horror newHorror = new Horror(horrorFile.ReadLine());
                    inventory.Add(newHorror);
                }
                else if (r == 2)
                {
                    New_Release newrelease = new New_Release(newFile.ReadLine());
                    inventory.Add(newrelease);
                }
                else if (r == 3)
                {
                    Drama newDrama = new Drama(dramaFile.ReadLine());
                    inventory.Add(newDrama);
                }
                else if (r == 4)
                {
                    Romance newRomance = new Romance(romanceFile.ReadLine());
                    inventory.Add(newRomance);
                }

            }

            writeToLog("Number of Videos in the store: " + inventory.Count + Environment.NewLine);
            writeToLog("Videos: "+Environment.NewLine);
            foreach (Video v in inventory)
            {

                writeToLog("Video<" + v.getName() + ", Category<" + v.getType() + ", " + v.getCost() + ">>");
            }

            writeToLog(Environment.NewLine);
            comedyFile.Close();
            newFile.Close();
            horrorFile.Close();
            dramaFile.Close();
            romanceFile.Close();
        }
        public void makeCustomers()
        {
            Random random = new Random();
            int maxValue = 3;
            int r;
            string[] names = {"Bob", "John", "Mary", "Suzanne", "Jerry", "Tom", "Leslie", "Ben", "Ron Swanson", "Tammy 2"};

            for (int i = 0; i < 10; ++i)
            {
                r = random.Next(maxValue);


                if (r == 0)
                {
                    BreezyCustomer cust = new BreezyCustomer(names[i]);
                    customerDatabase.Add(cust);
                }
                else if (r == 1)
                {
                    HoarderCustomer cust = new HoarderCustomer(names[i]);
                    customerDatabase.Add(cust);
                }
                else if (r == 2)
                {
                    RegularCustomer cust = new RegularCustomer(names[i]);
                    customerDatabase.Add(cust);

                }


            }

            writeToLog("Customers: " + Environment.NewLine);
            foreach (Customer c  in customerDatabase)
            {

                writeToLog("Customer: "+c.getNameAndType());
            }
            writeToLog(Environment.NewLine);

        }

        public List<Customer> getCustomers()
        {
            return customerDatabase;
        }
        public Rental createRental(Customer person)
        {
            person.decideNumOfRentals();
            int numOfRentals = person.getNumOfRentals();
            person.decideRentalPeriod();
            int rentalDays = person.getRentalPeriod();
            List<Video> shoppingCart = new List<Video>();
            if (inventory.Count() >= numOfRentals)
            {
                for (int i = 0; i < numOfRentals; i++)
                {
                    shoppingCart.Add(inventory.ElementAt(0));
                    inventory.RemoveAt(0);
                }
            }
            Rental rental = new Rental(shoppingCart, rentalDays + date, date, person.getNameAndType());

            return rental;

        }
        private void setDay(int day)
        {
            date = day;
        }
        public void checkout(Customer person)
        {
            Rental order = createRental(person);
            totalRevenue += order.getTotalCost();
            person.rentMovie(order);
            activeRental.Add(order);
            writeToLog(order.getCustomerNameandType() + ": CREATED RENTAL: " + Environment.NewLine);
            completedRentals.Add(order.getRentalInfo());
            writeToLog(order.getRentalInfo());
        }

        public int getDate()
        {
            return date;
        }

        public List<Video> getInventory()
        {
            return inventory;
        }

        public void checkForReturnedRentals(Rental rental)
        {
             if (activeRental.Count == 0)
             {
                 return;
             }
            activeRental.Remove(rental);
            List<Video> returnList = rental.getVideos();
            foreach (Video video in returnList)
            {
                inventory.Add(video);
            }
        }

        public void printLog()
        {

            System.IO.StreamWriter fileWrite = new System.IO.StreamWriter("output.txt");
            
            foreach (String entry in history)
            {
             fileWrite.WriteLine(entry);
             Debug.WriteLine(entry);
            }

            fileWrite.WriteLine("Number of Videos in the store: " + inventory.Count + Environment.NewLine);
            fileWrite.WriteLine("Videos: " + Environment.NewLine);
            foreach (Video v in inventory)
            {
                
                fileWrite.WriteLine("Video<"+v.getName()+", Category<"+v.getType()+", "+v.getCost()+">>");
            }

            fileWrite.WriteLine(Environment.NewLine+"Total revenue: $" + totalRevenue + Environment.NewLine);
            fileWrite.WriteLine("Number of Active Rentals in the store: " + activeRental.Count + Environment.NewLine);
            fileWrite.WriteLine(Environment.NewLine + "Active Rentals:" + Environment.NewLine);
            foreach (Rental r in activeRental)
            {
                fileWrite.WriteLine(r.getRentalInfo());
            }

            fileWrite.WriteLine("Completed Rentals: " + Environment.NewLine + "-------------------------------" + Environment.NewLine);

            foreach (String s in completedRentals)
            {
                fileWrite.WriteLine(s);
            }

            fileWrite.Close();
        }
        
        public void writeToLog(String s)
        {
            history.Add(s);

        }






    }



}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace groupproject
{
    class CustomerManager
    {
        public string addCustomer(string firstName, string lastName, string phoneNum)
        {
            //if the file customers file is empty  set the customer id to 100 and save the customer info
            if (new FileInfo("C:\\comp2129\\groupprojectgui\\groupprojectgui\\customers.txt").Length == 0)
            {
                //use stream writer in append to save info to file
                using (StreamWriter writetext = File.AppendText("C:\\comp2129\\groupprojectgui\\groupprojectgui\\customers.txt"))
                {
                    //write customer info to customers file
                    writetext.WriteLine(100 + "," + firstName + "," + lastName + "," + phoneNum + "," + "0");
                }
                return "Customer added successfully";
            }
            //else add +1 the last customer id found and save the cutomer info
            else
            {   //read all lines in customers file
                string[] lines = File.ReadAllLines("C:\\comp2129\\groupprojectgui\\groupprojectgui\\customers.txt");

                //check if customer already exists (same first name, last name and phone number as another customer)
                //loop through every line in customer file
                for (int x = 0; x < lines.Length; x++)
                {
                    //split every line into the 3 things we want to check, phone num, last name and first name
                    string[] linesSplit = lines[x].Split(',');
                    //if customer exists return error
                    if (linesSplit[1] == firstName && linesSplit[2] == lastName && linesSplit[3] == phoneNum)
                        return "Customer already exists";
                }
                //read the last line in the customer file to get the id and add 1 to it, its how we make sure to have unique ids
                var lastLine = File.ReadLines("C:\\comp2129\\groupprojectgui\\groupprojectgui\\customers.txt").Last();
                //split the last line
                var lastId = lastLine.Split(',');
                //get the id (always first element) and turn it into an into to add 1 to it 
                int id = Int16.Parse(lastId[0]);
                //add 1 to it
                id++;

                //append the customer using stream writer append mode
                using (StreamWriter writetext = File.AppendText("C:\\comp2129\\groupprojectgui\\groupprojectgui\\customers.txt"))
                {
                    //turn id back into string so we can append it to file
                    string idString = id.ToString();
                    //write to file
                    writetext.WriteLine(idString + "," + firstName + "," + lastName + "," + phoneNum + "," + "0");
                }
                return "Customer added successfully";
            }
        }

        public int findCustomer(string idString)
        {   
            //read every line in customers.txt
            string[] lines = File.ReadAllLines("C:\\comp2129\\groupprojectgui\\groupprojectgui\\customers.txt");       
            
            //loop through every line in customers.txt
            for(int x = 0; x < lines.Length; x++)
            {   
                //StringSplitOptions the line and get the id
                string[] linesSplit = lines[x].Split(',');
                //if you find the id return its locaton int he file
                if (linesSplit[0] == idString)
                    return x;
            }
            //return not found
            return -1;    
        }

        public string removeCustomer(string idString)
        {   
            // find customer location
            int loc = findCustomer(idString);
            //read all lines in customer doc
            string[] lines = File.ReadAllLines("C:\\comp2129\\groupprojectgui\\groupprojectgui\\customers.txt");
            //split the found customer
            string[] linesSplit = lines[loc].Split(',');
            //get the booking amount and turn into an int
            int bookingAmt = Int16.Parse(linesSplit[4]);

            //if customer doesnt exist or  customer has a booking return error
            if (loc == -1) return "Customer not found";
            if (bookingAmt > 0) return "Customer has an active booking";

            //the reason we use this code instead of using the changeline function and replacing the line with an empty string
            //is because if we do there will be an empty space in the folder where the old line used to be and it crashes our program
            //make a temp file
            var tempFile = Path.GetTempFileName();
            //read customers and loop through every line until you find the loc of the customer
            var keepLines = File.ReadLines("C:\\comp2129\\groupprojectgui\\groupprojectgui\\customers.txt").Where(l => l != lines[loc]);
            //write the updates lines into temp file
            File.WriteAllLines(tempFile, keepLines);
            //delete the old file
            File.Delete(("C:\\comp2129\\groupprojectgui\\groupprojectgui\\customers.txt"));
            //replace the customer.txt wth the temp file
            File.Move(tempFile, ("C:\\comp2129\\groupprojectgui\\groupprojectgui\\customers.txt"));

            return "Customer Deleted Successfully";
        }

        public string viewCustomer(string idString)
        {
            //find customer
            int loc = findCustomer(idString);

            //if customer doesnt exist return error
            if (loc == -1)
            {
                return "No customer";
            }
            //read all lines in the file
            string[] lines = File.ReadAllLines("C:\\comp2129\\groupprojectgui\\groupprojectgui\\customers.txt");
            //return the found customer
            return lines[loc];
        }

        public string printAllCustomers()
        {
            //read all lines in customer
            string[] lines = File.ReadAllLines("C:\\comp2129\\groupprojectgui\\groupprojectgui\\customers.txt");

            //empty string to save into
            string s = "";

            // loop through every customer
            for (int i = 0; i < lines.Length; i++)
            {
                //split them and add a description to each attribute they have
                string[] linesSplit = lines[i].Split(',');

                s += "\nCustomer ID: " + linesSplit[0];
                s += "\nFirst Name: " + linesSplit[1];
                s += "\nLast Name: " + linesSplit[2];
                s += "\nBooking Amount: " + linesSplit[3];
                s += "\n";
            }
            return s;
        }
    }
}
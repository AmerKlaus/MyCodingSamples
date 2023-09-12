using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Customer : Person
    {
        private int customerNumber;
        private bool mailingList;
        public Customer(String l, String f, String a, String p, int c, bool m)
            : base(l, f, a, p)
        {
            CustomerNumber = c;
            MailingList = m;
        }
        public int CustomerNumber
        {
            get 
            {
                return customerNumber; 
            }
            set 
            { 
                if(value >= 0)
                {
                    customerNumber = value;
                }
                else
                {
                    customerNumber = 99999;
                    Console.WriteLine("Customer number should be a positive integer value.");
                }
                
            }
        }
        public bool MailingList
        {
            get 
            { 
                return mailingList; 
            }
            set 
            { 
                mailingList = value; 
            }
        }
        public static void drawLine()
        {
            Console.Write("|");
            for (int i = 0; i < 80; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("|");
        }
        public void DisplayRecord()
        {
            String mail = "";
            if(MailingList == true)
            {
                mail = "Yes";
            }
            else if(MailingList == false)
            {
                mail = "No";
            }
            drawLine();
            Console.WriteLine($"| {"PERSON",38}  {"|",40}");
            drawLine();
            Console.WriteLine($"| {"Customer Number",-30} | {CustomerNumber,45} | ");
            Console.WriteLine($"| {"Last Name",-30} | {LastName,-45} |");
            Console.WriteLine($"| {"First Name",-30} | {FirstName,-45} | ");
            Console.WriteLine($"| {"Address",-30} | {Address,-45} | ");
            Console.WriteLine($"| {"Phone Number",-30} | {Phone,45} | ");
            Console.WriteLine($"| {"Mailing List",-30} | {mail,-45} | ");
            drawLine();
        }
    }
}

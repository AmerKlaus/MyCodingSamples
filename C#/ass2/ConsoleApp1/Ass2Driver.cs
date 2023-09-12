using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Ass2Driver
    {
        static void Main(string[] args)
        {
            int cusNum;
            String cusLN;
            String cusFN;
            String addr;
            String phone;
            String mail;
            bool mailist;
            decimal purAmt;

            Console.WriteLine("Enter your Customer Number: ");
            cusNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your Last Name: ");
            cusLN = Console.ReadLine();
            Console.WriteLine("Enter your First Name: ");
            cusFN = Console.ReadLine();
            Console.WriteLine("Enter your Address: ");
            addr = Console.ReadLine();
            Console.WriteLine("Enter your Phone Number: ");
            phone = Console.ReadLine();
            Console.WriteLine("Do you want to be on a Mailing List? (yes or no)");
            mail = Console.ReadLine();
            Console.WriteLine("Enter your Purchased Amount: ");
            purAmt = Convert.ToDecimal(Console.ReadLine());

            if (mail.Equals("yes", StringComparison.InvariantCultureIgnoreCase))
            {
                mailist = true;
            }
            else
            {
                mailist = false;
            }

            Person p = new Person(cusLN, cusFN, addr, phone);
            Customer c = new Customer(cusLN, cusFN, addr, phone, cusNum, mailist);
            PreferredCustomer pc = new PreferredCustomer(cusLN, cusFN, addr, phone, cusNum, mailist, purAmt);

            p.DisplayRecord();
            c.DisplayRecord();
            pc.DisplayRecord();
        }
    }
}

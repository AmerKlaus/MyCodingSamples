using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PreferredCustomer : Customer
    {
        private decimal purchasedAmount;
        private int discountLevel;
        public PreferredCustomer(String l, String f, String a, String p, int c, bool m, decimal pA)
            : base(l, f, a, p, c, m)
        {
            this.PurchasedAmount = pA;
            this.DiscountLevel = discountLevel;
        }
        public decimal PurchasedAmount
        {
            get
            {
                return Math.Abs(purchasedAmount);
            }
            set
            {
                if(value >= 0)
                {
                    purchasedAmount = value;
                }
                else
                {
                    purchasedAmount = 0;
                    Console.WriteLine("Customer purchases amount should be a postive value.");
                }
            }
        }
        public int DiscountLevel
        {
            get
            {
                return discountLevel;
            }
            set
            {
                if (PurchasedAmount >= 500 && PurchasedAmount < 1000)
                {
                    discountLevel = 5;
                }
                else if (PurchasedAmount >= 1000 && PurchasedAmount < 1500)
                {
                    discountLevel = 6;
                }
                else if (PurchasedAmount >= 1500 && PurchasedAmount < 2000)
                {
                    discountLevel = 7;
                }
                else if (PurchasedAmount >= 2000)
                {
                    discountLevel = 10;
                }
                else
                    discountLevel = 0;
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
            if (MailingList == true)
            {
                mail = "Yes";
            }
            else if (MailingList == false)
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
            Console.WriteLine($"| {"Phone Number",-30} | {Phone,-45} | ");
            Console.WriteLine($"| {"Mailing List",-30} | {mail,-45} | ");
            Console.WriteLine($"| {"Purchased Amount",-30} | {"$" + PurchasedAmount,45} | ");
            Console.WriteLine($"| {"Discount Level",-30} | {DiscountLevel + "%",45} | ");
            drawLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Person
    {
        private String lastName;
        private String firstName;
        private String address;
        private String phone;
        public Person(String lastName, String firstName, String address, String phone)
        {
            LastName = lastName;
            FirstName = firstName;
            Address = address;
            Phone = phone;
        }
        public String LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public String FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public String Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public String Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
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
            drawLine();
            Console.WriteLine($"| {"PERSON",38}  {"|",40}");
            drawLine();
            Console.WriteLine($"| {"Last Name",-30} | {LastName,-45} |");
            Console.WriteLine($"| {"First Name",-30} | {FirstName,-45} | ");
            Console.WriteLine($"| {"Address",-30} | {Address,-45} | ");
            Console.WriteLine($"| {"Phone Number",-30} | {Phone,45} | ");
            drawLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName;
            string lastName;
            int birthYear;
            int currentYear;

            Console.WriteLine("Please enter your first name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Please enter your last name: ");
            lastName = Console.ReadLine();
            Console.WriteLine("Please enter your birth year: ");
            birthYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter your current year: ");
            currentYear = Convert.ToInt32(Console.ReadLine());

            HeartRates hr = new HeartRates(firstName, lastName, birthYear, currentYear);
            hr.DisplayPatientRecord();
        }
    }
    public class HeartRates
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int birthYear { get; set; }
        public int currentYear { get; set; }

        public HeartRates(string f, string l, int b, int c)
        {
            firstName = f;
            lastName = l;
            birthYear = b;
            currentYear = c;
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
        public int BirthYear
        {
            get
            {
                return birthYear;
            }
            set
            {
                birthYear = value;
            }
        }
        public int CurrentYear
        {
            get
            {
                return currentYear;
            }
            set
            {
                currentYear = value;
            }
        }

        int ageCal
        {
            get
            {
                return currentYear - birthYear;
            }
        }

        int maxHeartRate
        {
            get
            {
                return 220 - ageCal;
            }
        }

        int maxTargetHeart
        {
            get
            {
                int target;
                target = (int)(maxHeartRate * 0.85);
                return target;
            }
        }

        int minTargetHeart
        {
            get
            {
                int target;
                target = (int)(maxHeartRate * 0.50);
                return target;
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

        public void DisplayPatientRecord()
        {
            drawLine();
            Console.WriteLine($"| {"PATIENT HEART RATE RECORD",53}  {"|",25}");
            drawLine();
            string personName = lastName + ", " + firstName;
            Console.WriteLine($"| {"Patient Name",-30} | {personName,-45} |");
            Console.WriteLine($"| {"Patient Birth Year",-30} | {birthYear,45} | ");
            Console.WriteLine($"| {"Patient Age",-30} | {ageCal,45} | ");
            Console.WriteLine($"| {"Maximum Heart Rate",-30} | {maxHeartRate,45} | ");
            Console.WriteLine($"| {"Target Heart Rate Range",-30} | {minTargetHeart + "---" + maxTargetHeart,45} | ");
            drawLine();
        }
    }
}

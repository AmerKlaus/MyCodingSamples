using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public class HeartRates
    {
        private string firstName;
        private string lastName;
        private int birthYear;
        private int currentYear;

        public HeartRates(string f, string l, int b, int c)
        {
            FirstName = f;
            LastName = l;
            BirthYear = b;
            CurrentYear = c;
        }

        String FirstName
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

        String LastName
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
        int BirthYear
        {
            get
            {
                return birthYear;
            }
            set
            {
                birthYear = Math.Abs(value);
            }
        }
        int CurrentYear
        {
            get
            {
                return currentYear;
            }
            set
            {
                currentYear = Math.Abs(value);
            }
        }

        int AgeCal
        {
            get
            {
                return CurrentYear - BirthYear;
            }
        }

        int MaxHeartRate
        {
            get
            {
                return 220 - AgeCal;
            }
        }

        int MaxTargetHeart
        {
            get
            {
                return (int) (MaxHeartRate * 0.85);
            }
        }

        int MinTargetHeart
        {
            get
            {
                return (int) (MaxHeartRate * 0.50);
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
            Console.WriteLine($"| {"Patient Birth Year",-30} | {BirthYear,45} | ");
            Console.WriteLine($"| {"Patient Age",-30} | {AgeCal,45} | ");
            Console.WriteLine($"| {"Maximum Heart Rate",-30} | {MaxHeartRate,45} | ");
            Console.WriteLine($"| {"Target Heart Rate Range",-30} | {MinTargetHeart + "--" + MaxTargetHeart,45} | ");
            drawLine();
        }
    }
}

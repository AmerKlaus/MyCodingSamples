using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName;
            string lastName;
            int birthYear;
            int height;
            int weight;
            int currentYear;

            Console.WriteLine("Please enter your first name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Please enter your last name: ");
            lastName = Console.ReadLine();
            Console.WriteLine("Please enter your birth year: ");
            birthYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter your height: ");
            height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter your weight: ");
            weight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the current year: ");
            currentYear = Convert.ToInt32(Console.ReadLine());

            HealthProfile hp = new HealthProfile(firstName, lastName, birthYear, height, weight, currentYear);
            hp.DisplayPatientRecord();
        }
    }
    public class HealthProfile
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int birthYear { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public int currentYear { get; set; }

        public HealthProfile(string firstName, string lastName, int birthYear, int height, int weight, int currentYear)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthYear = birthYear;
            this.height = height;
            this.weight = weight;
            this.currentYear = currentYear;
        }

        string FirstName
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
        string LastName
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
                birthYear = value; 
            }
        }
        int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
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
                currentYear = value;
            }
        }
        int Age
        {
            get
            {
                return currentYear - birthYear;
            }
        }
        int HeartRate
        {
            get
            {
                return 220 - Age;
            }
        }
        int MaxHeartRate
        {
            get
            {
                double a = HeartRate * 0.85;
                return (int) a;
            }
        }
        int MinHeartRate
        {
            get
            {
                double a = HeartRate * 0.50;
                return (int) a;
            }
        }

        public double bmiCal()
        {
            return (weight * 703) / (height * height);
        }
        public String bmiText()
        {
            if(bmiCal() < 18.5)
            {
                return "Underweight";
            }
            else if(bmiCal() > 18.5 &&  bmiCal() < 24.9)
            {
                return "Normal";
            }
            else if(bmiCal() > 25 &&  bmiCal() < 29.9)
            {
                return "Overweight";
            }
            else
            {
                return "Obese";
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
            Console.WriteLine($"| {"Patient Age",-30} | {Age,45} | ");
            Console.WriteLine($"| {"Patient Height",-30} | {height,45} | ");
            Console.WriteLine($"| {"Patient Weight",-30} | {weight,45} | ");
            Console.WriteLine($"| {"Maximum Heart Rate",-30} | {HeartRate,45} | ");
            Console.WriteLine($"| {"Target Heart Rate Range",-30} | {MinHeartRate + "---" + MaxHeartRate,45} | ");
            Console.WriteLine($"| {"BMI Numeric Value",-30} | {bmiCal(),45} | ");
            Console.WriteLine($"| {"BMI Text Value",-30} | {bmiText(),-45} | ");
            drawLine();
        }
    }
}

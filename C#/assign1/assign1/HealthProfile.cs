using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign1
{
    public class HealthProfile
    {
        private string firstName;
        private string lastName;
        private int birthYear;
        private int height;
        private int weight;
        private int currentYear;

        public HealthProfile(string firstName, string lastName, int birthYear, int height, int weight, int currentYear)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
            Height = height;
            Weight = weight;
            CurrentYear = currentYear;
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
                birthYear = Math.Abs(value); 
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
                height = Math.Abs(value);
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
                weight = Math.Abs(value);
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
        int Age
        {
            get
            {
                return CurrentYear - BirthYear;
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

        public double BmiCal()
        {
            return (Weight * 703) / (Height * Height);
        }
        public String BmiText()
        {
            double bmi = BmiCal();
            if (bmi < 18.5)
            {
                return "Underweight";
            }
            else if(bmi > 18.5 && bmi < 24.9)
            {
                return "Normal";
            }
            else if(bmi > 25 && bmi < 29.9)
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
            Console.WriteLine($"| {"PATIENT HEALTH RECORD",53}  {"|",25}");
            drawLine();
            string personName = lastName + ", " + firstName;
            Console.WriteLine($"| {"Patient Name",-30} | {personName,-45} |");
            Console.WriteLine($"| {"Patient Birth Year",-30} | {BirthYear,45} | ");
            Console.WriteLine($"| {"Patient Age",-30} | {Age,45} | ");
            Console.WriteLine($"| {"Patient Height",-30} | {Height,45} | ");
            Console.WriteLine($"| {"Patient Weight",-30} | {Weight,45} | ");
            Console.WriteLine($"| {"Maximum Heart Rate",-30} | {HeartRate,45} | ");
            Console.WriteLine($"| {"Target Heart Rate Range",-30} | {MinHeartRate + "--" + MaxHeartRate,45} | ");
            Console.WriteLine($"| {"BMI Numeric Value",-30} | {BmiCal(),45} | ");
            Console.WriteLine($"| {"BMI Text Value",-30} | {BmiText(),-45} | ");
            drawLine();
        }
    }
}

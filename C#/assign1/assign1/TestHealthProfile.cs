using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign1
{
    public class TestHealthProfile
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
}

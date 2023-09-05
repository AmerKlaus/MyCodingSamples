using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class TestHeartRates
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
}

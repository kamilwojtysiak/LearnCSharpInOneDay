using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LearnCSharpInOneDay
{
    class Program
    {
        static void Main(string[] args)
        {
            int _month = 0;
            int _year = 0;

            List<Staff> myStaff = new List<Staff>();
            FileReader fr = new FileReader();

            while (_year == 0)
            {
                Console.WriteLine("Please enter the year");

                try
                {
                    _year = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "Please try again.");

                    _year = 0;
                }
            }

            while (_month == 0)
            {
                Console.WriteLine("Please enter a number of the month.");

                try
                {
                    _month = Convert.ToInt32(Console.ReadLine());

                    if (_month < 1 || _month > 12)
                    {
                        Console.WriteLine("Month must be from 1 to 12.");

                        _month = 0;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "Please try again.");
                }
            }

            myStaff = fr.ReadFile();

            for (int i = 0; i < myStaff.Count; i++)
            {
                try
                {
                    Console.WriteLine($"Enter hours worked for {myStaff[i].NameOfStaff}");

                    myStaff[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                    myStaff[i].CalculatePay();

                    Console.WriteLine(myStaff[i].ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            PaySlip ps = new PaySlip(_month, _year);

            ps.GenerateSummary(myStaff);
            ps.GeneratePaySlip(myStaff);
        }
    }
}

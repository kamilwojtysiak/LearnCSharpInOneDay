using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LearnCSharpInOneDay
{
    public class PaySlip
    {
        private int _month;
        private int _year;

        enum MonthsOfYear
        {
            JAN = 1,
            FEB = 2,
            MAR = 3,
            APR = 4,
            MAY = 5,
            JUN = 6,
            JUL = 7,
            AUG = 8,
            SEP = 9,
            OCT = 10,
            NOV = 11,
            DEC = 12
        }

        public PaySlip(int payMonth, int payYear)
        {
            _month = payMonth;
            _year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;

            foreach (var staff in myStaff)
            {
                path = staff.NameOfStaff + ".txt";

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine($"PAYSLIP FOR {(MonthsOfYear)_month} {_year}");
                    sw.WriteLine("========================");
                    sw.WriteLine($"Name of Staff: {staff.NameOfStaff}");
                    sw.WriteLine($"Hours Worked: {staff.HoursWorked}");
                    sw.WriteLine("");
                    sw.WriteLine($"Basic Pay: {staff.BasicPay}");

                    if (staff.GetType() == typeof(Manager))
                    {
                        sw.WriteLine("Allowance: " + ((Manager)staff).Allowance);
                    }
                    if (staff.GetType() == typeof(Admin))
                    {
                        sw.WriteLine("Allowance: " + ((Admin)staff).Overtime);
                    }

                    sw.WriteLine("");
                    sw.WriteLine("========================");
                    sw.WriteLine($"Total pay: {staff.TotalPay}");
                    sw.WriteLine("========================");

                    sw.Close();
                }
            }
        }

        public void GenerateSummary(List<Staff> myStaff)
        {
            var result =
                from staff in myStaff
                where staff.HoursWorked < 10
                orderby staff.NameOfStaff ascending
                select new { staff.NameOfStaff, staff.HoursWorked };

            string path = "summary.txt";

            StreamWriter sw = new StreamWriter(path);

            sw.WriteLine("Staff with less than 10 working hours");
            sw.WriteLine("");

            foreach (var staff in result)
            {
                sw.WriteLine($"Name of staff: {staff.NameOfStaff}");
            }

            sw.Close();
        }

        public override string ToString()
        {
            return $"Month: {_month} \nYear: {_year}";
        }
    }
}

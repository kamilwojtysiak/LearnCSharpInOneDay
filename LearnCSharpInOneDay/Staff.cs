using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace LearnCSharpInOneDay
{
    public class Staff
    {
        private float _hourlyRate;
        private int _hWorked;

        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }

        public float HoursWorked
        {
            get 
            {
                return _hWorked; 
            }
            set 
            {
                if (HoursWorked > 0)
                {
                    value = _hWorked;
                }
                else
                {
                    _hWorked = 0;
                }
            }
        }

        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            _hourlyRate = rate;
        }

        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating pay...");

            BasicPay = HoursWorked * _hourlyRate;

            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return $"Hours worked = {HoursWorked} \nHourly rate = {_hourlyRate} \nTotal pay = {TotalPay}";
        }
    }
}

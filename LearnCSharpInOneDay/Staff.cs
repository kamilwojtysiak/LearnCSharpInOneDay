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

        public int HoursWorked
        {
            get 
            {
                return _hWorked; 
            }
            set 
            {
                if (value > 0)
                {
                    _hWorked = value;
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
            return $"Hours worked = {_hWorked} \nHourly rate = {_hourlyRate} \nTotal pay = {TotalPay}";
        }
    }
}

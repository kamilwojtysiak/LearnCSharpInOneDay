using System;
using System.Collections.Generic;
using System.Text;

namespace LearnCSharpInOneDay
{
    public class Manager : Staff
    {
        private const float _managerHourlyRate = 50;

        public int Allowance { get; private set; }

        public Manager(string name) : base(name, _managerHourlyRate)
        {

        }

        public override void CalculatePay()
        {
            base.CalculatePay();

            Allowance = 1000;

            if (HoursWorked > 160)
            {
                TotalPay += Allowance;
            }
        }

        public override string ToString()
        {
            return $"Manager hours worked = {HoursWorked} \nManager hourly rate = {_managerHourlyRate} \nManager total pay = {TotalPay}";
        }
    }
}

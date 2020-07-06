using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace LearnCSharpInOneDay
{
    public class Admin: Staff
    {
        private const float _overtimeRate = 15.5f;
        private const float _adminhourlyRate = 30f;

        public float Overtime { get; private set; }

        public Admin(string name) : base(name, _adminhourlyRate)
        {

        }

        public override void CalculatePay()
        {
            base.CalculatePay();

            if (HoursWorked > 160)
            {
                Overtime = _overtimeRate * (160 - HoursWorked);

                TotalPay += Overtime;
            }
        }

        public override string ToString()
        {
            return $"Admin hours worked = {HoursWorked} \nAdmin hourly rate = {_adminhourlyRate} \nTotal pay = {TotalPay}";
        }
    }
}

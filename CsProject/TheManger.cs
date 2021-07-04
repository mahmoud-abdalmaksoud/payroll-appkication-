using System;
using System.Collections.Generic;
using System.Text;

namespace CsProject
{
    class Manger : Staff 
    {
        private const float mangerHourlyRate = 50;
        public int Allowance { get; private set; }

        public Manger(string name) : base(name, mangerHourlyRate) { }


        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;
            if (HoursWorked > 160)
                TotalPay = BasicPay + Allowance;
        }
        public override string ToString()
        {
            return
                 "/nNameOfStaff = " + NameOfStaff
                 + "\nmangerHourlyRate = " + mangerHourlyRate
                 + "\nHoursWorked = " + HoursWorked
                 + "\nBasicPay = " + BasicPay
                 + "\nAllowance = " + Allowance;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CsProject
{
    class Admin : Staff
    {
        private const float overtimeRate = 15.5f ;
        private const float adminHourlyRate = 30f;
        public float Overtime { get; private set; }

        public Admin(string name) : base(name, adminHourlyRate) { }

        public override void CalculatePay()
        {
            base.CalculatePay();

            if (HoursWorked > 160)
                Overtime = overtimeRate * (HoursWorked - 160);
        }

        public override string ToString()
        {
            return
                "\nNameOfStaff = " + NameOfStaff +
                "\nAdminHourlyRate = " + adminHourlyRate +
                "\nHoursWorkeed = " + HoursWorked +
                "\nBasicPay = " + BasicPay +
                "\nOvertime = " + Overtime +
                "\n\nTotoaPay = " + TotalPay;
        }




    }
}

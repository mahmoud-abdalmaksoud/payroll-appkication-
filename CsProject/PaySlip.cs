using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CsProject
{
    class PaySlip
    {
        private int month;
        private int year;
        enum MonthsOfYear { JAN = 1,FEB=2, MAR,APR,MAY,JUN,JL,AUG,SEP,OCT,NOV,DEC}

        public PaySlip(int payMonth , int PayYear)
        {
            month = payMonth;
            year = PayYear;
        }
        public void generatePaySlip(List<Staff> myStaff)
        {
            string path;
            foreach(Staff f in myStaff)
            {
                path = f.NameOfStaff + ".txt";
                using (StreamWriter sw = new StreamWriter(path)) 
                {
                    sw.WriteLine("PaySlip for: {0}  {1}", (MonthsOfYear)month, year);
                    sw.WriteLine("===========================");
                    sw.WriteLine("Name of staff: {0}", f.NameOfStaff);
                    sw.WriteLine("HoursWorked: {0}", f.HoursWorked);
                    sw.WriteLine("");
                    sw.WriteLine("Basic Pay: {0,c}", f.BasicPay);
                    if (f.GetType() == typeof(Manger))
                        sw.WriteLine("Allowance: {0:c}", ((Manger)f).Allowance);
                    else if (f.GetType() == typeof(Admin))
                        sw.WriteLine("overTime: {0,c}", ((Admin)f).Overtime);
                    sw.WriteLine(" ");
                    sw.WriteLine("========================== ");
                    sw.Close();
                }

                }
            }
    public void GenerateSummary(List<Staff> mystaff)
        {
            var result
                = from f in mystaff
                  where f.HoursWorked < 10
                  orderby f.NameOfStaff ascending
                  select new { f.NameOfStaff, f.HoursWorked };
            string path = "summary.txt";
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Staff with less than 10 working hours");
                sw.WriteLine("");
                foreach (var f in result)
                    sw.WriteLine("Name of Staff :{0} ,Hours Worked: {1}", f.NameOfStaff, f.HoursWorked);
                sw.Close();
            }

        }
        public override string ToString()
        {
            return "month = " + month + "year = " + year;
        }
    }
    }


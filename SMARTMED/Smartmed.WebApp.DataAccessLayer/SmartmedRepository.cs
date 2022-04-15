using System;
using System.Collections.Generic;
using System.Text;
using Smartmed.WebApp.DataAccessLayer.Models;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace Smartmed.WebApp.DataAccessLayer
{
    public class SmartmedRepository
    {
        SMARTMEDContext context;
        public SmartmedRepository()
        {
            context = new SMARTMEDContext();
        }

        public List<Medicine> ViewMedicine()
        {
            
            var categoriesList = (from med in context.Medicine select med ).ToList();
            return categoriesList;
        }

        [Obsolete]
        public int add_medicine_Quantity(String newMedicineName, decimal? cost, decimal? newMedicineQuantity, int percent, DateTime? expDate)
        {
            int result = 0;
            int returnresult = 0;
            SqlParameter prmnewmedicinename = new SqlParameter("@newMedicineName", newMedicineName);
            SqlParameter prmcost = new SqlParameter("@Cost", cost);
            SqlParameter prmnewmedicinequantity = new SqlParameter("@newMedicineQuantity", newMedicineQuantity);
            SqlParameter prmpercent = new SqlParameter("@percent", percent);
            SqlParameter prmexpdate = new SqlParameter("@expDate", expDate);

            SqlParameter prmreturnvalue = new SqlParameter("@retvalue", System.Data.SqlDbType.TinyInt);
            prmreturnvalue.Direction = System.Data.ParameterDirection.Output;

            result = context.Database.ExecuteSqlCommand("EXEC @retvalue=add_medicine_quantity @newMedicineName , @Cost, @newMedicineQuantity, @percent, @expDate", new[] { prmreturnvalue, prmnewmedicinename, prmcost, prmnewmedicinequantity, prmpercent, prmexpdate });
            returnresult = Convert.ToInt32(prmreturnvalue.Value);
            return returnresult;
        }      
    
        public int check_bed(string bedno)
        {
            int result;
            int returnresult = 0;
            SqlParameter prmbedno = new SqlParameter("@bedno", bedno);
            SqlParameter prmreturnvalue = new SqlParameter("@retvalue", System.Data.SqlDbType.TinyInt);
            prmreturnvalue.Direction = System.Data.ParameterDirection.Output;

            result = context.Database.ExecuteSqlCommand("EXEC @retvalue=check_bed @bedno", new[] { prmreturnvalue, prmbedno });
            returnresult = Convert.ToInt32(prmreturnvalue.Value);
            return returnresult;

        }

        public List<ActivePatient> view_active_patient(string bedno)
        {
            List<ActivePatient> activePatients = null;
            try
            {
                activePatients = (from med in context.ActivePatient where med.BedNumber == bedno select med).ToList();

            }
            catch (Exception e)
            {
                activePatients = null;
                Console.WriteLine(e.Message);
            }    
            return activePatients;
        }

        public List<NonActivePatient> view_non_active_patient(string uid)
        {
            List<NonActivePatient> nonActivePatients = null;
            try
            {
                nonActivePatients = (from med in context.NonActivePatient where med.UniqueId==uid select med).ToList();

            }
            catch (Exception e)
            {
                nonActivePatients = null;
                Console.WriteLine(e.Message);
            }
            return nonActivePatients;
        }


        public int register_activePatient(string bedno,string name,string description,long phone_no,long doctor_id)
        {
            int result=0,returnresult=0;
            string temp = null;
            SqlParameter prmbedno = new SqlParameter("@bedno", bedno);
            SqlParameter prmname = new SqlParameter("@name", name);
            SqlParameter prmdescription = new SqlParameter("@description", description);
            SqlParameter prmphoneno = new SqlParameter("@phone_no", phone_no);
            SqlParameter prmdoctorid = new SqlParameter("@doctor_id", doctor_id);
            
            SqlParameter prmreturnvalue = new SqlParameter("@retvalue", System.Data.SqlDbType.TinyInt);
            prmreturnvalue.Direction = System.Data.ParameterDirection.Output;
            result = context.Database.ExecuteSqlCommand("EXEC @retvalue=register_patient @bedno,@name,@description,  @phone_no,  @doctor_id ", new[] { prmreturnvalue, prmbedno, prmname, prmdescription, prmphoneno, prmdoctorid });
            returnresult = Convert.ToInt32(prmreturnvalue.Value);
            return returnresult;
        }


        public int register_doctor(string doc_name,string certified_in,long phn_no)
        {
            Doctor doctor = new Doctor();
            try
            {
                doctor.DoctorName = doc_name;
                doctor.CertifiedIn = certified_in;
                doctor.PhoneNo = phn_no;

                context.Doctor.Add(doctor);
                context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }


        public List<Doctor> view_Doctor_button(long doc_id)
        {
            List<Doctor> doctors = null;
            try
            {
                doctors = (from med in context.Doctor where med.DoctorId == doc_id select med).ToList();
            }
            catch (Exception)
            {

                doctors = null;
            }
            return doctors;
        }


        public int add_medicine_button(string bed_no,string med_name,int quantity)
        {
            int result = 0, returnresult = 0;
            SqlParameter prmbedno = new SqlParameter("@bedno", bed_no);
            SqlParameter prmmedname = new SqlParameter("@med_name", med_name);
            SqlParameter prmquantity = new SqlParameter("@quantity", quantity);

            SqlParameter prmreturnvalue = new SqlParameter("@retvalue", System.Data.SqlDbType.TinyInt);
            prmreturnvalue.Direction = System.Data.ParameterDirection.Output;

            result = context.Database.ExecuteSqlCommand("EXEC @retvalue=add_medicine @bedno,@med_name,@quantity", new[] { prmreturnvalue, prmbedno, prmmedname, prmquantity });
            returnresult = Convert.ToInt32(prmreturnvalue.Value);
            return returnresult;
        }



        public int update_patient_button(string bedno,string new_description,DateTime new_time,long new_phn_no,long doc_id)
        {
            int result, returnresult = 0;
            SqlParameter prmbedno = new SqlParameter("@bedno", bedno);
            SqlParameter prmdescription = new SqlParameter("@new_description", new_description);
            SqlParameter prmnewtime = new SqlParameter("@new_time", new_time);
            SqlParameter prmnewphn = new SqlParameter("@new_phn_no", new_phn_no);
            SqlParameter prmdocid = new SqlParameter("@doc_id", doc_id);

            SqlParameter prmreturnvalue = new SqlParameter("@retvalue", System.Data.SqlDbType.TinyInt);
            prmreturnvalue.Direction = System.Data.ParameterDirection.Output;

            result = context.Database.ExecuteSqlCommand("EXEC @retvalue=update_patient @bedno, @new_description, @new_time, @new_phn_no, @doc_id", new[] { prmreturnvalue, prmbedno, prmdescription, prmnewtime, prmnewphn, prmdocid });
            returnresult = Convert.ToInt32(prmreturnvalue.Value);
            return returnresult;
        }



        public int add_bill_button(string bedno,long money,string reason)
        {
            int result, returnresult = 0;
            SqlParameter prmbedno = new SqlParameter("@bedno", bedno);
            SqlParameter prmmoney = new SqlParameter("@money", money);
            SqlParameter prmreason = new SqlParameter("@reason", reason);

            SqlParameter prmreturnvalue = new SqlParameter("@retvalue", System.Data.SqlDbType.TinyInt);
            prmreturnvalue.Direction = System.Data.ParameterDirection.Output;

            result = context.Database.ExecuteSqlCommand("EXEC @retvalue=add_bill @bedno,@money,@reason", new[] { prmreturnvalue, prmbedno, prmmoney, prmreason });
            returnresult = Convert.ToInt32(prmreturnvalue.Value);
            return returnresult;
        }



        public int remove_patient_button(string uid,string bedno)
        {
            int result, returnresult = 0;
            SqlParameter prmbedno = new SqlParameter("@bedno", bedno);
            SqlParameter prmuid = new SqlParameter("@uid", uid);

            SqlParameter prmreturnvalue = new SqlParameter("@retvalue", System.Data.SqlDbType.TinyInt);
            prmreturnvalue.Direction = System.Data.ParameterDirection.Output;

            result = context.Database.ExecuteSqlCommand("EXEC @retvalue=remove_patient @uid,@bedno", new[] { prmreturnvalue, prmuid, prmbedno });
            returnresult = Convert.ToInt32(prmreturnvalue.Value);
            return returnresult;
        }


        public string final_billAmount_button(string bedno)
        {
            List<ActivePatient> activePatients = (from med in context.ActivePatient where med.BedNumber == bedno select med).ToList();
            int medcost = Convert.ToInt32(activePatients[0].MedicineCost);
            string medicine_name = activePatients[0].MedicineName;
            int totalcost = 0;
            string bill = "";

            List<Bill> bills = (from med in context.Bill where med.BedNumber == bedno select med).ToList();
            foreach (var item in bills)
            {
                bill+=item.Reason+"\t"+item.Amount+"\t"+item.Dates+"\n";
            }

            SqlParameter prmbedno = new SqlParameter("@bedno", bedno);
            SqlParameter prmreturnvalue = new SqlParameter("@retvalue", System.Data.SqlDbType.TinyInt);
            prmreturnvalue.Direction = System.Data.ParameterDirection.Output;

            context.Database.ExecuteSqlCommand("EXEC @retvalue=get_bill @bedno", new[] { prmreturnvalue, prmbedno });
            int returnvalue = Convert.ToInt32(prmreturnvalue.Value);
            if(returnvalue>0)
            {
                bill += "The Bill Cost is: " + returnvalue+"\n\n";
                bill += "The medicine required is: " + medicine_name+"\nThe Medicine Cost is: "+medcost+"\n\n";
                bill += "\n\n\nThe Final Amount is: \n";
                totalcost = medcost + returnvalue;
                bill += totalcost;
                return bill;
            }
            else
            {
                bill = "Something Went Wrong";
                return bill;
            }
        }



        public int get_job_role(string email)
        {
            SqlParameter prmemail = new SqlParameter("@email", email);
            SqlParameter prmreturnvalue = new SqlParameter("@retvalue", System.Data.SqlDbType.TinyInt);
            prmreturnvalue.Direction = System.Data.ParameterDirection.Output;

            context.Database.ExecuteSqlCommand("EXEC @retvalue=get_job_role @email", new[] { prmreturnvalue, prmemail });
            int returnresult = 0;
            returnresult= Convert.ToInt32(prmreturnvalue.Value);
            return returnresult;
        }



        public int register_staff(string email,string name,long phn,int job_role)
        {
            Credential credential = new Credential();
            try
            {
                credential.Email = email;
                credential.Name = name;
                credential.PhoneNumber = phn;
                credential.JobRole = job_role;

                context.Credential.Add(credential);
                context.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {

                return -1;
            }
        }



        public List<Doctor> viewDoctors()
        {
            List<Doctor> doctors = null;
            try
            {
                doctors = (from med in context.Doctor select med).ToList();
            }
            catch (Exception)
            {

                doctors = null;
            }
            return doctors;
        }



        public int addExpense(string field,int amount)
        {
            SqlParameter prmfield = new SqlParameter("@field", field);
            SqlParameter prmamount = new SqlParameter("@amount", amount);
            SqlParameter prmreturnvalue = new SqlParameter("@retvalue", System.Data.SqlDbType.TinyInt);
            prmreturnvalue.Direction = System.Data.ParameterDirection.Output;

            context.Database.ExecuteSqlCommand("EXEC @retvalue=add_expense @field,@amount", new[] { prmreturnvalue, prmfield,prmamount });
            int returnresult = 0;
            returnresult = Convert.ToInt32(prmreturnvalue.Value);
            return returnresult;
        }



        //ANALYSIS
        public List<int> analysisMedicine(int year)
        {
            var temp = (from p in context.Income where p.Dates.Value.Year == year group p by p.Dates.Value.Month into mg select new { month = mg.Key, sum = mg.Sum(z => z.Income1) });
            List<int> month = new List<int>();
            List<int> sum = new List<int>();
            for (int i = 0; i < 12; i++)
                sum.Add(0);
            foreach (var item in temp)
            {
                sum[item.month - 1] = Convert.ToInt32(item.sum);

            }

            return sum;
        }



        public List<int> singleYearExpense(int year)
        {
            var temp = (from p in context.Expense where p.Dates.Value.Year==year group p by p.Field into mg select new { field=mg.Key,sum=mg.Sum(z=>z.Expense1)});
            List<int> month = new List<int>();
            List<int> sum = new List<int>();
            for (int i = 0; i < 6; i++)
                sum.Add(0);
            foreach (var item in temp)
            {
                if (item.field.Equals("MEDICINE"))
                    sum[0] =Convert.ToInt32(item.sum);
                else if (item.field.Equals("STAFF"))
                    sum[1] =Convert.ToInt32(item.sum);
                else if (item.field.Equals("DEVELOPMENT"))
                    sum[2] = Convert.ToInt32(item.sum);
                else if (item.field.Equals("TAX"))
                    sum[3] = Convert.ToInt32(item.sum);
                else if (item.field.Equals("ELECTRICITY"))
                    sum[4] = Convert.ToInt32(item.sum);
                else if (item.field.Equals("MISCELLANEOUS"))
                    sum[5] = Convert.ToInt32(item.sum);
            }
            return sum;
        }



        public List<int> MultiyearExpense(int year1,int year2)
        {
            var temp = (from p in context.Expense where p.Dates.Value.Year >= year1 && p.Dates.Value.Year<=year2 group p by p.Field into mg select new { field = mg.Key, sum = mg.Sum(z => z.Expense1) });
            List<int> month = new List<int>();
            List<int> sum = new List<int>();
            for (int i = 0; i < 6; i++)
                sum.Add(0);

            foreach (var item in temp)
            {
                if (item.field.Equals("MEDICINE"))
                    sum[0] = Convert.ToInt32(item.sum);
                else if (item.field.Equals("STAFF"))
                    sum[1] = Convert.ToInt32(item.sum);
                else if (item.field.Equals("DEVELOPMENT"))
                    sum[2] = Convert.ToInt32(item.sum);
                else if (item.field.Equals("TAX"))
                    sum[3] = Convert.ToInt32(item.sum);
                else if (item.field.Equals("ELECTRICITY"))
                    sum[4] = Convert.ToInt32(item.sum);
                else if (item.field.Equals("MISCELLANEOUS"))
                    sum[5] = Convert.ToInt32(item.sum);
            }
            return sum;

        }



        public List<int> totalMonthlyExpense(int year)
        {
            var temp = (from p in context.Expense where p.Dates.Value.Year==year group p by p.Dates.Value.Month into mg select new { month=mg.Key,sum=mg.Sum(z=>z.Expense1)});
            List<int> month = new List<int>();
            List<int> sum = new List<int>();
            for (int i = 0; i < 12; i++)
                sum.Add(0);
            foreach (var item in temp)
            {
                sum[item.month - 1] = Convert.ToInt32(item.sum);

            }
            return sum;
        }



        public List<int> totalMultiyearlyExpense(int year1,int year2)
        {
            var temp = (from p in context.Expense where p.Dates.Value.Year >= year1 && p.Dates.Value.Year<=year2 group p by p.Dates.Value.Year into mg select new { year = mg.Key, sum = mg.Sum(z => z.Expense1) });
            List<int> month = new List<int>();
            List<int> sum = new List<int>();
            for (int i = 0; i < (year2-year1)+1; i++)
                sum.Add(0);
            foreach (var item in temp)
            {
                sum[item.year - year1] =Convert.ToInt32(item.sum);
            }
            return sum;
        }


        //INCOME ANALYSIS
        public List<int> singleYearIncome(int year)
        {
            var temp = (from p in context.Income where p.Dates.Value.Year == year group p by p.Field into mg select new { field = mg.Key, sum = mg.Sum(z => z.Income1) });
            List<int> month = new List<int>();
            List<int> sum = new List<int>();
            for (int i = 0; i < 3; i++)
                sum.Add(0);
            foreach (var item in temp)
            {
                if (item.field.Equals("MEDICINE"))
                    sum[0] = Convert.ToInt32(item.sum);
                else if (item.field.Equals("TEST"))
                    sum[1] = Convert.ToInt32(item.sum);
                else if (item.field.Equals("Patient"))
                    sum[2] = Convert.ToInt32(item.sum);
               
            }
            return sum;
        }



        public List<int> MultiyearIncome(int year1,int year2)
        {
            var temp = (from p in context.Income where p.Dates.Value.Year >= year1 && p.Dates.Value.Year <= year2 group p by p.Field into mg select new { field = mg.Key, sum = mg.Sum(z => z.Income1) });
            List<int> month = new List<int>();
            List<int> sum = new List<int>();
            for (int i = 0; i < 3; i++)
                sum.Add(0);

            foreach (var item in temp)
            {
                if (item.field.Equals("MEDICINE"))
                    sum[0] = Convert.ToInt32(item.sum);
                else if (item.field.Equals("TEST"))
                    sum[1] = Convert.ToInt32(item.sum);
                else if (item.field.Equals("Patient"))
                    sum[2] = Convert.ToInt32(item.sum);
                
            }
            return sum;
        }



        public List<int> totalMonthlyIncome(int year)
        {
            var temp = (from p in context.Income where p.Dates.Value.Year == year group p by p.Dates.Value.Month into mg select new { month = mg.Key, sum = mg.Sum(z => z.Income1) });
            List<int> month = new List<int>();
            List<int> sum = new List<int>();
            for (int i = 0; i < 12; i++)
                sum.Add(0);
            foreach (var item in temp)
            {
                sum[item.month - 1] = Convert.ToInt32(item.sum);

            }
            return sum;
        }



        public List<int> totalMultiyearlyIncome(int year1,int year2)
        {
            var temp = (from p in context.Income where p.Dates.Value.Year >= year1 && p.Dates.Value.Year <= year2 group p by p.Dates.Value.Year into mg select new { year = mg.Key, sum = mg.Sum(z => z.Income1) });
            List<int> month = new List<int>();
            List<int> sum = new List<int>();
            for (int i = 0; i < (year2 - year1) + 1; i++)
                sum.Add(0);
            foreach (var item in temp)
            {
                sum[item.year - year1] = Convert.ToInt32(item.sum);
            }
            return sum;
        }



        public List<Medicine> getExpiryMedicine()
        {
            List<Medicine> medicines = null;
            try
            {
                var temp = (from p in context.Medicine where p.ExpiryDate <= DateTime.Now.Date select p).ToList();
                medicines = temp;
            }
            catch (Exception)
            {
                medicines = null;
            }
            return medicines;
        }

    }
}

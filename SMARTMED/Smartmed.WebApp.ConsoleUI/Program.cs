using System;
using Smartmed.WebApp.DataAccessLayer.Models;
using Smartmed.WebApp.DataAccessLayer;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Smartmed.WebApp.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartmedRepository repository = new SmartmedRepository();
            List<Medicine> medicines= repository.getExpiryMedicine();
            foreach (var item in medicines)
            {
                Console.WriteLine(item.MedicineName+" "+item.ExpiryDate);
            }
            Program p = new Program();
            //p.ggg();
            //p.gg();
            {
                //var temp = repository.ViewMedicine();
                //foreach (var item in temp)
                //{
                //    Console.WriteLine(item.MedicineName + "\t" + item.Cost + "\t" + item.Quantity + "\t" + item.ExpiryDate + "\n");
                //}



                //int result=repository.add_medicine_Quantity("Flipkart", 40, 1, 10, DateTime.Now.ToString("yyyy-MM-dd"));
                //Console.WriteLine(result);


                //int result = repository.check_bed("G102");
                //Console.WriteLine(result);


                //List<ActivePatient> res = repository.view_active_patient("G102");
                //foreach (var item in res)
                //{

                //    Console.WriteLine(item.BedNumber+"\t"+item.Description + "\t" +item.DateOfArrival + "\t" +item.ExpectedDateOfDischarge + "\t" +item.MedicineCost + "\t" +item.MedicineName + "\t" +item.PhoneNo + "\t" +item.DoctorId);
                //}



                //List<NonActivePatient> res = repository.view_non_active_patient("123456");
                //foreach (var item in res)
                //{

                //    Console.WriteLine(item.UniqueId+"\t"+item.Name + "\t" +item.MedicineName);
                //}


                //int result = repository.register_activePatient("G103", "Lucifer", "Heart Problem", DateTime.Now.ToString("yyyy-MM-dd"),987456 , 1);
                //Console.WriteLine(result);



                //Console.WriteLine(repository.register_doctor("Bruce Banner","All Type",8617283014));



                //List<Doctor> res = repository.view_Doctor_button(2);
                //foreach (var item in res)
                //{

                //    Console.WriteLine(item.DoctorId + "\t" + item.DoctorName + "\t" + item.CertifiedIn);
                //}



                //Console.WriteLine(repository.add_medicine_button("G108","Capagin",2));



                //Console.WriteLine(repository.update_patient_button("G108","Heart Break",new DateTime(2020,04,01),7896541236,1));



                //Console.WriteLine(repository.add_bill_button("G108",4,"TAX"));



                //Console.WriteLine(repository.remove_patient_button("0000","G102"));



                //Console.WriteLine(repository.final_billAmount_button("G103"));



                //Console.WriteLine(repository.get_job_role("shasilajit@gmail.com"));



                //Console.WriteLine(repository.register_staff("sb@bal.com","Siddartha",9331221379,3));

                //repository.MultiyearExpense(2018,2020);

                //repository.totalMonthlyExpense(2020);

                //repository.totalMultiyearlyExpense(2018, 2020);
            }
        }

        public void ggg()
        {
            Random rnd = new Random();
            for(int i=0;i<50;i++)
            {
                int year = rnd.Next(2015, 2020);
                int days = rnd.Next(1, 28);
                int month = rnd.Next(1, 13);

                int fieldincome = rnd.Next(0, 3);
                string[] income = new string[3];
                int amount = rnd.Next(1000,3000);

                income[0] = "MEDICINE";
                income[1] = "TEST";
                income[2] = "Patient";
                Console.WriteLine("insert into income values('" +income[fieldincome]+"',"+amount+",'"+year+"-"+month+"-"+days+"')");
            }
        }

        public void gg()
        {
            Random rnd = new Random();
            for (int i = 0; i < 50; i++)
            {
                int year = rnd.Next(2015, 2020);
                int days = rnd.Next(1, 28);
                int month = rnd.Next(1, 13);

                int fieldexpense = rnd.Next(0, 6);
                string[] expense = new string[6];
                int amount = rnd.Next(800, 2000);

                expense[0] = "MEDICINE";
                expense[1] = "STAFF";
                expense[2] = "DEVELOPMENT";
                expense[3] = "TAX";
                expense[4] = "ELECTRICITY";
                expense[5] = "MISCELLANEOUS";


                Console.WriteLine("insert into expense values('" + expense[fieldexpense] + "'," + amount + ",'" + year + "-" + month + "-" + days + "')");
            }
        }
    }
}

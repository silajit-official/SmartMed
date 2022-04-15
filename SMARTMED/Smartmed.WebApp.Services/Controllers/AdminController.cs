using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smartmed.WebApp.Services.Models;
using Smartmed.WebApp.DataAccessLayer;
using Smartmed.WebApp.Services.HelpingClass;

namespace Smartmed.WebApp.Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : Controller
    {
        public JsonResult ViewMedicine()
        {
            SmartmedRepository repository = new SmartmedRepository();
            List<Smartmed.WebApp.DataAccessLayer.Models.Medicine> medicines = new List<DataAccessLayer.Models.Medicine>();
            List<Medicine> medicines1 = new List<Medicine>();
            try
            {
                medicines = repository.ViewMedicine();
                foreach (var item in medicines)
                {
                    medicines1.Add(new Medicine()
                    {
                        MedicineName = item.MedicineName,
                        Cost = item.Cost,
                        ExpiryDate = item.ExpiryDate,
                        Quantity = item.Quantity
                    });
                }
            }
            catch (Exception)
            {

                medicines1 = null;
            }
            return Json(medicines1);
        }

       
        public int add_medicine_Quantity(add_medicine_Quantity med)
        {
            SmartmedRepository repository = new SmartmedRepository();
            int a = repository.add_medicine_Quantity(med.MedicineName, med.Cost, med.Quantity, med.Rebate, med.ExpiryDate);
            return a;
        }


        public int check_bed(string bedno)
        {
            SmartmedRepository repository = new SmartmedRepository();
            return repository.check_bed(bedno);
        }


        public JsonResult view_active_patient(string bedno)
        {
            SmartmedRepository repository = new SmartmedRepository();
            return Json(repository.view_active_patient(bedno));
        }


        public JsonResult view_non_active_patient(string uid)
        {
            SmartmedRepository repository = new SmartmedRepository();
            return Json(repository.view_non_active_patient(uid));
        }


        public int register_activePatient(register_activePatient doc)
        {
            SmartmedRepository repository = new SmartmedRepository();
            return repository.register_activePatient(doc.bedno, doc.name, doc.description, doc.phone_no, doc.doctor_id);
        }
        

        public int register_doctor(Doctor doctor)
        {
            SmartmedRepository repository = new SmartmedRepository();
            return repository.register_doctor(doctor.DoctorName, doctor.CertifiedIn, doctor.PhoneNo);
        }


        public JsonResult view_Doctor_button(long docid)
        {
            SmartmedRepository repository = new SmartmedRepository();
            List<Smartmed.WebApp.DataAccessLayer.Models.Doctor> doctors = new List<DataAccessLayer.Models.Doctor>();
            List<Doctor> doctors1 = new List<Doctor>();
            try
            {
                doctors = repository.view_Doctor_button(docid);
                foreach (var item in doctors)
                {
                    doctors1.Add(new Doctor()
                    {
                        DoctorId = item.DoctorId,
                        DoctorName = item.DoctorName,
                        CertifiedIn = item.CertifiedIn,
                        PhoneNo = item.PhoneNo
                    });
                }
            }
            catch (Exception)
            {

                doctors1 = null;
            }
            return Json(doctors1);
        }


        public int add_medicine_button(HelpingClass.add_medicine_button med)
        {
            SmartmedRepository repository = new SmartmedRepository();
            return repository.add_medicine_button(med.bed_no,med.med_name,med.quantity);
        }


        public int update_patient_button(HelpingClass.update_patient_button patient)
        {
            SmartmedRepository repository = new SmartmedRepository();
            return repository.update_patient_button(patient.bedno, patient.new_description, patient.new_time, patient.new_phn_no, patient.doc_id);
        }


        public int add_bill_button(HelpingClass.add_bill_button bill)
        {
            SmartmedRepository repository = new SmartmedRepository();
            return repository.add_bill_button(bill.bedno, bill.money, bill.reason);
        }


        public int remove_patient_button(HelpingClass.remove_patient_button pat)
        {
            SmartmedRepository repository = new SmartmedRepository();
            return repository.remove_patient_button(pat.UID, pat.bedno);

        }


        public string final_billAmount_button(string bedno)
        {
            SmartmedRepository repository = new SmartmedRepository();
            return repository.final_billAmount_button(bedno);
        }


        public int get_job_role(string email)
        {
            SmartmedRepository repository = new SmartmedRepository();
            return repository.get_job_role(email);
        }


        public int register_staff(HelpingClass.register_staff staff)
        {
            SmartmedRepository repository = new SmartmedRepository();
            return repository.register_staff(staff.email, staff.name, staff.phone, staff.job_role);
        }


        public List<Doctor> viewAllMedicine()
        {
            SmartmedRepository repository = new SmartmedRepository();
            List<Smartmed.WebApp.DataAccessLayer.Models.Doctor> doctors = new List<DataAccessLayer.Models.Doctor>();
            List<Doctor> doctors1 = new List<Doctor>();
            try
            {
                doctors = repository.viewDoctors();
                foreach (var item in doctors)
                {
                    doctors1.Add(new Doctor()
                    {
                        DoctorId=item.DoctorId,
                        CertifiedIn=item.CertifiedIn,
                        DoctorName=item.DoctorName,
                        PhoneNo=item.PhoneNo
                    });
                  
                }
            }
            catch (Exception)
            {

                doctors1 = null;
            }
            return doctors1;
        }

        public int addExpense(add_expense ex)
        {
            SmartmedRepository repository = new SmartmedRepository();
            return repository.addExpense(ex.field,ex.amount);
        }

        //ANALYSIS
        public List<int> analysisMedicine(int year)
        {
            SmartmedRepository repository = new SmartmedRepository();
            return (repository.analysisMedicine(year));
        }



        public List<int> singleYearExpense(int year)
        {
            SmartmedRepository repository = new SmartmedRepository();
            return repository.singleYearExpense(year);
        }

        public List<int> MultiyearExpense(int year)
        {
            int year1, year2;
            year1 = year / 10000;
            year2 = year % 10000;
            SmartmedRepository repository = new SmartmedRepository();
            return repository.MultiyearExpense(year1,year2);
        }

        public List<int> totalMonthlyExpense(int year)
        {
            SmartmedRepository repository = new SmartmedRepository();
            return repository.totalMonthlyExpense(year);
        }

        public List<int> totalMultiyearlyExpense(int year)
        {
            int year1, year2;
            year1 = year / 10000;
            year2 = year % 10000;
            SmartmedRepository repository = new SmartmedRepository();
            return repository.totalMultiyearlyExpense(year1, year2);
        }

        //INCOME ANALYSIS
        public List<int> singleYearIncome(int year)
        {
            SmartmedRepository repository = new SmartmedRepository();
            return repository.singleYearIncome(year);
        }

        public List<int> MultiyearIncome(int year)
        {
            int year1, year2;
            year1 = year / 10000;
            year2 = year % 10000;
            SmartmedRepository repository = new SmartmedRepository();
            return repository.MultiyearIncome(year1, year2);
        }

        public List<int> totalMonthlyIncome(int year)
        {
            SmartmedRepository repository = new SmartmedRepository();
            return repository.totalMonthlyIncome(year);
        }

        public List<int> totalMultiyearlyIncome(int year)
        {
            int year1, year2;
            year1 = year / 10000;
            year2 = year % 10000;
            SmartmedRepository repository = new SmartmedRepository();
            return repository.totalMultiyearlyIncome(year1, year2);
        }


        public List<Medicine> GetExpMedicines()
        {
            SmartmedRepository repository = new SmartmedRepository();
            List<Medicine> dalmed = new List<Medicine>();
            var temp = repository.getExpiryMedicine();
            try
            {
                foreach (var item in temp)
                {
                    dalmed.Add(new Medicine()
                    {
                        MedicineName = item.MedicineName,
                        ExpiryDate = item.ExpiryDate,
                        Cost = item.Cost,
                        Quantity = item.Quantity
                    });
                }
            }
            catch (Exception)
            {
                dalmed = null;
            }
            return dalmed;
        }



    }

  
}
﻿using Day17Assignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day17Assignment.Repositories
{
    public class HospitalManagementRepository : IHospitalManagementRepository
    {
        private HospitalManagementSystemDatabaseContext context;

        public HospitalManagementRepository(HospitalManagementSystemDatabaseContext hospitalManagementSystemContext)
        {
            context = hospitalManagementSystemContext;
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            context.Doctors.Add(doctor);
            context.SaveChanges();
            return doctor;
        }

        public bool DeleteDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            var Doctor = context.Doctors.SingleOrDefault(doctorData => doctorData.DoctorId == doctor.DoctorId);

            if (Doctor != null)
            {
                Doctor.IsActive = false;
                context.SaveChanges();
            }

            return false;

        }

        public Doctor GetDoctor(int Id)
        {
            return context.Doctors.SingleOrDefault(Doctor => Doctor.DoctorId == Id);
        }

        public IQueryable<object> GetDoctorAndPatientReport()
        {
            return context.Treatments
                .Include(doc => doc.Doctor)
                .Select(data => new { DoctorId = data.DoctorId, DoctorName = data.Doctor.DoctorName, PatientId = data.PatientId, PatientName = data.Patient.PatientName });
        }

        public List<Doctor> GetDoctors()
        {
            return context.Doctors.ToList();
        }

        public MedicineList GetMedicineList(int Id)
        {
            var Patient = context.Patients.SingleOrDefault(Pat => Pat.PatientId == Id);
            return context.MedicineLists.SingleOrDefault(Pat => Pat.PatientName == Patient.PatientName);
        }

        public PatientsDoctor GetpatientAssignedToDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            return context.PatientsDoctors.FirstOrDefault(Doc => Doc.DoctorName == doctor.DoctorName);
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            var existingDoctor = context.Doctors.SingleOrDefault(DoctorData => DoctorData.DoctorId == doctor.DoctorId);

            if (existingDoctor != null)
            {
                existingDoctor.DoctorName = doctor.DoctorName;
                existingDoctor.PhoneNumber = doctor.PhoneNumber;
                existingDoctor.Gender = doctor.Gender;
                existingDoctor.Age = doctor.Age;
                existingDoctor.Address = doctor.Address;

                context.SaveChanges();
            }

            return doctor;
        }
    }
}

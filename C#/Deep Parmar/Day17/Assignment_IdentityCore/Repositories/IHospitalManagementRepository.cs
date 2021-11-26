using Day17Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day17Assignment.Repositories
{
    public interface IHospitalManagementRepository
    {
        List<Doctor> GetDoctors();
        Doctor GetDoctor(int Id);
        Doctor AddDoctor(Doctor doctor);
        bool DeleteDoctor(Doctor doctor);
        Doctor UpdateDoctor(Doctor doctor);
        PatientsDoctor GetpatientAssignedToDoctor(Doctor doctor);
        MedicineList GetMedicineList(int Id);
        IQueryable<object> GetDoctorAndPatientReport();
    }
}

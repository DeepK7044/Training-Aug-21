using Day17Assignment.Authentication;
using Day17Assignment.Models;
using Day17Assignment.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day17Assignment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IHospitalManagementRepository _Doctor;

        public DoctorController(IHospitalManagementRepository doctorRepository)
        {
            _Doctor = doctorRepository;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            var Doctors = _Doctor.GetDoctors();
            if (Doctors == null)
            {
                return NotFound("Data Not Found.");
            }
            return Ok(Doctors);
        }

        [HttpGet("~/Report/Doctor/{DocID}")]
        public IActionResult GetpatientAssignedToDoctor(int DocID)
        {
            var Doctor = _Doctor.GetDoctor(DocID);
            if (Doctor == null)
            {
                return NotFound("Data Not Found.");
            }
            return Ok(_Doctor.GetpatientAssignedToDoctor(Doctor));
        }

        [HttpGet("~/Report/MedicineList/Patient/{PatId}")]
        public IActionResult GetMedicinesList(int PatID)
        {
            return Ok(_Doctor.GetMedicineList(PatID));
        }

        [HttpGet("~/Report/Doctor")]
        public IActionResult GetDoctorAndPatientReport()
        {
            return Ok(_Doctor.GetDoctorAndPatientReport());
        }

        [HttpGet("{Id}")]
        public IActionResult GetDoctor(int Id)
        {
            var Doctor = _Doctor.GetDoctor(Id);
            if (Doctor == null)
            {
                return NotFound("Data Not Found.");
            }
            return Ok(Doctor);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public IActionResult AddDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }
            var Doctor = _Doctor.AddDoctor(doctor);
            return Ok(Doctor);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPatch("{Id}")]
        public IActionResult UpdateDoctor(int Id, Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }
            var Doctor = _Doctor.GetDoctor(Id);
            if (Doctor != null)
            {
                doctor.DoctorId = Id;
                return Ok(_Doctor.UpdateDoctor(doctor));
            }
            return NotFound($"Doctor Which Id : {Id} is Not AVailable");
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{Id}")]
        public IActionResult DeleteDoctor(int Id)
        {
            var Doctor = _Doctor.GetDoctor(Id);
            if (Doctor != null)
            {
                return Ok(_Doctor.DeleteDoctor(Doctor));
            }
            return NotFound($"Doctor Which Id : {Id} is Not AVailable");
        }
    }
}

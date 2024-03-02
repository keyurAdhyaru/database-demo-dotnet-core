using DBDemo.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        #region Public Members
        StudentBL objStudentBL = new StudentBL();

        #endregion

        #region Public Methods

        /// <summary>
        /// Get All Students
        /// </summary>
        /// <returns>Student data</returns>
        [HttpGet]
        [Route("api/student/GetAllStudent")]
        public IActionResult GetAllStudent()
        {
            return Ok(JsonConvert.SerializeObject(objStudentBL.GetStudent()) );
        }

        /// <summary>
        /// Insert Student Data into table
        /// </summary>
        /// <param name="studentName">Name of the Student</param>
        /// <param name="studentEnd">Enrollment Number</param>
        /// <param name="sem">Currenct SEM</param>
        /// <returns>Message</returns>
        [HttpPost]
        [Route("api/student/InsertStudnet")]
        public IActionResult InsertStudent(string studentName, string studentEnd, int sem)
        {
            return Ok(JsonConvert.SerializeObject(objStudentBL.InsertStudent(studentName, studentEnd, sem)));
        }

        /// <summary>
        /// Update Student Data into table
        /// </summary>
        /// <param name="id">Id of Student</param>
        /// <param name="studentName">Name of the Student</param>
        /// <param name="studentEnd">Enrollment Number</param>
        /// <param name="sem">Currenct SEM</param>
        /// <returns>Message</returns>
        [HttpPut]
        [Route("api/student/UpdateStudent")]
        public IActionResult UpdateStudent(int id, string studentName, string studentEnd, int sem)
        {
            return Ok(objStudentBL.UpdateStudent(id, studentName, studentEnd, sem));
        }

        /// <summary>
        /// Delete Rec of Given Id
        /// </summary>
        /// <param name="id">Student Id</param>
        /// <returns>Message</returns>
        [HttpDelete]
        [Route("api/student/DeleteStudent")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok(objStudentBL.DeleteStudent(id));
        }

        #endregion
    }
}

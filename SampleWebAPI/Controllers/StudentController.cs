using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Data;
using SampleWebAPI.Dtos;
using SampleWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudent _student;
        private IMapper _mapper;

        public StudentsController(IStudent student, IMapper mapper)
        {
            _student = student ?? throw new ArgumentNullException(nameof(student));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> Get()
        {
            var students = await _student.GetAll();

            /*List<StudentDto> lstStudentDto = new List<StudentDto>();
            foreach (var student in students)
            {
                lstStudentDto.Add(new StudentDto
                {
                    ID = student.ID,
                    Name = $"{student.FirstName} {student.LastName}",
                    EnrollmentDate = student.EnrollmentDate
                });
            }*/
            var dtos = _mapper.Map<IEnumerable<StudentDto>>(students);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> Get(int id)
        {
            var result = await _student.GetById(id.ToString());
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<StudentDto>(result));
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> Post([FromBody] StudentForCreateDto studentforCreateDto)
        {
            try
            {
                var student = _mapper.Map<Models.Student>(studentforCreateDto);
                var result = await _student.Insert(student);
                var studentReturn = _mapper.Map<Dtos.StudentDto>(result);
                return Ok(studentReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDto>> Put(int id, [FromBody] StudentForCreateDto studentforCreateDto)
        {
            try
            {
                var student = _mapper.Map<Models.Student>(studentforCreateDto);
                var result = await _student.Update(id.ToString(), student);
                var studentdto = _mapper.Map<Dtos.StudentDto>(result);
                return Ok(studentdto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _student.Delete(id.ToString());
                return Ok($"Data student {id} berhasil didelete!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

/*private List<Student> lstStudent = new List<Student>
{
new Student { ID=1,FirstName="Agus",LastName="Kurniawan",
EnrollmentDate=DateTime.Now},
new Student { ID=2,FirstName="Erick",LastName="Kurniawan",
EnrollmentDate=DateTime.Now},
new Student { ID=1,FirstName="Agus",LastName="Aja",
EnrollmentDate=DateTime.Now}
};*/

/*[HttpGet]
public static List<Student> Get()
{
    return lstStudent;
}

[HttpGet("{id}")]
public Student Get(int id)
{
}*/

/*var result = lstStudent.Where(s => s.ID == id).SingleOrDefault();
var result = (from s in lstStudent select s).SingleOrDefault();
if (result != null)
    return result;
else
    return new Student { };
*/


/*[HttpGet("byname")]
public List<Student> Get(string firstname, string lastname)
{
    var results = lstStudent.Where(s => s.FirstName.StartsWith(firstname) &&
    s.LastName.StartsWith(lastname)).ToList();
    var results = (from s in lstStudent where s.FirstName.ToLower()
                   .StartsWith(firstname.ToLower())
                  select s).ToList();
    return results;
}*/

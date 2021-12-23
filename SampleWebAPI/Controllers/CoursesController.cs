using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Data;
using SampleWebAPI.Dtos;
using SampleWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        private ICourse _course;
        private IMapper _mapper;

        public CoursesController(ICourse course, IMapper mapper)
        {
            _course = course;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> Get()
        {
            var results = await _course.GetAll();
            return Ok(_mapper.Map<IEnumerable<CourseDto>>(results));
        }
        // GET: api/values
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> Get(int id)
        {
            var result = await _course.GetById(id.ToString());
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<CourseDto>(result));
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<CourseDto>> Post([FromBody] CourseForCreateDto courseforCreateDto)
        {
            try
            {
                var course = _mapper.Map<Models.Course>(courseforCreateDto);
                var result = await _course.Insert(course);
                var courseReturn = _mapper.Map<Dtos.CourseDto>(result);
                return Ok(courseReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CourseDto>> Put(int id, [FromBody] CourseForCreateDto courseToCreateDto)
        {
            try
            {
                var course = _mapper.Map<Models.Course>(courseToCreateDto);
                var result = await _course.Update(id.ToString(), course);
                var coursedto = _mapper.Map<Dtos.CourseDto>(result);
                return Ok(coursedto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _course.Delete(id.ToString());
                return Ok($"Data course {id} berhasil didelete!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/bytitle")]
        public async Task<IEnumerable<Course>> GetByTitle (string title)
        {
            var results = await _course.GetByTitle(title);
            return results;
        }


    }
}

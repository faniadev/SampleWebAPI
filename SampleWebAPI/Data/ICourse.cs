using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SampleWebAPI.Models;

namespace SampleWebAPI.Data
{
    public interface ICourse : ICrud<Course>
    {
        Task<IEnumerable<Course>> GetByTitle(string title);
       
    }
}

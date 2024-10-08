using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public  interface IClassService
    {
        Task<List<Class>> GetAllClassesAsync();
        Task<Class> GetClassByIdAsync(Guid id);
        Task AddClassAsync(Class classItem);
        Task UpdateClassAsync(Class classItem);
        Task DeleteClassAsync(Guid id);
    }
}

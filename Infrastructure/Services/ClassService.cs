using Aplication.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public  class ClassService : IClassService
    {

        private readonly List<Class> _classes = new List<Class>();

        public Task<List<Class>> GetAllClassesAsync() => Task.FromResult(_classes);

        public Task<Class> GetClassByIdAsync(Guid id) =>
            Task.FromResult(_classes.FirstOrDefault(c => c.Id == id));

        public Task AddClassAsync(Class classItem)
        {
            classItem.Id = Guid.NewGuid();
            _classes.Add(classItem);
            return Task.CompletedTask;
        }

        public Task UpdateClassAsync(Class classItem)
        {
            var existing = _classes.FirstOrDefault(c => c.Id == classItem.Id);
            if (existing != null)
            {
                existing.Name = classItem.Name;
            }
            return Task.CompletedTask;
        }

        public Task DeleteClassAsync(Guid id)
        {
            _classes.RemoveAll(c => c.Id == id);
            return Task.CompletedTask;
        }
    }
}

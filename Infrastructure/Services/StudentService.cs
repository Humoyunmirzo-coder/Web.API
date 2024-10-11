using Aplication.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class StudentService : IStudentService
    {
        private readonly List<Student> _students = new List<Student>();

        public Task<List<Student>> GetAllStudentsAsync() => Task.FromResult(_students);

        public Task<Student> GetStudentByIdAsync(Guid id) =>
            Task.FromResult(_students.FirstOrDefault(s => s.Id == id));

        public Task AddStudentAsync(Student student)
        {
            student.Id = Guid.NewGuid();
            _students.Add(student);
            return Task.CompletedTask;
        }

        public Task UpdateStudentAsync(Student student)
        {
            var existing = _students.FirstOrDefault(s => s.Id == student.Id);
            if (existing != null)
            {
                existing.FullName = student.FullName;
                existing.BirthDate = student.BirthDate;
                existing.ClassId = student.ClassId;
            }
            return Task.CompletedTask;
        }

        public Task<bool> DeleteStudentAsync(Guid id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return Task.FromResult(false);

            _students.Remove(student);
            return Task.FromResult(true);

        }
    }
}

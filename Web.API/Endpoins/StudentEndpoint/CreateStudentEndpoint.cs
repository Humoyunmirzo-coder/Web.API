using Aplication.Services;
using Domain.Models;
using FastEndpoints;

namespace Web.API.Endpoins.StudentEndpoint
{
    public class CreateStudentEndpoint : Endpoint<CreateStudentRequest>
    {
        private readonly IStudentService _studentService;

        public CreateStudentEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override void Configure()
        {
            Post("/students");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateStudentRequest req, CancellationToken ct)
        {
            var student = new Student
            {
                FullName = req.FullName,
                BirthDate = req.BirthDate,
                ClassId = req.ClassId
            };

            // Xizmat orqali ma'lumotlarni saqlash
            await _studentService.AddStudentAsync(student);

            await SendOkAsync(student, ct);
        }
    }
}

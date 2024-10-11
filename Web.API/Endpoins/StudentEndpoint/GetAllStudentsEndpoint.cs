using Aplication.Services;
using Domain.Models;
using FastEndpoints;

namespace Web.API.Endpoins.StudentEndpoint
{
    public class GetAllStudentsEndpoint : EndpointWithoutRequest<List<Student>>
    {
        private readonly IStudentService _studentService;

        public GetAllStudentsEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override void Configure()
        {
            Get("/students");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var students = await _studentService.GetAllStudentsAsync();
            await SendOkAsync(students, ct);
        }
    }
}

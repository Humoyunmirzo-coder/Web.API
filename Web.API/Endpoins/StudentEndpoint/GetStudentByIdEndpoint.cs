using Aplication.Services;
using Domain.Models;
using FastEndpoints;

namespace Web.API.Endpoins.StudentEndpoint
{
    public class GetStudentByIdEndpoint : Endpoint<GetStudentByIdRequest>

    {
        private readonly IStudentService _studentService;

        public GetStudentByIdEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override void Configure()
        {
            Get("/students/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetStudentByIdRequest req, CancellationToken ct)
        {
            var student = await _studentService.GetStudentByIdAsync(req.Id);

            if (student == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            await SendOkAsync(student, ct);
        }
    }

}


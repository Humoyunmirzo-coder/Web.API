using Aplication.Services;
using Domain.Models;
using FastEndpoints;

namespace Web.API.Endpoins.StudentEndpoint
{
    public class DeleteStudentEndpoint : Endpoint<DeleteStudentRequest>
    {

        private readonly IStudentService _studentService;

        public DeleteStudentEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override void Configure()
        {
            Delete("/students/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeleteStudentRequest req, CancellationToken ct)
        {
            var success = await _studentService.DeleteStudentAsync(req.Id);

            if (!success)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            await SendOkAsync(new { Message = "Student successfully deleted!" }, ct);
        }
    }

}


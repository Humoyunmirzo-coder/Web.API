using Aplication.Services;
using Ardalis.ApiEndpoints;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Net;




namespace Web.API.Endpoins.Student
{
    public class CreateStudentEndpoint : EndPoint<Students>
      
    {
        private readonly IStudentService _studentService;
    }
}

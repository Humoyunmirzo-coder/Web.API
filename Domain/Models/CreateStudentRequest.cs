using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public  class CreateStudentRequest
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid ClassId { get; set; }
    }
}

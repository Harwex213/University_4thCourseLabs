using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lab03.Controllers;
using Microsoft.Ajax.Utilities;

namespace Lab03.DTOs
{
    public class PostStudentDto
    {
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = ErrorCodes.StudentEntityBadName)]
        public string Name { get; set; }
        
        [RegularExpression(@"^375[29|44|33][0-9]{8}$", ErrorMessage = ErrorCodes.StudentEntityBadPhone)]
        public string Phone { get; set; }
    }
}
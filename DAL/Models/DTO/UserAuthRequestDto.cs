using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO
{
    public class UserAuthRequestDto
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
        public string? Name { get; set; }
    }
}


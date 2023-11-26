using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public class RegisterDTO
    {
        public int AccountId { get; set; }
        [Required]
        public string FullName { get; set; }
        public DateTime? Dob { get; set; }
        [Required]
        public string Email { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        [Required]
        public string Phone { get; set; }
        public int? Gender { get; set; }
    }
}

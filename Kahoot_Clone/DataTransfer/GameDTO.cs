using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public class GameDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string PinCode { get; set; }
        [Required]
        public int UserId { get; set; }
        public int? Publish { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public class QuestionDTO
    {
        [Required]
        public string QuestionContent { get; set; }
        public string Type { get; set; } = null!;
        [Required]
        public int Point { get; set; }
        public int? TimeLimit { get; set; }
        public int GameId { get; set; }
    }
}

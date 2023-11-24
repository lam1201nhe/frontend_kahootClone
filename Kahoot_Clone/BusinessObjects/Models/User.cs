using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class User
    {
        public User()
        {
            Games = new HashSet<Game>();
        }

        public int UserId { get; set; }
        public int AccountId { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public string Email { get; set; } = null!;
        public string? Image { get; set; }
        public string? Description { get; set; }
        public string Phone { get; set; } = null!;
        public bool? Gender { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<Game> Games { get; set; }
    }
}

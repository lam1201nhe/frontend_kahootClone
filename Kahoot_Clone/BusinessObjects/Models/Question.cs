using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Question
    {
        public Question()
        {
            QuestionChoices = new HashSet<QuestionChoice>();
        }

        public int QuestionId { get; set; }
        public string QuestionContent { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int Point { get; set; }
        public int? TimeLimit { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; } = null!;
        public virtual ICollection<QuestionChoice> QuestionChoices { get; set; }
    }
}

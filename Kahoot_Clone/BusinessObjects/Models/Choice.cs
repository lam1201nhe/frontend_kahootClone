using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Choice
    {
        public Choice()
        {
            QuestionChoices = new HashSet<QuestionChoice>();
        }

        public int ChoiceId { get; set; }
        public string ChoiceContent { get; set; } = null!;

        public virtual ICollection<QuestionChoice> QuestionChoices { get; set; }
    }
}

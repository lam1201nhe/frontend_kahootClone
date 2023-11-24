using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class QuestionChoiceDAO
    {
        public static List<QuestionChoice> GetQuestionChoices()
        {
            var listQuestionChoices = new List<QuestionChoice>();
            try
            {
                using (var context = new CloneKahootContext())
                {
                    listQuestionChoices = context.QuestionChoices.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listQuestionChoices;
        }

        public static void SaveQuestionChoice(QuestionChoice questionChoice)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    context.QuestionChoices.Add(questionChoice);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateQuestionChoice(QuestionChoice questionChoice)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    context.Entry(questionChoice).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteQuestionChoice(int questionChoiceID)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    var questionChoiceToDelete = context.QuestionChoices.SingleOrDefault(g => g.ChoiceId == questionChoiceID);
                    context.QuestionChoices.Remove(questionChoiceToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

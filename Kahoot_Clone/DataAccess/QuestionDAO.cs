using BusinessObjects.Models;

namespace DataAccess
{
    public class QuestionDAO
    {
        public static List<Question> GetQuestions()
        {
            var listQuestions = new List<Question>();
            try
            {
                using (var context = new CloneKahootContext())
                {
                    listQuestions = context.Questions.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listQuestions;
        }

        public static void SaveQuestion(Question question)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    context.Questions.Add(question);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateQuestion(Question question)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    context.Entry(question).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteQuestion(int questionID)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    var questionToDelete = context.Questions.SingleOrDefault(g => g.QuestionId == questionID);
                    context.Questions.Remove(questionToDelete);
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
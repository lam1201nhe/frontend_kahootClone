using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ChoiceDAO
    {
        public static List<Choice> GetChoices()
        {
            var listChoices = new List<Choice>();
            try
            {
                using (var context = new CloneKahootContext())
                {
                    listChoices = context.Choices.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listChoices;
        }

        public static void SaveChoice(Choice choice)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    context.Choices.Add(choice);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateChoice(Choice choice)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    context.Entry(choice).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteChoice(int choiceID)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    var choiceToDelete = context.Choices.SingleOrDefault(g => g.ChoiceId == choiceID);
                    context.Choices.Remove(choiceToDelete);
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

using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PlayerDAO
    {
        public static List<Player> GetPlayers()
        {
            var listPlayers = new List<Player>();
            try
            {
                using (var context = new CloneKahootContext())
                {
                    listPlayers = context.Players.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listPlayers;
        }

        public static void SavePlayer(Player player)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    context.Players.Add(player);
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


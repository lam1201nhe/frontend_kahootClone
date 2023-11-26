using BusinessObjects.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.impl
{
    public class GameRepository : IGameRepository
    {
        public void DeleteGame(int gameID) => GameDAO.DeleteGame(gameID);

        public Game GetGameByGameID(int gameId) => GameDAO.GetGameByGameID(gameId);

        public List<string> GetListCode() => GameDAO.GetListCode();

        public List<Game> GetGameByUserID(int userId) => GameDAO.GetGameByUserID(userId);

        public List<Game> GetGames() => GameDAO.GetGames();

        public void SaveGame(Game game) => GameDAO.SaveGame(game);

        public void UpdateGame(Game game) => GameDAO.UpdateGame(game);

        public Game GetGameByCodePin(string codePin) => GameDAO.GetGameByCodePin(codePin);
    }
}

using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IGameRepository
    {
        List<Game> GetGames();
        void SaveGame(Game game);
        void UpdateGame(Game game);
        void DeleteGame(int gameID);
        Game GetGameByGameID(int gameId);
        List<Game> GetGameByUserID(int userId);
        List<string> GetListCode();
        Game GetGameByCodePin(string codePin);
    }
}

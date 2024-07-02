using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSales.Entity;
namespace CarSales.Interfaces
{
    public interface IGameService
    {
        Task <IEnumerable<Game>> GetAllAsync();

        Task<Game> GetByIdAsync(Guid id);

        Task AddGameAsync(Game game);   

        Task UpdateGameAsync(Game game);
        Task DeleteGameAsync(Guid id);
    }
}
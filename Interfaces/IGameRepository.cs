using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSales.Entity;

namespace CarSales.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAllAsync();

        Task<Game> GetByIdAsync(Guid id);

        Task AddAsync(Game game);

        Task UpdateAsync(Game game);

        Task DeleteAsync(Guid id);
    }
}
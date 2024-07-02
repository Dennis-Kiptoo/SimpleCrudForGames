using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSales.Context;
using CarSales.Interfaces;
using CarSales.Entity;
using System.Data.Entity;

namespace CarSales.Repository
{
    public class GameRepository :IGameRepository
    {
        private readonly GameDbContext _context;

        public GameRepository(GameDbContext context)
        {
            _context = context;
        }
        
  public async Task<IEnumerable<Game>> GetAllAsync()
{
    // Execute the query synchronously, then convert to async operation as a workaround
    var games = _context.Games.ToList(); // This executes synchronously
    return await Task.FromResult(games); // Convert to async operation
}
        public async Task<Game> GetByIdAsync(Guid id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task AddAsync(Game game)
        {
             _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }
      public async Task UpdateAsync(Game game)
{
    _context.Games.Update(game);
    await _context.SaveChangesAsync();
}
public async Task DeleteAsync(Guid id)
{
    var game = await _context.Games.FindAsync(id);
    if (game != null)
    {
        _context.Games.Remove(game);
        await _context.SaveChangesAsync();
    }
    else
    {
        // Optionally, handle the case where the game does not exist.
        // This could involve throwing an exception or simply returning.
    }
}



    }
}
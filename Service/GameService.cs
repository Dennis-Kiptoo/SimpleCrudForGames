using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarSales.Interfaces;
using CarSales.Entity;

namespace CarSales.Service
{
public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Game> GetByIdAsync(Guid id)
    {
        return await _gameRepository.GetByIdAsync(id);
    }

    public async Task AddGameAsync(Game game)
    {
        await _gameRepository.AddAsync(game);
    }

    public async Task UpdateGameAsync(Game game)
    {
        await _gameRepository.UpdateAsync(game);
    }

    public async Task DeleteGameAsync(Guid id)
    {
        await _gameRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await _gameRepository.GetAllAsync();
    }
}
}
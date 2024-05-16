using APIKnight.Entities;
using APIKnight.Repositories.Interfaces;
using APIKnight.Services.Interface;

namespace APIKnight.Services
{
    public class KnightService : IKnightService
    {
        private readonly IKnightRepository _knightRepository;

        public KnightService(IKnightRepository knightRepository)
        {
            _knightRepository = knightRepository;
        }

        public async Task<Knight> Create(Knight knight)
        {
            return await _knightRepository.Create(knight);
        }

        public void Delete(Knight knight)
        {
            _knightRepository.Delete(knight);
        }      

        public async Task<List<Knight>> GetAll()
        {
            return await _knightRepository.GetAll();
        }

        public async Task<Knight> GetById(int id)
        {
            return await _knightRepository.GetById(id);
        }

        public async Task<List<Weapon>> GetWeaponsByKnightId(int knightId)
        {
            return await _knightRepository.GetWeaponsByKnightId(knightId);
        }

        public async Task<bool> Update(int id, Knight knight)
        {
            return await _knightRepository.Update(id, knight);
        }
    }
}

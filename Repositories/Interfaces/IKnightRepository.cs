using APIKnight.Entities;

namespace APIKnight.Repositories.Interfaces
{
    public interface IKnightRepository
    {
        Task<List<Knight>> GetAll();
        Task<Knight> GetById(int id);
        Task<Knight> Create(Knight knight);        
        void Delete(Knight knight);      
        Task<bool> Update(int id, Knight knight);
        Task<List<Weapon>> GetWeaponsByKnightId(int knightId);

    }
}

using APIKnight.Entities;

namespace APIKnight.Services.Interface
{
    public interface IKnightService
    {
        Task<List<Knight>> GetAll();
        Task<Knight> GetById(int id);        
        Task<Knight> Create(Knight knight);
        Task<List<Weapon>> GetWeaponsByKnightId(int knightId);
        Task<bool> Update(int id, Knight knight);
        void Delete(Knight knight);
    }
}

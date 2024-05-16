using APIKnight.Entities;
using APIKnight.Repositories.Interfaces;
using APIKnight.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace APIKnight.Repositories
{
    public class KnightRepository : BaseRepository, IKnightRepository
    {
        private readonly AppDbContext _context;

        public KnightRepository(AppDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<Knight> Create(Knight knight)
        {   
            EntityEntry<Knight> x =  await _context.Knights.AddAsync(knight);            
            return x.Entity;
        }

        public void Delete(Knight knight)
        {
            _context.Remove(knight);
        }      

        public async Task<List<Knight>> GetAll()
        {
            return await _context.Knights.ToListAsync();
        }

        public async Task<Knight> GetById(int id)
        {
            return await _context.Knights.FirstOrDefaultAsync(x => x.KnightId == id);
        }

        public async Task<List<Weapon>> GetWeaponsByKnightId(int knightId)
        {
            List<Weapon> weapons = new List<Weapon>();
            Knight knight = await _context.Knights
                .Include(x => x.WeaponsKnight)
                .ThenInclude(x => x.Knight).FirstOrDefaultAsync(x => x.KnightId == knightId);

            if (knight != null)
            {
                weapons = knight.WeaponsKnight.Select(x => x.Weapon).ToList();
            }

            return weapons;
           
        }

        public async Task<bool> Update(int id, Knight knight)
        {
            Knight existKnight = await _context.Knights.FindAsync(id);

            if (existKnight == null)
                return false;
            else
            {
                _context.Entry(existKnight).State = EntityState.Detached;
            }
            _context.Attach(knight);
            _context.Entry(existKnight).State = EntityState.Modified;
            return true;
        }       
    }
}

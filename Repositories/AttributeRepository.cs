using APIKnight.Data;
using APIKnight.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace APIKnight.Repositories
{
    public class AttributeRepository : BaseRepository, IAttributeRepository
    {
        private readonly AppDbContext _context;

        public AttributeRepository(AppDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<Entities.Attribute> Create(Entities.Attribute attr)
        {
            try
            {
                EntityEntry<Entities.Attribute> x = await _context.Attributes.AddAsync(attr);
                return x.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Entities.Attribute attr)
        {
            _context.Remove(attr);
        }

        public async Task<List<Entities.Attribute>> GetAll()
        {
            return await _context.Attributes.ToListAsync();
        }

        public async Task<Entities.Attribute> GetById(int id)
        {
            return await _context.Attributes.FirstOrDefaultAsync(x => x.AttributeId == id);
        }
            

        public async Task<bool> Update(int id, Entities.Attribute attr)
        {
            Entities.Attribute existAttr = await _context.Attributes.FindAsync(id);

            if (existAttr == null)
                return false;
            else
            {
                _context.Entry(existAttr).State = EntityState.Detached;
            }
            _context.Attach(attr);
            _context.Entry(existAttr).State = EntityState.Modified;
            return true;
        }
    }
}

using APIKnight.Repositories.Interfaces;
using APIKnight.Services.Interface;

namespace APIKnight.Services
{
    public class AttributeService : IAttributeService
    {
        private readonly IAttributeRepository _attrRepository;

        public AttributeService(IAttributeRepository attrRepository)
        {
            _attrRepository = attrRepository;
        }

        public async Task<Entities.Attribute> Create(Entities.Attribute attr)
        {
            return await _attrRepository.Create(attr);
        }

        public void Delete(Entities.Attribute attr)
        {
            _attrRepository.Delete(attr);
        }

        public async Task<List<Entities.Attribute>> GetAll()
        {
            return await _attrRepository.GetAll();
        }

        public async Task<Entities.Attribute> GetById(int id)
        {
            return await _attrRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _attrRepository.SaveChanges();
        }

        public async Task<bool> Update(int id, Entities.Attribute attr)
        {
            return await _attrRepository.Update(id, attr);
        }
    }
}

using APIKnight.Data;


namespace APIKnight.Repositories.Interfaces
{
    public interface IAttributeRepository : IBaseRepository
    {
        Task<List<Entities.Attribute>> GetAll();
        Task<Entities.Attribute> GetById(int id);
        Task<Entities.Attribute> Create(Entities.Attribute attr);
        void Delete(Entities.Attribute attr);
        Task<bool> Update(int id, Entities.Attribute attr);
    }
}

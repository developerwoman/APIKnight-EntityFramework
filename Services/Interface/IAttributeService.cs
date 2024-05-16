namespace APIKnight.Services.Interface
{
    public interface IAttributeService
    {
        Task<List<Entities.Attribute>> GetAll();
        Task<Entities.Attribute> GetById(int id);
        Task<Entities.Attribute> Create(Entities.Attribute attr);       
        Task<bool> Update(int id, Entities.Attribute attr);
        void Delete(Entities.Attribute attr);
        public void SaveChanges();
    }
}

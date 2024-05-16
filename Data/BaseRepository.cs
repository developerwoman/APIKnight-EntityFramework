namespace APIKnight.Data
{
    public class BaseRepository : IBaseRepository
    {
        private readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }    

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

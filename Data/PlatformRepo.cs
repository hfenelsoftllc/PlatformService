using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;
        public PlatformRepo(AppDbContext context)
        {
            this._context = context;
        }
        
        public void CreatePlatform(Platform platform)
        {
            if(platform == null){
                throw new ArgumentNullException(nameof(platform));
            }
            _context.Platforms.Add(platform);
            _context.SaveChanges();
        }

        public Platform GetPlatFormById(int id)
        {
            return _context.Platforms.FirstOrDefault(p =>p.Id==id);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
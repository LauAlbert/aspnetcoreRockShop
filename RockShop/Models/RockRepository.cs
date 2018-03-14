using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockShop.Models
{
    public class RockRepository : IRockRepository
    {
        private readonly AppDbContext _appDbContext;
        public RockRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Rock GetRock(int id)
        {
            return _appDbContext.Rocks.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Rock> GetRockOfTheWeek()
        {
            return _appDbContext.Rocks.Where(r => r.RockOfTheWeek == true).ToList();
        }

        public IEnumerable<Rock> GetRocks()
        {
            return _appDbContext.Rocks;
        }
        public void AddRock(Rock rock)
        {
            rock.DateTime = DateTime.Now;
            _appDbContext.Rocks.Add(rock);
        }
        public async Task<bool> Save()
        {
            var changes = await _appDbContext.SaveChangesAsync();
            return (changes > 0);
        }
    }
}

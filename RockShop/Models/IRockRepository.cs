using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockShop.Models
{
    public interface IRockRepository
    {
        IEnumerable<Rock> GetRocks();
        IEnumerable<Rock> GetRockOfTheWeek();
        Rock GetRock(int id);
    }
}

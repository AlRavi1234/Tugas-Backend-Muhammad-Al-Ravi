using TugasMinggu1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasMinggu1.Data.DAL;

namespace TugasMinggu1.data.DAL
{
    public interface ISamurai:ICrud<Samurai>
    {
        Task<IEnumerable<Samurai>> GetByName(string name);
        Task<Samurai> AddSamuraiWithSword(Samurai obj);
        Task<IEnumerable<Samurai>> GetSamuraiWithAll();
        Task<Samurai> DeleteSwordInSamurai(int id);

    }
}

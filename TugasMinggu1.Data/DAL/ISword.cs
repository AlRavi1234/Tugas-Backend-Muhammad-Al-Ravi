
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasMinggu1.Domain;

namespace TugasMinggu1.Data.DAL
{
    public interface ISword : ICrud<Sword>
    {
        Task<IEnumerable<Sword>> GetByName(string name);
        Task<IEnumerable<Sword>> GetByWeight();
        Task<Sword> AddSwordWithTipe(Sword obj);
        Task<Sword> AddExistingSwordInElemen(Sword obj);
        Task<IEnumerable<Sword>> GetSwordWithTipe(PaginationParams paginationParams);
        Task<Sword> DeleteElemenInSword(int id);
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasMinggu1.Domain;

namespace TugasMinggu1.Data.DAL
{
    public interface IElemen : ICrud<Elemen>
    {
        Task<IEnumerable<Elemen>> GetByName(string name);
        Task<Elemen> AddExistingElemenInSword(Elemen obj);
        Task<Elemen> DeleteElemenInAllSword(int id);
    }
}

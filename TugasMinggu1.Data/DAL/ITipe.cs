using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasMinggu1.Domain;

namespace TugasMinggu1.Data.DAL
{
    public interface ITipe : ICrud <Tipe>
    {
    Task<IEnumerable<Tipe>> GetByName(string name);
    }
}

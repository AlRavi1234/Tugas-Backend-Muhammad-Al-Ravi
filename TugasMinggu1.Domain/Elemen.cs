using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasMinggu1.Domain
{   //ManyToMany ke Sword
    public class Elemen
    {
        public int ElemenId { get; set; }
        public string Name { get; set; }
        public List<Sword> Swords { get; set; } = new List<Sword>();
    }
}

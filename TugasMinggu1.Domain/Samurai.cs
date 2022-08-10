using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasMinggu1.Domain
{ //OneToMany ke Sword
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Sword> Swords { get; set; } = new List<Sword>();
       
    }
}

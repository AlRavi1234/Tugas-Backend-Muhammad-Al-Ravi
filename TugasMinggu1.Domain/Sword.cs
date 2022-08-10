using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasMinggu1.Domain
{   //ManyToOne ke Samurai
    //ManyToMany ke Elemen
    //OnetoOne ke Type
    public class Sword
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        public Samurai Samurai { get; set; }
        public int SamuraiId { get; set; }
        public Tipe Tipes { get; set; }
        public List<Elemen> Elemens { get; set; } = new List<Elemen>();
    }
}

using TugasMinggu1.Domain;

namespace TugasMinggu1.DTO
{
    public class SwordWithTipeReadDTO
    {
        public int SamuraiId { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        public Tipe Tipes { get; set; }
    }
}

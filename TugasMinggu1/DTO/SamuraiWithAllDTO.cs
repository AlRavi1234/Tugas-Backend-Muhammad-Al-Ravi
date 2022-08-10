using TugasMinggu1.Domain;

namespace TugasMinggu1.DTO
{
    public class SamuraiWithAllDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SwordWithTipeElemenDTO> Swords { get; set; }= new List<SwordWithTipeElemenDTO>();

        
    }
}

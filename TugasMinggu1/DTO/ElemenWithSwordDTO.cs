namespace TugasMinggu1.DTO
{
    public class ElemenWithSwordDTO
    {
        public int ElemenId { get; set; }
        public List<SwordIdDTO> Swords { get; set; } = new List<SwordIdDTO>();
    }
}

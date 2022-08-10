namespace TugasMinggu1.DTO
{
    public class SwordWithTipeElemenDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Tipe_DTO Tipes { get; set; }

        public List<ElemenIdNameDTO> Elemens { get; set; } = new List<ElemenIdNameDTO>();

    }
}

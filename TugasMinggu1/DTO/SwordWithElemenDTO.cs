namespace TugasMinggu1.DTO
{
    public class SwordWithElemenDTO
    {
        public int Id{get;set;}

       public List<ElemenIdDTO> Elemens { get; set; } = new List<ElemenIdDTO>();   
       //public ElemenIdDTO Elemens { get;set;}

    }
}

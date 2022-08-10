using TugasMinggu1.Domain;

namespace TugasMinggu1.DTO
{
    public class SwordWithAll
    {
        //public List<SwordCreateDTO> Swords { get; set; }
        //public string Name { get; set; }
        //public int SwordId { get; set; }
        public int SamuraiId { get; set; }
        public SamuraiCreateDTO Samurai { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        
      //  public Samurai Samurai { get; set; }
       public Tipe Tipes { get; set; }
        public List<ElemenDTO> Elemens { get; set; } = new List<ElemenDTO>();


        //public List<Tipe_DTO> Tipes { get; set; }



    }
}

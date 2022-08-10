using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasMinggu1.Domain;

namespace TugasMinggu1.Data
{
    public class SwordContext :DbContext
    {
       /* public SwordContext()
        {

        }*/

        public SwordContext(DbContextOptions<SwordContext> options):base(options)
        {

        }
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Sword> Swords { get; set; }
        public DbSet<Elemen> Elemens { get; set; }
        public DbSet<Tipe> Tipes { get; set; }
      
        public DbSet<User> Users { get; set; }
        
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SwordDb");

        }

        // public DbSet<ElemenSword> ElemenSwords { get; set; }
        /*  protected override void OnModelCreating(ModelBuilder modelBuilder)
          {


              modelBuilder.Entity<Sword>().HasMany(s => s.Elemens)
                  .WithMany(b => b.Swords)
                  .UsingEntity<ElemenSword>(bs => bs.HasOne<Elemen>().WithMany(),
                  bs => bs.HasOne<Sword>().WithMany());


          }*/

    }
}

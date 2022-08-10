using Microsoft.EntityFrameworkCore;
using TugasMinggu1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasMinggu1.Data;
using TugasMinggu1.data.DAL;

namespace TugasMinggu1.data.DAL
{
    public class SamuraiDAL : ISamurai
    {   //dependency injection
        private readonly SwordContext _context;

        //inject samurai context
        public SamuraiDAL(SwordContext context)
        {
            _context = context;
        }

        //digunakan async untuk pemanggil metode async
        //GetAll
        public async Task<IEnumerable<Samurai>> GetSamuraiWithAll()
        {
            //  var results = await _context.Samurais.Include(s => s.Swords).ThenInclude(s=>s.Tipes).Include(s=>s.Swords)
            //  .ThenInclude(s=>s.Elemens).OrderBy(s=>s.Name).ToListAsync();
            var samurais = await _context.Samurais.Include(s => s.Swords).OrderBy(s => s.Name).ToListAsync();
            foreach (var samurai in samurais)
            {
                foreach (var sword in samurai.Swords)
                {
                    await _context.Swords.Include(s => s.Tipes).Include(s => s.Elemens).ToListAsync();
                }
            }
            return samurais;
        }
        //getsamurai
        public async Task<IEnumerable<Samurai>> GetAll()
        {
            var results = await _context.Samurais.OrderBy(s => s.Name).ToListAsync();
            return results;
            
        }

        //getById
        public async Task<Samurai> GetById(int id)
        {
            var result = await _context.Samurais.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data samurai dengan id {id} tidak ditemukan");
            return result;
        }

        //getByname
        public async Task<IEnumerable<Samurai>> GetByName(string name)
        {
            //var samurais = await _context.Samurais.FirstOrDefaultAsync(s => s.Name == $"%{name}%");
            var samurais = _context.Samurais.Where(s => s.Name.Contains(name.ToLower())).OrderBy(s => s.Name).ToList();
            return samurais;
        }

        //insert
        public async Task<Samurai> Insert(Samurai obj)
        {
            try
            {
                _context.Samurais.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        //AddSamuraiWithSword
        public async Task<Samurai> AddSamuraiWithSword(Samurai obj)
        {
            try
            {
                _context.Samurais.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        //update
        public async Task<Samurai> Update(Samurai obj)
        {
            try
            {
                var updateSamurai = await _context.Samurais. FirstOrDefaultAsync(s => s.Id == obj.Id);
                if (updateSamurai == null) throw new Exception($"data samurai dengan id {obj.Id}tidak ditemukan");
                updateSamurai.Name = obj.Name;
                await _context.SaveChangesAsync();
                return obj;
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        //delete
        public async Task Delete(int id)
        {
            try
            {
                var deleteSamurai = await _context.Samurais.FirstOrDefaultAsync(s => s.Id == id);
                if (deleteSamurai == null)
                    throw new Exception($"data samurai dengan id {id} tidak ditemukan");
                _context.Samurais.Remove(deleteSamurai);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        //DeleteSwordInSamurai
        public async Task<Samurai> DeleteSwordInSamurai(int id)
        {
            try
            {
                var deleteSamurai = _context.Samurais.FirstOrDefault(s => s.Id == id);
                var swords = _context.Swords.Where(s=>s.SamuraiId==id);
                foreach (var sword in swords)
                {
                    deleteSamurai.Swords.Remove(sword);
                }
                // _context.Swords.Remove(deleteSword);
                await _context.SaveChangesAsync();
                return deleteSamurai;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        //akhir
    }
}

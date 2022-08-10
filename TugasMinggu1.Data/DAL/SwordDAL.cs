using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TugasMinggu1.Domain;

namespace TugasMinggu1.Data.DAL
{
    public class SwordDAL : ISword
    {
        private readonly SwordContext _context;

        public SwordDAL(SwordContext context)
        {
            _context = context;
        }
        //getall()
        public async Task<IEnumerable<Sword>> GetAll()
        {
            var results = await _context.Swords.Include(s=>s.Samurai).Include(s=>s.Elemens).Include(s=>s.Tipes)
                .OrderBy(s => s.Id).AsNoTracking().ToListAsync();
            return results;
        }

        //getweight
        public async Task<IEnumerable<Sword>> GetByWeight()
        {
            var results = await _context.Swords.OrderBy(s => s.Weight).ToListAsync();
            return results;

        }
        //getById
        public async Task<Sword> GetById(int id)
        {
            var result = await _context.Swords.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data sword dengan id {id} tidak ditemukan");
            return result;
        }

        //getbyname
        public async Task<IEnumerable<Sword>> GetByName(string name)
        {
            var swords = _context.Swords.Where(s => s.Name.Contains(name.ToLower())).OrderBy(s => s.Name).ToList();
            return swords;
        
        }
        //insert
        public async Task<Sword> Insert(Sword obj)
        {
            try
            {

                _context.Swords.Add(obj);

                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        //update
        public async Task<Sword> Update(Sword obj)
        {
            try
            {
                var updateSword = await _context.Swords.FirstOrDefaultAsync(s => s.Id == obj.Id);
                if (updateSword == null) throw new Exception($"data Sword dengan id {obj.Id}tidak ditemukan");
                updateSword.Name = obj.Name;
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        //delete
        public async Task Delete(int id)
        {
            try
            {
                var deleteSword = await _context.Swords.FirstOrDefaultAsync(s => s.Id == id);
                if (deleteSword == null)
                    throw new Exception($"data Sword dengan id {id} tidak ditemukan");
                _context.Swords.Remove(deleteSword);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }  
        //AddSwordWithTipe
        public async Task<Sword> AddSwordWithTipe(Sword obj)
        {
            try
            {

                _context.Swords.Add(obj);

                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        //GetSwordWithTipe(PaginationParams paginationParams)
        public async Task<IEnumerable<Sword>> GetSwordWithTipe(PaginationParams paginationParams)
        {
           
             var results = _context.Swords.Include(s => s.Tipes).OrderBy(s => s.Weight)
                  .Skip((paginationParams.Page - 1) * paginationParams.ItemsPerPage)
                  .Take(paginationParams.ItemsPerPage).ToList();
              return results;
        }
        /*  var results = _context.Swords.Include(s => s.Tipes).OrderBy(s => s.Weight)
                 .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                 .Take(paginationParams.PageSize).ToList();
             return results;*/

        //AddExistingSwordInElemen
        public async Task<Sword> AddExistingSwordInElemen(Sword obj)
        {
            var updateSword = _context.Swords.Find(obj.Id);
            var elemen = _context.Elemens.Find(obj.Elemens[0].ElemenId);
            if (updateSword == null) throw new Exception($"data sword dengan id {obj.Id} tidak ditemukan");
            if (elemen == null) throw new Exception($"data elemen dengan id {obj.Elemens[0].ElemenId} tidak ditemukan");
            updateSword.Elemens.Add(elemen);
            await _context.SaveChangesAsync();
            return obj;
        }


        //DeleteElemenInSword
        public async Task<Sword> DeleteElemenInSword(int id)
        {
            try
              {
                var deleteSword = _context.Swords.FirstOrDefault(s => s.Id == id);
                if (deleteSword == null) throw new Exception($"data sword dengan id {id} tidak ditemukan");
                var elemens = _context.Elemens.Include(e => e.Swords.Where(s => s.Id == id));
                foreach( var elemen in elemens)
                {
                    deleteSword.Elemens.Remove(elemen);
                }
               // _context.Swords.Remove(deleteSword);
                await _context.SaveChangesAsync();
                return deleteSword;
            }
              catch (Exception ex)
              {
                  throw new Exception($"{ex.Message}");
              }
        } 

        //akhir
    }
}
           
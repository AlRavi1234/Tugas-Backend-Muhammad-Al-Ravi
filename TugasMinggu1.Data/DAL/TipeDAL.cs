using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasMinggu1.Domain;

namespace TugasMinggu1.Data.DAL
{
    public class TipeDAL:ITipe
    {
        private readonly SwordContext _context;
        public TipeDAL(SwordContext context)
        {
            _context = context;
        }

     
        //gettipe
        public async Task<IEnumerable<Tipe>> GetAll()
        {
            var results = await _context.Tipes.OrderBy(t => t.Name).ToListAsync();
            return results;
        }

        //getById
        public async Task<Tipe> GetById(int id)
        {
            var result = await _context.Tipes.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data tipe dengan id {id} tidak ditemukan");
            return result;
        }

        //getbyname
        public async Task<IEnumerable<Tipe>> GetByName(string name)
        {
            var tipes = _context.Tipes.Where(t => t.Name.Contains(name.ToLower())).OrderBy(t => t.Name).ToList();
            return tipes;
        }
        //insert
        public async Task<Tipe> Insert(Tipe obj)
        {
            try
            {
                
                _context.Tipes.Add(obj);
               // if (obj.SwordId != null) throw new Exception($"data tipe dengan dengan sword id {obj.SwordId} sudah ada");
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        //update
        public async Task<Tipe> Update(Tipe obj)
        {
            try
            {
                var updateTipe = await _context.Tipes.FirstOrDefaultAsync(t => t.Id == obj.Id);
                if (updateTipe == null) throw new Exception($"data tipe dengan id {obj.Id}tidak ditemukan");
                updateTipe.Name = obj.Name;
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
                var deleteTipe = await _context.Tipes.FirstOrDefaultAsync(t => t.Id == id);
                if (deleteTipe == null)
                    throw new Exception($"data tipe dengan id {id} tidak ditemukan");
                _context.Tipes.Remove(deleteTipe);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }


    }

}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasMinggu1.Domain;

namespace TugasMinggu1.Data.DAL
{
    public class ElemenDAL : IElemen
    {
        private readonly SwordContext _context;

        public ElemenDAL(SwordContext context)
        {
            _context = context;
        }
        //getall()
        public async Task<IEnumerable<Elemen>>GetAll()
        {
            var results = await _context.Elemens.OrderBy(e => e.Name).ToListAsync();
            return results;
        }
        //getById
        public async Task<Elemen> GetById(int id)
        {
            var result = await _context.Elemens.FirstOrDefaultAsync(s => s.ElemenId == id);
            if (result == null) throw new Exception($"Data Elemen dengan id {id} tidak ditemukan");
            return result;
        }

        //getbyname
        public async Task<IEnumerable<Elemen>>GetByName(string name)
        {
            var elemens = _context.Elemens.Where(e => e.Name.Contains(name.ToLower())).OrderBy(e => e.Name).ToList();
            return elemens;
        }
        //insert
        public async Task<Elemen> Insert(Elemen obj)
        {
             try
            {
                _context.Elemens.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        //update
        public async Task<Elemen> Update(Elemen obj)
        {
            try
            {
                var updateElemen = await _context.Elemens.FirstOrDefaultAsync(e => e.ElemenId == obj.ElemenId);
                if (updateElemen == null) throw new Exception($"data elemen dengan id {obj.ElemenId}tidak ditemukan");
                updateElemen.Name = obj.Name;
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
                var deleteElemen = await _context.Elemens.FirstOrDefaultAsync(e => e.ElemenId == id);
                if (deleteElemen == null)
                    throw new Exception($"data elemen dengan id {id} tidak ditemukan");
                _context.Elemens.Remove(deleteElemen);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        //AddExistingElemenInSword
        public async Task<Elemen> AddExistingElemenInSword(Elemen obj)
        {
            var updateElemen = _context.Elemens.Find(obj.ElemenId);
            var sword = _context.Swords.Find(obj.Swords[0].Id);
            if (updateElemen == null) throw new Exception($"data elemen dengan id {obj.ElemenId} tidak ditemukan");
            if (sword == null) throw new Exception($"data sword dengan id {obj.Swords[0].Id} tidak ditemukan");
            updateElemen.Swords.Add(sword);
            await _context.SaveChangesAsync();
            return obj;
        }

        //DeleteElemenInAllSword
        public async Task<Elemen> DeleteElemenInAllSword(int id)
        {
            try
            {
                var deleteElemen = _context.Elemens.FirstOrDefault(s => s.ElemenId == id);
                var swords = _context.Swords.Include(s => s.Elemens.Where(e => e.ElemenId == id));
                foreach (var sword in swords)
                {
                    deleteElemen.Swords.Remove(sword);
                }
                // _context.Swords.Remove(deleteSword);
                await _context.SaveChangesAsync();
                return deleteElemen;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        // akhir
    }
}

using Microsoft.AspNetCore.Mvc;
using TugasMinggu1.Domain;
using TugasMinggu1.DTO;
using TugasMinggu1.Helpers;
using TugasMinggu1.Models;
using TugasMinggu1.Data.DAL;
using AutoMapper;
using Microsoft.AspNetCore.Http;
namespace TugasMinggu1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TipesController : ControllerBase
    {
        private readonly ITipe _tipeDAL;
        private readonly IMapper _mapper;

        public TipesController(ITipe tipeDAL, IMapper mapper)
        {
            _tipeDAL = tipeDAL;
            _mapper = mapper;
        }
        //GetAll(byName)
        [HttpGet]
        public async Task<IEnumerable<TipeDTO>> Get()
        {

            var results = await _tipeDAL.GetAll();
            var tipeDTO = _mapper.Map<IEnumerable<TipeDTO>>(results);

            return tipeDTO;
        }
        //getbyid
        [HttpGet("{id}")]
        public async Task<TipeReadDTO> GetById(int id)
        {
            var result = await _tipeDAL.GetById(id);
            if (result == null) throw new Exception($"data {id} tidak ditemukan");
            var tipeDTO = _mapper.Map<TipeReadDTO>(result);
            return tipeDTO;
        }
        //getbyname
        [HttpGet("ByName")]

        public async Task<IEnumerable<TipeReadDTO>> GetByName(string name)
        {

            var result = await _tipeDAL.GetByName(name);
            var tipeDTO = _mapper.Map<IEnumerable<TipeReadDTO>>(result);

            return tipeDTO;
        }

        
        /*public async Task<IEnumerable<TipeReadDTO>> GetByName(string name)
        {
            List<TipeReadDTO> tipeDtos = new List<TipeReadDTO>();
            var results = await _tipeDAL.GetByName(name);
            foreach (var result in results)
            {
                tipeDtos.Add(new TipeReadDTO
                {
                    Id = result.Id,
                    Name = result.Name
                });
            }
            return tipeDtos;
        }*/

        //insert
        [HttpPost]
        public async Task<ActionResult> Post(TipeDTO tipeDto)
        {
             try
             {
                 var newTipe = _mapper.Map<Tipe>(tipeDto);
                 var result = await _tipeDAL.Insert(newTipe);

                 var tipeReadDto = _mapper.Map<TipeReadDTO>(result);

                 return CreatedAtAction("Get", new { id = result.Id }, tipeReadDto);
             
             }
             catch (Exception ex)
             {
                 return BadRequest(ex.Message);
             }
          /* try
            {
                var newTipe = new Tipe
                {
                    Name = tipeDto.Name,
                    SwordId = tipeDto.SwordId
                };
                var result = await _tipeDAL.Insert(newTipe);
                var tipeReadDto = new TipeReadDTO
                {
                    Id = result.Id,
                    Name = result.Name

                };
                return CreatedAtAction("Get", new { id = result.Id }, tipeReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }*/
        }
        //update
        [HttpPut]
        public async Task<ActionResult> Put(TipeReadDTO tipeDto)
        {
            try
            {
                var updatetipe = _mapper.Map<Tipe>(tipeDto);
                var result = await _tipeDAL.Update(updatetipe);
                return Ok(tipeDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _tipeDAL.Delete(id);
                return Ok($"data samurai dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

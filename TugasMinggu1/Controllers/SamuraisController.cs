using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TugasMinggu1.data.DAL;
using TugasMinggu1.Domain;
using TugasMinggu1.DTO;
using TugasMinggu1.Helpers;
using TugasMinggu1.Models;

namespace TugasMinggu1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraisController : ControllerBase
    {
        private readonly ISamurai _samuraiDAL;
        private readonly IMapper _mapper;

        public SamuraisController(ISamurai samuraiDAL, IMapper mapper)
        {
            _samuraiDAL = samuraiDAL;
            _mapper = mapper;
        }

        //tampil semua
        [HttpGet("WithAll")]
        //get pakai mapper
        public async Task<IEnumerable<SamuraiWithAllDTO>> GetSamuraiWithAll()
        {

            var results = await _samuraiDAL.GetSamuraiWithAll();
            var samuraiDTO = _mapper.Map<IEnumerable<SamuraiWithAllDTO>>(results);

            return samuraiDTO;
        }
        [HttpGet]
        //getsamurai
        public async Task<IEnumerable<SamuraiReadDTO>> Get()
        {

            var results = await _samuraiDAL.GetAll();
            var samuraiDTO = _mapper.Map<IEnumerable<SamuraiReadDTO>>(results);

            return samuraiDTO;
        }
        //tidak pakai mapper getnya
        /* public async Task<IEnumerable<SamuraiReadDTO>> Get()
         {
             List<SamuraiReadDTO> samuraiDTO = new List<SamuraiReadDTO>();

             var results = await _samuraiDAL.GetAll();
             foreach (var result in results)
             {
                 samuraiDTO.Add(new SamuraiReadDTO
                 {
                     Id = result.Id,
                     Name = result.Name
                 });
             }
             return samuraiDTO;
         }*/
    
        //getbyid
        [HttpGet("{id}")]
        public async Task<SamuraiReadDTO> GetById(int id)
        {
            var result = await _samuraiDAL.GetById(id);
            if (result == null) throw new Exception($"data {id} tidak ditemukan");
            var samuraiDTO = _mapper.Map<SamuraiReadDTO>(result);
            return samuraiDTO;
        }
        //getbyname
        [HttpGet("ByName")]
      
        public async Task<IEnumerable<SamuraiReadDTO>> GetByName(string name)
         {
       
            var result = await _samuraiDAL.GetByName(name);
            var samuraiDTO = _mapper.Map<IEnumerable<SamuraiReadDTO>>(result);

            return samuraiDTO;
        }
        /* public async Task<IEnumerable<SamuraiReadDTO>> GetByName(string name)
        {
            List<SamuraiReadDTO> samuraiDtos = new List<SamuraiReadDTO>();
            var results = await _samuraiDAL.GetByName(name);
            foreach (var result in results)
            {
                samuraiDtos.Add(new SamuraiReadDTO
                {
                    Id = result.Id,
                    Name = result.Name
                });
            }
            return samuraiDtos;
        }*/
        //insert
        [HttpPost]
      
        public async Task<ActionResult> Post(SamuraiCreateDTO samuraiCreateDto)
        {
            try
            {
                var newSamurai = _mapper.Map<Samurai>(samuraiCreateDto);
                var result = await _samuraiDAL.Insert(newSamurai);
                var samuraiReadDto = _mapper.Map<SamuraiReadDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id },
                    samuraiReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /* public async Task<ActionResult> Post(SamuraiCreateDTO samuraiCreateDto)
       {
           try
           {
               var newSamurai = new Samurai
               {
                   Name = samuraiCreateDto.Name
               };
               var result = await _samuraiDAL.Insert(newSamurai);
               var samuraiReadDto = new SamuraiReadDTO
               {
                   Id = result.Id,
                   Name = result.Name
               };
               return CreatedAtAction("Get", new { id = result.Id }, 
                   samuraiReadDto);
           }
           catch (Exception ex)
           {
               return BadRequest(ex.Message);
           }
       }*/
        //insertsamuraiwithsword
        [HttpPost("SamuraiWithSword")]

        public async Task<ActionResult> Post(SamuraiWithSwordDTO samuraiWithSwordDto)
        {
            try
            {
                var newSamurai = _mapper.Map<Samurai>(samuraiWithSwordDto);
                var result = await _samuraiDAL.AddSamuraiWithSword(newSamurai);
                var samuraiReadDto = _mapper.Map<SamuraiWithSwordDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id },
                    samuraiReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //update
        [HttpPut]
      
        public async Task<ActionResult> Put(SamuraiReadDTO samuraiDto)
        {
            try
            {
                var updateSamurai = _mapper.Map<Samurai>(samuraiDto);
                var result = await _samuraiDAL.Update(updateSamurai);
                return Ok(samuraiDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /* public async Task<ActionResult> Put(SamuraiReadDTO samuraiDto)
       {
           try
           {
               var updateSamurai = new Samurai
               {
                   Id = samuraiDto.id,
                   Name = samuraiDto.Name
               };
               var result = await _samuraiDAL.Update(updateSamurai);
               return Ok(samuraiDto);
           }
           catch (Exception ex)
           {
               return BadRequest(ex.Message);
           }
       }*/
        //delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _samuraiDAL.Delete(id);
                return Ok($"data samurai dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete(("SwordInSamurai"))]
        public async Task<ActionResult> DeleteSwordInSamurai(int id)
        {
            try
            {
                // var Deletesword = _mapper.Map<Sword>(swordIdDTO);
                var result = await _samuraiDAL.DeleteSwordInSamurai(id);
                return Ok($"data Sword di Samurai Id {id} berhasil di delete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //akhir
    }
}

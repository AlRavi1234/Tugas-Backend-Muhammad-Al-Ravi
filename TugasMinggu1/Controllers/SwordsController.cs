
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
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SwordsController: ControllerBase
    {
        private readonly ISword _swordDAL;
        private readonly IMapper _mapper;

        public SwordsController(ISword swordDAL, IMapper mapper)
        {
            _swordDAL = swordDAL;
            _mapper = mapper;
        }

        //GetAll()
        [HttpGet("GetAll")]
        public async Task<IEnumerable<SwordWithAll>> Get()
        {

            var results = await _swordDAL.GetAll();
            var swordDTO = _mapper.Map<IEnumerable<SwordWithAll>>(results);

            return swordDTO;
        }
        //getsword
        [HttpGet("ByWeight")]
        //get pakai mapper
        public async Task<IEnumerable<SwordReadDTO>> GetByWeight()
        {

            var results = await _swordDAL.GetByWeight();
            var swordDTO = _mapper.Map<IEnumerable<SwordReadDTO>>(results);

            return swordDTO;
        }
        //getbyid
        [HttpGet("{id}")]
        public async Task<SwordReadDTO> GetById(int id)
        {
            var result = await _swordDAL.GetById(id);
            if (result == null) throw new Exception($"data {id} tidak ditemukan");
            var swordDTO = _mapper.Map<SwordReadDTO>(result);
            return swordDTO;
        }
        //getbyname
        [HttpGet("ByName")]

        public async Task<IEnumerable<SwordReadDTO>> GetByName(string name)
        {

            var result = await _swordDAL.GetByName(name);
            var swordDTO = _mapper.Map<IEnumerable<SwordReadDTO>>(result);

            return swordDTO;
        }
     
       /* public async Task<IEnumerable<SwordReadDTO>> GetByName(string name)
        {
            List<SwordReadDTO> swordDtos = new List<SwordReadDTO>();
            var results = await _swordDAL.GetByName(name);
            foreach (var result in results)
            {
                swordDtos.Add(new SwordReadDTO
                {
                    Id = result.Id,
                    Name = result.Name,
                    Weight = result.Weight
                });
            }
            return swordDtos;
        }*/

        //insert
        [HttpPost]
        public async Task<ActionResult> Post(SwordCreateDTO swordCreateDto)
        {
            try
            {
                var newSword = _mapper.Map<Sword>(swordCreateDto);
                var result = await _swordDAL.Insert(newSword);
                var swordReadDto = _mapper.Map<SwordReadDTO>(result);
                return CreatedAtAction("Get", new { id = result.Id }, swordReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //update
        [HttpPut]
        public async Task<ActionResult> Put(SwordReadDTO swordDto)
        {
            try
            {
                var updatesword = _mapper.Map<Sword>(swordDto);
                var result = await _swordDAL.Update(updatesword);
                return Ok(swordDto);
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
                await _swordDAL.Delete(id);
                return Ok($"data Sword dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //AddSwordWithTipe
        [HttpPost("SwordWithTipe")]
        public async Task<ActionResult> Post(SwordWithTipeDTO swordWithTipeDto)
        {

            try
            {
                var newSword = _mapper.Map<Sword>(swordWithTipeDto);
                var result = await _swordDAL.AddSwordWithTipe(newSword);
                 newSword.Tipes.SwordId = result.Id;
                var swordReadDto = _mapper.Map<SwordWithTipeDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id },
                        swordReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //AddExistingSwordInElemen
        [HttpPut("AddExistingSwordInElemen")]
        public async Task<ActionResult> Put(SwordWithElemenDTO swordWithElemenDTO)
        {
            try
            {
                var updatesword = _mapper.Map<Sword>(swordWithElemenDTO);
                var result = await _swordDAL.AddExistingSwordInElemen(updatesword);
                return Ok(swordWithElemenDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("WithTipePagingRecord")]
        public async Task<ActionResult> GetSwordWithTipe([FromQuery] PaginationParams paginationParams)
        {

            var results = await _swordDAL.GetSwordWithTipe(paginationParams);
            var swordDTO = _mapper.Map<IEnumerable<SwordWithTipeReadDTO>>(results);
            return Ok(swordDTO);
        }
        [HttpDelete(("ElemenInSword"))]
        public async Task<ActionResult> DeleteElemenInSword(int id)
        {
            try
            {
               // var Deletesword = _mapper.Map<Sword>(swordIdDTO);
                var result = await _swordDAL.DeleteElemenInSword(id);
                return Ok($"data Elemen di Sword Id {id} berhasil di delete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //akhir


    }
}

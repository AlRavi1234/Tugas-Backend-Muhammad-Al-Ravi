
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
    public class ElemensController : ControllerBase
    {
        private readonly IElemen _elemenDAL;
        private readonly IMapper _mapper;

        public ElemensController(IElemen elemenDAL, IMapper mapper)
        {
            _elemenDAL = elemenDAL;
            _mapper = mapper;

        }

        //GetAll(byName)
        [HttpGet]
        public async Task<IEnumerable<ElemenIdNameDTO>> Get()
        {

            var results = await _elemenDAL.GetAll();
            var elemenDTO = _mapper.Map<IEnumerable<ElemenIdNameDTO>>(results);

            return elemenDTO;
        }
        //getbyid
        [HttpGet("{id}")]
        public async Task<ElemenIdNameDTO> GetById(int id)
        {
            var result = await _elemenDAL.GetById(id);
            if (result == null) throw new Exception($"data {id} tidak ditemukan");
            var elemenDTO = _mapper.Map<ElemenIdNameDTO>(result);
            return elemenDTO;
        }
        //getbyname
        [HttpGet("ByName")]

        public async Task<IEnumerable<ElemenIdNameDTO>> GetByName(string name)
        {

            var result = await _elemenDAL.GetByName(name);
            var elemenDTO = _mapper.Map<IEnumerable<ElemenIdNameDTO>>(result);

            return elemenDTO;
        }
       /* public async Task<IEnumerable<ElemenIdNameDTO>> GetByName(string name)
         {
             List<ElemenIdNameDTO> elemenDtos = new List<ElemenIdNameDTO>();
             var results = await _elemenDAL.GetByName(name);
             foreach (var result in results)
             {
                 elemenDtos.Add(new ElemenIdNameDTO
                 {
                     ElemenId = result.ElemenId,
                     Name = result.Name
                 });
             }
             return elemenDtos;
         }*/

        //insert
        [HttpPost]
        public async Task<ActionResult> Post(ElemenDTO elemenDto)
        {
            try
            {
               var newElemen = _mapper.Map<Elemen>(elemenDto);
               var result = await _elemenDAL.Insert(newElemen);
               var elemenIdNameDto = _mapper.Map<ElemenIdNameDTO>(result);

               return CreatedAtAction("Get", new { id = result.ElemenId }, elemenIdNameDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //update
        [HttpPut]
        public async Task<ActionResult> Put(ElemenIdNameDTO elemenIdNameDto)
        {
            try
            {
                var updateelemen = _mapper.Map<Elemen>(elemenIdNameDto);
               var result = await _elemenDAL.Update(updateelemen);
                return Ok(elemenIdNameDto);
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
                await _elemenDAL.Delete(id);
                return Ok($"data Elemen dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //AddExistingElemenInSword
        [HttpPut("AddExistingElemenInSword")]
        public async Task<ActionResult> Put(ElemenWithSwordDTO elemenWithSwordDTO)
        {


            try
            {
                var updateelemen = _mapper.Map<Elemen>(elemenWithSwordDTO);
                var result = await _elemenDAL.AddExistingElemenInSword(updateelemen);
                return Ok(elemenWithSwordDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //DeleteElemenInAllSword
        [HttpDelete(("ElemenInALlSword"))]
        public async Task<ActionResult> DeleteElemenInAllSword(int id)
        {


            try
            {
                var result = await _elemenDAL.DeleteElemenInAllSword(id);
                return Ok($"data ElemenId {id} di semua Sword berhasil di delete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

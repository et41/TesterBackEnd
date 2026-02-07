using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using TesterBackEnd.Models;
using TesterBackEnd.Models.DTOs;


namespace TesterBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckListController : ControllerBase
    {

        private readonly TesterDBContext _dbContext;
        private readonly IMapper _mapper;

        public CheckListController(TesterDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Checklist>> GetChecklists()
        {
            var checklists = _dbContext.Checklist
                                       .ToList();
            return Ok(checklists);
        }

        [HttpGet("{id}")]
        public ActionResult<ChecklistDTO> GetChecklist(int id)
        {
            var checklist = _dbContext.Checklist.Find(id);
            if (checklist == null)
            {
                return NotFound();
            }

            var checklistDto = _mapper.Map<ChecklistDTO>(checklist);
            return Ok(checklistDto);
        }

        [HttpGet("transformer/{transformerId}")]
        public ActionResult<ChecklistDTO> GetChecklistByTransformerId(int transformerId)
        {
            var checklist = _dbContext.Checklist
                .FirstOrDefault(c => c.TransformerId == transformerId);

            if (checklist == null)
            {
                return NotFound();
            }

            var checklistDto = _mapper.Map<ChecklistDTO>(checklist);
            return Ok(checklistDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChecklist(int id, ChecklistDTO checklistDto)
        {
            if (checklistDto == null)
            {
                return BadRequest("Checklist data is required");
            }

            if (id != checklistDto.Id)
            {
                return BadRequest("ID mismatch");
            }

            var checklist = await _dbContext.Checklist.FindAsync(id);
            if (checklist == null)
            {
                return NotFound();
            }

            // Map DTO to entity
            _mapper.Map(checklistDto, checklist);
            checklist.UpdatedAt = DateTime.Now;

            _dbContext.Entry(checklist).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteChecklists(int id)
        {
            var checklist = _dbContext.Checklist.Find(id);
            if (checklist == null)
            {
                return NotFound();
            }

            _dbContext.Checklist.Remove(checklist);
            _dbContext.SaveChanges();

            return NoContent();

        }


    }
}

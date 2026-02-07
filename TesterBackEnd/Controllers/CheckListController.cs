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
        private readonly ILogger<CheckListController> _logger;

        public CheckListController(TesterDBContext dbContext, IMapper mapper, ILogger<CheckListController> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
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
            _logger.LogInformation("PUT /checklist/{Id} called", id);

            if (checklistDto == null)
            {
                _logger.LogWarning("ChecklistDTO is null");
                return BadRequest("Checklist data is required");
            }

            _logger.LogInformation("Received DTO - Id: {DtoId}, TransformerId: {TransformerId}, " +
                "IncomingCoreInsulation: {IncomingCore}, WindingAssemblyInsulation: {WindingIns}, " +
                "WindingAssemblyTTR: {WindingTTR}, LidAssemblyInsulation: {LidIns}, " +
                "LidAssemblyTTR: {LidTTR}, TankAssemblyTests: {Tank}, LabTests: {Lab}",
                checklistDto.Id, checklistDto.TransformerId,
                checklistDto.IncomingCoreInsulation, checklistDto.WindingAssemblyInsulation,
                checklistDto.WindingAssemblyTTR, checklistDto.LidAssemblyInsulation,
                checklistDto.LidAssemblyTTR, checklistDto.TankAssemblyTests, checklistDto.LabTests);

            if (id != checklistDto.Id)
            {
                _logger.LogWarning("ID mismatch: route {RouteId} != body {BodyId}", id, checklistDto.Id);
                return BadRequest("ID mismatch");
            }

            var checklist = await _dbContext.Checklist.FindAsync(id);
            if (checklist == null)
            {
                _logger.LogWarning("Checklist {Id} not found in database", id);
                return NotFound();
            }

            _logger.LogInformation("Before mapping - DB values: IncomingCore={IncomingCore}, WindingIns={WindingIns}, WindingTTR={WindingTTR}",
                checklist.IncomingCoreInsulation, checklist.WindingAssemblyInsulation, checklist.WindingAssemblyTTR);

            // Map DTO to entity
            _mapper.Map(checklistDto, checklist);
            checklist.UpdatedAt = DateTime.Now;

            _logger.LogInformation("After mapping - Entity values: IncomingCore={IncomingCore}, WindingIns={WindingIns}, WindingTTR={WindingTTR}",
                checklist.IncomingCoreInsulation, checklist.WindingAssemblyInsulation, checklist.WindingAssemblyTTR);

            _dbContext.Entry(checklist).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation("Checklist {Id} saved successfully", id);

            return NoContent();
        }

        [HttpPost("backfill")]
        public async Task<IActionResult> BackfillMissingChecklists()
        {
            var transformersWithoutChecklist = await _dbContext.Transformer
                .Where(t => t.Checklist == null)
                .ToListAsync();

            if (!transformersWithoutChecklist.Any())
            {
                return Ok(new { message = "All transformers already have checklists", created = 0 });
            }

            foreach (var transformer in transformersWithoutChecklist)
            {
                _dbContext.Checklist.Add(new Checklist
                {
                    TransformerId = transformer.Id,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IncomingCoreInsulation = false,
                    WindingAssemblyInsulation = false,
                    WindingAssemblyTTR = false,
                    LidAssemblyInsulation = false,
                    LidAssemblyTTR = false,
                    TankAssemblyTests = false,
                    LabTests = false
                });
            }

            await _dbContext.SaveChangesAsync();

            _logger.LogInformation("Backfilled {Count} missing checklists", transformersWithoutChecklist.Count);
            return Ok(new { message = $"Created {transformersWithoutChecklist.Count} checklists", created = transformersWithoutChecklist.Count });
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

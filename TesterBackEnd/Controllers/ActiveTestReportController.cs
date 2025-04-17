using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesterBackEnd.Models;
using TesterBackEnd.Models.DTOs;
using AutoMapper;

namespace TesterBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActiveTestReportController : ControllerBase
    {
        private readonly TesterDBContext _dbContext;
        private readonly IMapper _mapper;

        public ActiveTestReportController(TesterDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ActiveTestReport>> GetActiveTestReports()
        {
            var activeTestReports = _dbContext.ActiveTestReport
                                      .Include(p => p.Transformer)
                                      .ToList();
            var activeTestReportDTOs = _mapper.Map<List<ActiveTestReportDTO>>(activeTestReports);
            return Ok(activeTestReportDTOs);
        }

/*

        [HttpGet("{id}")]
        public ActionResult<ActiveTestReportDTO> GetActiveTestReportById(int id)
        {
            var activeTestReport = _dbContext.ActiveTestReport
                                    .Include(p => p.Transformer)
                                    .FirstOrDefault(p => p.Id == id);
            if (activeTestReport == null)
            {
                return NotFound();
            }
            var activeTestReportDTO = _mapper.Map<ActiveTestReportDTO>(activeTestReport);
            return Ok(activeTestReportDTO);
        }
*/

        [HttpGet("{id}")]
        public ActionResult<TransformerDTO> GetTransformerById(int id)
        {
            var transformer = _dbContext.Transformer.Include(p => p.ActiveTestReports).FirstOrDefault(p => p.Id == id);
            var testReport = _dbContext.ActiveTestReport.Include(p => p.Transformer).Where(p => p.TransformerId == id).FirstOrDefault();
            if (transformer == null)
            {
                return NotFound();
            }
            var activeTestReport = _mapper.Map<ActiveTestReportDTO>(testReport);

            return Ok(activeTestReport);
        }

        [HttpPost]
        public async Task<ActionResult<ActiveTestReportDTO>> CreateActiveTestReport([FromBody] ActiveTestReportDTO activeTestReportDTO)
        {
            if(activeTestReportDTO == null)
            {
                return BadRequest("Invalid Active Test Report Data");
            }

            // Map the DTO to the entity
            var activeTestReport = _mapper.Map<ActiveTestReport>(activeTestReportDTO);

            // Add the entity to the context
            _dbContext.ActiveTestReport.Add(activeTestReport);
            await _dbContext.SaveChangesAsync();

            var createdActiveTestReportDTO = _mapper.Map<ActiveTestReportDTO>(activeTestReport);
            return Ok(createdActiveTestReportDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActiveTestReport(int id)
        {
            var activeTestReport = await _dbContext.ActiveTestReport.FindAsync(id);
            if (activeTestReport == null)
            {
                return NotFound();
            }
            _dbContext.ActiveTestReport.Remove(activeTestReport);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}

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

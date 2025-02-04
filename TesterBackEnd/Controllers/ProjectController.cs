using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesterBackEnd.Models;

namespace TesterBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly TesterDBContext _dbContext;

        public ProjectController(TesterDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Project>> GetProjects()
        {
            return _dbContext.Project.ToList();

        }

        [HttpGet("{id}")]
        public ActionResult<Project> GetProjectById(int id)
        {
            var project = _dbContext.Project.Find(id);
            if (project == null)
            { 
                return NotFound();
            }
            return project;
        }

        [HttpPost]
        public ActionResult<Project> CreateProject(Project project)
        {
            if (project == null) 
            {
                return BadRequest();
            }
            _dbContext.Project.Add(project);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetProjectById), new { id = project.Id }, project);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProject(int id) 
        {

            var project = _dbContext.Project.Find(id);
            if (project == null) 
            { 
                return NotFound();
            }

            _dbContext.Project.Remove(project);
            _dbContext.SaveChanges();

            return NoContent();
        
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutProject(int id, Project updatedProject) 
        {
            if ( id != updatedProject.Id)
            {
                return BadRequest("Project ID mismatch");
            }

            var existingProject = await _dbContext.Project.FirstOrDefaultAsync(p => p.Id == id);
             
            if (existingProject == null) 
            {
                return NotFound();
            }

            _dbContext.Entry(existingProject).CurrentValues.SetValues(updatedProject);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();


        }

        
        
        




    }
}

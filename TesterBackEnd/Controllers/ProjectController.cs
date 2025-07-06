using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using TesterBackEnd.Models;
using TesterBackEnd.Models.DTOs;

namespace TesterBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly TesterDBContext _dbContext;
        private readonly IMapper _mapper;

        public ProjectController(TesterDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProjectDTO>> GetProjects()
        {
            var projects = _dbContext.Project
                                      .Include(p => p.Transformers)
                                      .ToList();
            var projectDTOs = _mapper.Map<List<ProjectDTO>>(projects);
            return Ok(projectDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<ProjectDTO> GetProjectById(int id)
        {
            var project = _dbContext.Project
                                    .Include(p => p.Transformers)
                                    .FirstOrDefault(p => p.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            var projectDTO = _mapper.Map<ProjectDTO>(project);
            return Ok(projectDTO);
        }
        private string GenerateSerialNumber(int projectId, int index)
        {
            return $"{projectId:D6} - {index:D2}";
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDTO>> CreateProject([FromBody] ProjectDTO projectDTO)
        {
            if (projectDTO == null)
            {
                return BadRequest("Invalid Project Data");
            }

            // Map the DTO to the entity
            var project = _mapper.Map<Project>(projectDTO);
            project.CreatedAt = DateTime.Now;
            project.UpdatedAt = DateTime.Now;

            project.Transformers = new List<Transformer>();
            for (int i=0; i < project.Pieces; i++)
            {
                var transformer = new Transformer
                {
                    SerialNumber = GenerateSerialNumber(projectDTO.ProjectId, i + 1),
                    Project = project,
                    Checklist = new Checklist
                    {
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        IncomingCoreInsulation = false,
                        WindingAssemblyInsulation = false,
                        WindingAssemblyTTR = false,
                        LidAssemblyInsulation = false,
                        LidAssemblyTTR = false,
                        TankAssemblyTests = false,
                        LabTests = false
                    }
                };
                project.Transformers.Add(transformer);
            }

            // Set the ProjectId for the transformers
            foreach (var transformer in project.Transformers)
            {
                transformer.ProjectId = project.Id;
            }

            _dbContext.Project.Add(project);
            await _dbContext.SaveChangesAsync();

            // Return the DTO version of the created project
            var createdProjectDTO = _mapper.Map<ProjectDTO>(project);
            return CreatedAtAction(nameof(GetProjectById), new { id = project.Id }, createdProjectDTO);
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
        public async Task<IActionResult> UpdateProject(int id, ProjectDTO projectDTO)
        {
            var project = await _dbContext.Project
                .Include(p => p.Transformers)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            // Use AutoMapper to map the properties from DTO to entity
            _mapper.Map(projectDTO, project);

            // Mark the entity as modified to ensure changes are tracked
            _dbContext.Entry(project).State = EntityState.Modified;

            // Handle transformer records manually since they have special logic
            if (project.Transformers.Count > projectDTO.Pieces)
            {
                var extraTransformers = project.Transformers
                    .OrderByDescending(t => t.Id)
                    .Take(project.Transformers.Count - projectDTO.Pieces);

                _dbContext.Transformer.RemoveRange(extraTransformers);
            }
            else if (project.Transformers.Count < projectDTO.Pieces)
            {
                int newCount = projectDTO.Pieces - project.Transformers.Count;
                for (int i = 0; i < newCount; i++)
                {
                    project.Transformers.Add(new Transformer
                    {
                        SerialNumber = GenerateSerialNumber(project.ProjectId, project.Transformers.Count + 1),
                        Project = project,
                    });
                }
            }

            await _dbContext.SaveChangesAsync();
            return NoContent();
        }




    }
}

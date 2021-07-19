using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TaskTracker.DAL;
using TaskTracker.DAL.Models;
using TaskTracker.DAL.Repositories;

namespace TaskTracker.Controllers
{
    [RoutePrefix("project")]
    public class ProjectsController : BaseController
    {
        IProjectRepository _projectRepo;

        public ProjectsController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _projectRepo = UnitOfWork.GetProjectRepo();
        }

        /// <summary>
        /// Get a project by Id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{projectId:int}")]
        public async Task<IHttpActionResult> GetProjectByIdAsync(int projectId)
        {
            Project project = await _projectRepo.SelectByIdAsync(projectId);
            return project == null ? NotFound() : (IHttpActionResult)Ok(project);
        }

        /// <summary>
        /// Get all projects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get_list")]
        public async Task<IHttpActionResult> GetProjectListAsync()
        {
            IEnumerable<Project> projectList = await _projectRepo.SelectAllAsync();
            return projectList.Count() == 0 ? NotFound() : (IHttpActionResult)Ok(projectList);
        }

        /// <summary>
        /// Create a new project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public async Task<IHttpActionResult> CreateProjectAsync([FromBody]Project project)
        {
            Project p = await _projectRepo.SelectByIdAsync(project.Id);
            if (p != null)
            {
                return Conflict();
            }
            else
            {
                _projectRepo.Insert(project);
                await UnitOfWork.SaveAsync();
                return Ok(project);
            }
        }

        /// <summary>
        /// Edit a project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("edit")]
        public async Task<IHttpActionResult> EditProjectAsync([FromBody]Project project)
        {
            Project p = await _projectRepo.SelectByIdAsync(project.Id);
            if (p == null)
            {
                return NotFound();
            }
            else
            {
                _projectRepo.Update(project);
                await UnitOfWork.SaveAsync();
                return Ok(project);
            }
        }

        /// <summary>
        /// Delete a project by Id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("delete/{projectId:int}")]
        public async Task<IHttpActionResult> DeleteProjectAsync(int projectId)
        {
            Project p = await _projectRepo.SelectByIdAsync(projectId);
            if (p == null)
            {
                return NotFound();
            }
            else
            {
                _projectRepo.Delete(p);
                await UnitOfWork.SaveAsync();
                return Ok();
            }
        }


    }
}

using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TaskTracker.DAL;
using TaskTracker.DAL.Models;
using TaskTracker.DAL.Repositories;
using System.Threading.Tasks;

namespace TaskTracker.Controllers
{
    [RoutePrefix("task")]
    public class TasksController : BaseController
    {
        private ITaskRepository _taskRepo;

        public TasksController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _taskRepo = UnitOfWork.GetTaskRepo();
        }

        /// <summary>
        /// Get a task by Id
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{taskId:int}")]
        // [SwaggerResponse(HttpStatusCode.OK)]
        public async System.Threading.Tasks.Task<IHttpActionResult> GetTaskByIdAsync(int taskId)
        {
            DAL.Models.Task t = await _taskRepo.SelectByIdAsync(taskId);
            return t == null ? NotFound() : (IHttpActionResult)Ok(t);
        }

        /// <summary>
        /// Get all tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get_list")]
        // [SwaggerResponse(HttpStatusCode.OK)]
        public async System.Threading.Tasks.Task<IHttpActionResult> GetTaskListAsync()
        {
            IEnumerable<DAL.Models.Task> taskList = await _taskRepo.SelectAllAsync();
            return taskList.Count() == 0 ? NotFound() : (IHttpActionResult)Ok(taskList);
        }

        /// <summary>
        /// Get all tasks from concrete project
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get_list_from_project/{projectId:int}")]
        // [SwaggerResponse(HttpStatusCode.OK)]
        public async System.Threading.Tasks.Task<IHttpActionResult> GetTaskListFromProjectAsync(int projectId)
        {
            IEnumerable<DAL.Models.Task> taskListFromProject = await _taskRepo.SelectAllFromProjectAsync(projectId);
            return taskListFromProject.Count() == 0 ? NotFound() : (IHttpActionResult)Ok(taskListFromProject);
        }

        /// <summary>
        /// Create a new task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        //[SwaggerResponse(HttpStatusCode.OK)]
        public async System.Threading.Tasks.Task<IHttpActionResult> CreateTaskAsync([FromBody]DAL.Models.Task task)
        {
            DAL.Models.Task t = await _taskRepo.SelectByIdAsync(task.Id);
            if (t != null)
            {
                return Conflict();
            }
            else
            {
                _taskRepo.Insert(task);
                await UnitOfWork.SaveAsync();
                return Ok(task);
            }
        }

        /// <summary>
        /// Edit a task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("edit")]
        //[SwaggerResponse(HttpStatusCode.OK)]
        public async System.Threading.Tasks.Task<IHttpActionResult> EditTaskAsync([FromBody]DAL.Models.Task task)
        {
            DAL.Models.Task t = await _taskRepo.SelectByIdAsync(task.Id);
            if (t == null)
            {
                return NotFound();
            }
            else
            {
                _taskRepo.Update(task);
                await UnitOfWork.SaveAsync();
                return Ok(task);
            }
        }

        /// <summary>
        /// Delete a task by Id
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("delete/{taskId:int}")]
        // [SwaggerResponse(HttpStatusCode.OK)]
        public async System.Threading.Tasks.Task<IHttpActionResult> DeleteTaskAsync(int taskId)
        {
            DAL.Models.Task t = await _taskRepo.SelectByIdAsync(taskId);
            if (t == null)
            {
                return NotFound();
            }
            else
            {
                _taskRepo.Delete(t);
                await UnitOfWork.SaveAsync();
                return Ok();
            }
        }

    }
}
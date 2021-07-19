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
    [RoutePrefix("user")]
    public class UsersController : BaseController
    {
        IUserRepository _userRepo;

        public UsersController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _userRepo = UnitOfWork.GetUserRepo();
        }

        /// <summary>
        /// Get an user by Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{userId:int}")]
        public async Task<IHttpActionResult> GetUserAsync(int userId)
        {
            User u = await _userRepo.SelectByIdAsync(userId);
            return u == null ? NotFound() : (IHttpActionResult)Ok(u);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get_list")]
        public async Task<IHttpActionResult> GetUserListAsync()
        {
            IEnumerable<User> userList = await _userRepo.SelectAllAsync();
            return userList.Count() == 0 ? NotFound() : (IHttpActionResult)Ok(userList);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public async Task<IHttpActionResult> CreateUserAsync([FromBody]User user)
        {
            User u = await _userRepo.SelectByIdAsync(user.Id);
            if(u != null)
            {
                return Conflict();
            }
            else
            {
                _userRepo.Insert(user);
                await UnitOfWork.SaveAsync();
                return Ok(user);
            }
        }

        /// <summary>
        /// Edit an user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("edit")]
        public async Task<IHttpActionResult> EditUserAsync([FromBody]User user)
        {
            User u = await _userRepo.SelectByIdAsync(user.Id);
            if (u == null)
            {
                return NotFound();
            }
            else
            {
                _userRepo.Update(user);
                await UnitOfWork.SaveAsync();
                return Ok(user);
            }
        }

        /// <summary>
        /// Delete an user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("delete/{userId:int}")]
        public async Task<IHttpActionResult> DeleteUserAsync(int userId)
        {
            User u = await _userRepo.SelectByIdAsync(userId);
            if (u == null)
            {
                return NotFound();
            }
            else
            {
                _userRepo.Delete(u);
                await UnitOfWork.SaveAsync();
                return Ok();
            }
        }
    }
}

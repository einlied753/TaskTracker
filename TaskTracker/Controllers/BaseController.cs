using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskTracker.DAL;
using TaskTracker.DAL.Repositories;
using TaskTracker.DAL.Models;
using TaskTracker.DAL.Enums;
using System.Web.Http;

namespace TaskTracker.Controllers
{
    public class BaseController : ApiController
    {
        public IUnitOfWork UnitOfWork { get; private set; }

        public BaseController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        //public IHttpActionResult Ok()
        // {
        //     var response = ResponseBase.Empty();
        //     return Content(HttpStatusCode.OK, response);
        // }


    }
}

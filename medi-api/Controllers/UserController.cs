using medi_api.dataStore;
using medi_api.models;
using medi_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace medi_api.Controllers
{
    public class UserController : ApiController
    {
        UserService objUserService = new UserService();

        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody]User user)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objUserService.GetUser(user));
        }
    }
}

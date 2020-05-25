using MusiSoft.Entities;
using MusiSoft.Services.Contract.Contract;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace MusiSoft.WebAPI.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [ResponseType(typeof(UserViewModel))]
        public IHttpActionResult GetUser()
        {
            return Ok(userService.GetUsers());
        }

        [ResponseType(typeof(UserViewModel))]
        public IHttpActionResult GetUser(int id)
        {
            var user = userService.GetUserById(id);

            if (user == null)
            {
                return Content(HttpStatusCode.BadRequest, "User doesn't exist");
            }

            return Ok(user);
        }

        [ResponseType(typeof(bool))]
        public IHttpActionResult PutUser(int id, UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return Content(HttpStatusCode.BadRequest, "Invalid content data");
            }

            if (userService.EditUser(user))
            {
                return Ok(true);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(UserViewModel))]
        public IHttpActionResult PostUser(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (userService.AddUser(user))
            {
                return Ok(user);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "User already exists");
            }
        }

        [ResponseType(typeof(bool))]
        public IHttpActionResult DeleteUser(int id)
        {
            if (userService.DeleteUser(id))
            {
                return Ok(true);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Can't delete");
            }
        }
    }
}
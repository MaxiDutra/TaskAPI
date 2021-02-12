using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesAPP.Models;

namespace NotesAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly NotesDBContext context;

        public UserController(NotesDBContext context)
        {
            this.context = context;
        }

        //GET api/controller/
        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            var users = context.Users.ToList();
            return users;
        }

        //GET api/controller/id
        [HttpGet("{id}")]
        public User GetUserById(int id)
        {
            var user = context.Users.FirstOrDefault(x => x.UserId == id);
            return user;
        }

        //POST api/controller
        [HttpPost]
        public ActionResult NewUser([FromBody] User newUser)
        {
            try
            {
                context.Users.Add(newUser);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        //PUT api/controller/id
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            if (user.UserId == id)
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = context.Users.FirstOrDefault(x => x.UserId == id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }


    }
}

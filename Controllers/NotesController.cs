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
    public class NotesController : ControllerBase
    {
        private readonly NotesDBContext context;

        public NotesController(NotesDBContext context)
        {
            this.context = context;
        }

        //GET /api/controller/
        [HttpGet]
        public IEnumerable<Note> GetNotes()
        {
            return context.Notes.ToList();
        }

        //GET /api/controller/id
        [HttpGet("{id}")]
        public Note GetNoteById(int id)
        {
            var note = context.Notes.FirstOrDefault(x => x.NotesId == id);
            return note;
        }

        //POST api/controller/
        [HttpPost]
        public ActionResult NewNote([FromBody] Note note)
        {
            try
            {
                context.Notes.Add(note);
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
        public ActionResult Put([FromBody] Note note, int id)
        {
            if (note.NotesId == id)
            {
                context.Entry(note).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //DELETE api/controller/id
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var note = context.Notes.FirstOrDefault(x => x.NotesId == id);
            if (note != null)
            {
                context.Remove(note);
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

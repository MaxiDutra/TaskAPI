using System;
using System.Collections.Generic;

#nullable disable

namespace NotesAPP.Models
{
    public partial class User
    {
        public User()
        {
            Notes = new HashSet<Note>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}

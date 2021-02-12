using System;
using System.Collections.Generic;

#nullable disable

namespace NotesAPP.Models
{
    public partial class Note
    {
        public int NotesId { get; set; }
        public string NotesName { get; set; }
        public string NoteDescription { get; set; }
        public string Tag { get; set; }
        public string NoteColor { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}

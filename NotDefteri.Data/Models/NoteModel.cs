using NotDefteri.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotDefteri.Data.Models
{
    public class NoteModel : Model
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }

        public virtual CategoryModel CategoryModel { get; set; }
    }
}

using NotDefteri.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotDefteri.Data.Models
{
    public class LikeModel : Model
    {
        public int UserId { get; set; }

        public int NoteId { get; set; }
    }
}

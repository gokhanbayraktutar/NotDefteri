using NotDefteri.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotDefteri.Data.Entities
{
    public class Like : Entity
    {
        public int UserId { get; set; }

        public int NoteId { get; set; }
    }
}

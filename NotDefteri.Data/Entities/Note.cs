using NotDefteri.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotDefteri.Data.Entities
{
    public class Note : Entity
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }

        public virtual Category Category { get; set; }

        public virtual User User { get; set; }

        public int CategoryId { get; set; }


    }
}

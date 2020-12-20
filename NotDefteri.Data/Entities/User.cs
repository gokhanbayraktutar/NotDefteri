using NotDefteri.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotDefteri.Data.Entities
{
    public class User : Entity
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}

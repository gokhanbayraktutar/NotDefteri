using NotDefteri.Data.Models.Base;
using System.Collections.Generic;

namespace NotDefteri.Data.Models
{
    public class UserModel : Model
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<NoteModel> NoteModels { get; set; }
    }
}

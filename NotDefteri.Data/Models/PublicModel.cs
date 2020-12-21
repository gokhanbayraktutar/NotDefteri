using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotDefteri.Data.Models
{
    public class PublicModel
    {
        public IPagedList<NoteModel> NoteModels { get; set; }

        public NoteModel NoteModel { get; set; }
    }
}

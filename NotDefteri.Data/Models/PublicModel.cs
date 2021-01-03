using System.Collections.Generic;

namespace NotDefteri.Data.Models
{
    public class PublicModel
    {
        public List<NoteModel> NoteModels { get; set; }

        public NoteModel NoteModel { get; set; }

        public List<CategoryModel> CategoryModels { get; set; }
    }
}

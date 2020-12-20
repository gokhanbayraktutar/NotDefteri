using NotDefteri.Abstraction.IRepository.Base;
using NotDefteri.Data.Entities;
using NotDefteri.Data.Models;

namespace NotDefteri.Abstraction.IRepository
{
    public interface INoteService : IService<Note, NoteModel>
    {
    }
}

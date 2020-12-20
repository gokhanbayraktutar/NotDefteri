using NotDefteri.Abstraction.IRepository;
using NotDefteri.Data.Context;
using NotDefteri.Data.Entities;
using NotDefteri.Data.Models;
using NotDefteri.Service.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotDefteri.Service.Repository
{
    public class NoteService : Service<Note, NoteModel>, INoteService
    {
        private DataContext _context;

        public NoteService(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}

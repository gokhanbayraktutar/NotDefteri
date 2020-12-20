using NotDefteri.Abstraction.IRepository;
using NotDefteri.Data.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NotDefteri.Web.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        public ActionResult Index()
        {
            List<NoteModel> noteModels = _noteService.GetAll(); 

            return View(noteModels);
        }
    }
}
using NotDefteri.Abstraction.IRepository;
using NotDefteri.Data.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;

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
            IPagedList<NoteModel> noteModels = _noteService.GetAll().ToPagedList(1, 10);

            return View(noteModels);
        }

        public ActionResult Page(int pg)
        {
            IPagedList<NoteModel> noteModels = _noteService.GetAll().ToPagedList(pg, 10);

            return View("Index", noteModels); ;
        }
    }
}
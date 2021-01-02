using NotDefteri.Abstraction.IRepository;
using NotDefteri.Data.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace NotDefteri.Web.Controllers
{
    public class NoteController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly INoteService _noteService;
        private readonly IUserService _userService;

        public NoteController(ICategoryService categoryService, INoteService noteService, IUserService userService)
        {
            _categoryService = categoryService;
            _noteService = noteService;
            _userService = userService;
        }
        PublicModel model = new PublicModel();

        public ActionResult Index()
        {
            UserModel userModel = _userService.GetAll().FirstOrDefault(x => x.UserName == User.Identity.Name);

            if (userModel != null)
            {
                model.NoteModels = _noteService.GetAll().Where(x => x.UserId == userModel.Id).OrderByDescending(x => x.Date).ToList();

                var categoryModels = _categoryService.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

                ViewBag.categories = categoryModels;

                return View(model);
            }
            else
            {
                //ViewBag.User = false;
                model.NoteModels = _noteService.GetAll().ToList();

                var categoryModels = _categoryService.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

                ViewBag.categories = categoryModels;

                return View(model);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NoteAdd(string title, string content, int categoryid)
        {
            UserModel userModel = _userService.GetAll().FirstOrDefault(x => x.UserName == User.Identity.Name);

            if (userModel != null)
            {
                NoteModel note = new NoteModel();

                note.Title = title;

                note.Content = content;

                note.CategoryId = categoryid;

                note.Date = DateTime.Now;

                note.UserId = userModel.Id;

                _noteService.Add(note);

                return Json("");
            }

            else
            {
                return Json("");
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NoteUpdate(int id)
        {
            var note = _noteService.GetAll().FirstOrDefault(x => x.Id == id);

            var categoryModels = _categoryService.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            ViewBag.categories = categoryModels;


            return PartialView("_UpdateNote", note);
        }

        [HttpPost]
        public ActionResult NoteEdit(int id, string title, string content, int categoryid)
        {
            var noteList = _noteService.GetAll();

            var note = noteList.FirstOrDefault(x => x.Id == id);

            UserModel userModel = _userService.GetAll().FirstOrDefault(x => x.UserName == User.Identity.Name);

            note.Title = title;

            note.Content = content;

            note.CategoryId = categoryid;

            note.Date = DateTime.Now;

            note.UserId = userModel.Id;

            _noteService.Update(note);

            return PartialView("_Tablo", noteList);

        }


        [HttpPost]
        public ActionResult NoteRemove(int id)
        {
            bool result = false;

            NoteModel note = _noteService.GetAll().FirstOrDefault(x => x.Id == id);

            if(note != null)
            {
                _noteService.Remove(note.Id);

                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}
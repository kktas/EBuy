using Microsoft.AspNetCore.Mvc;
using EBuyAPI_DTO.User;
using EBuy.Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EBuy.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IEBuyApiService _ebuyApiService;

        public UserController(IEBuyApiService ebuyApiService)
        {
            _ebuyApiService = ebuyApiService;
        }
        // GET: User
        public async Task<IActionResult> Index()
        {
            var result = await _ebuyApiService.Get<List<UserDTO>>("user");
            var selectLists = new List<SelectList>
            {
                    new(new List<SelectListItem>()
                {
                    new("Option1", "Option1"),
                    new("Option2", "Option2"),
                    new("Option3", "Option3"),
                    new("Option4", "Option4"),
                    new("Option5", "Option5"),
                })
            };

            PageIndex<List<UserDTO>> page = new()
            {
                Data = result ?? new List<UserDTO>(),
                View = new()
                {
                    Title = "Users",
                    Breadcrumbs = new List<BreadcrumbItem>(){
                        new(){Text = "Admin", Url = "https://www.google.com" },
                        new(){Text = "User"},
                    },
                    SelectLists = selectLists,
                },
                Search = new Dictionary<string, dynamic>(),
            };
            return View(page);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
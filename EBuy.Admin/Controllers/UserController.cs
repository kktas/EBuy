using Microsoft.AspNetCore.Mvc;
using EBuyAPI_DTO.User;
using EBuy.Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

namespace EBuy.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IEBuyApiService _ebuyApiService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IEBuyApiService ebuyApiService, IHttpContextAccessor httpContextAccessor)
        {
            _ebuyApiService = ebuyApiService;
            _httpContextAccessor = httpContextAccessor;
        }
        // GET: User
        public async Task<IActionResult> Index(string? business_id, string? full_name, int? pn, int? ps)
        {
            string apiUrl = $"user?business_id={business_id}&full_name={full_name}&pn={pn}&ps={ps}";

            var result = await _ebuyApiService.Get<List<UserDTO>>(apiUrl);
            var selectLists = new List<SelectList>
            {
                    new(new List<SelectListItem>()
                {
                    new("Option0", "0"),
                    new("Option1", "1"),
                    new("Option2", "2"),
                    new("Option3", "3"),
                    new("Option4", "4"),
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
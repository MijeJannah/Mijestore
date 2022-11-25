using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Mije.Data;
using Mije.DataAccess.Repository.IRepository;
using Mije.Models;

namespace Mijestore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _db;
        public CoverTypeController(IUnitOfWork db)
        {
            _db = db;
        }
        public IActionResult Tampilan()
        {
            IEnumerable<CoverType> objCoverTypeList = _db.CoverType.GetAll();
            return View(objCoverTypeList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _db.CoverType.Add(obj);
                _db.Save();
                TempData["success"] = "Berhasil Menambahkan Data";
                return RedirectToAction("Tampilan");
            }
            return View(obj);

        }
        // GET EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var getedit = _db.CoverType.GetFirstorDefault(u => u.Id == id);
            if (getedit == null)
            {
                return NotFound();
            }
            return View(getedit);
        }
        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _db.CoverType.update(obj);
                _db.Save();
                TempData["success"] = "Berhasil Edit Data";
                return RedirectToAction("Tampilan");
            }
            return View(obj);

        }
        // GET DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var getedit = _db.CoverType.GetFirstorDefault(u => u.Id == id);
            if (getedit == null)
            {
                return NotFound();
            }
            return View(getedit);
        }
        //POST DELETE
        [HttpPost, ActionName("Delete")]
        //[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.CoverType.GetFirstorDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.CoverType.Remove(obj);
            _db.Save();
            TempData["success"] = "Berhasil Dihapus";
            return RedirectToAction("Tampilan");


        }
    }
}

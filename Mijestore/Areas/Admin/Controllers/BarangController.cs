using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Mije.Data;
using Mije.DataAccess.Repository.IRepository;
using Mije.Models;

namespace Mijestore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BarangController : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly IWebHostEnvironment _hostEnvironment;
        public BarangController(IUnitOfWork db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Tampilan()
        {
            //IEnumerable<Barang> objCoverTypeList = _db.Barang.GetAll();
            //return View(objCoverTypeList);
            return View();
        }
        public IActionResult Create(int? id)
        {
            Barang barang = new();
            IEnumerable<SelectListItem> PordukList = _db.Produk.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }
                );

            ViewBag.ProdukList = PordukList;
            if (id==null || id==0)
            {
                return View(barang);
            }
            else
            {
              barang = _db.Barang.GetFirstorDefault(u => u.Id == id);
                return View(barang);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Barang obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if(file!=null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads =Path.Combine(wwwRootPath, @"images\barangs");
                    var extention = Path.GetExtension(file.FileName);

                    if(obj.photo != null)
                    {
                        var oldphoto = Path.Combine(wwwRootPath, obj.photo.TrimStart('\\'));
                        if(System.IO.File.Exists(oldphoto))
                        {
                            System.IO.File.Delete(oldphoto);
                        }
                    }

                    using(var fileStreams = new FileStream(Path.Combine(uploads, fileName+extention), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.photo= @"\images\barangs\" + fileName + extention;
                }
                if(obj.Id == 0)
                {
                    _db.Barang.Add(obj);
                }
                else
                {
                    _db.Barang.update(obj);
                }
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
   
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var barangList = _db.Barang.GetAll(includeProperties:"Produk");
            return Json(new {data = barangList});
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _db.Barang.GetFirstorDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }

            var oldphoto = Path.Combine(_hostEnvironment.WebRootPath, obj.photo.TrimStart('\\'));
            if (System.IO.File.Exists(oldphoto))
            {
                System.IO.File.Delete(oldphoto);
            }
            _db.Barang.Remove(obj);
            _db.Save();
            return Json(new { success = true, message = "Delete Successful" });


        }

        #endregion
    }

}

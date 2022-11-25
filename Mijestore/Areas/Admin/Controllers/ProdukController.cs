using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Mije.Data;
using Mije.DataAccess.Repository.IRepository;
using Mije.Models;

namespace Mijestore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProdukController : Controller
    {
        //private readonly IProdukRespository _produk;
        //public ProdukController (IProdukRespository produk)
        private readonly IUnitOfWork _produk;
        public ProdukController(IUnitOfWork produk)
        {
            _produk = produk;
        }
        public IActionResult Tampilan()
        {
            IEnumerable<Produk> objProdukList = _produk.Produk.GetAll();
            return View(objProdukList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produk obj)
        {
            if (obj.Name == obj.Stock.ToString())
            {
                ModelState.AddModelError("CustomError", "Nama produk dan jumlah stock sama");
            }
            if (ModelState.IsValid)
            {
                _produk.Produk.Add(obj);
                _produk.Save();
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
            //var getedit = _produk.produks.Find(id);
            var getedit = _produk.Produk.GetFirstorDefault(u => u.Id == id);
            if (getedit == null)
            {
                return NotFound();
            }
            return View(getedit);
        }
        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Produk obj)
        {
            if (obj.Name == obj.Stock.ToString())
            {
                ModelState.AddModelError("CustomError", "Nama produk dan jumlah stock sama");
            }
            if (ModelState.IsValid)
            {
                _produk.Produk.update(obj);
                _produk.Save();
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
            //var getedit = _produk.produks.Find(id);
            var getedit = _produk.Produk.GetFirstorDefault(u => u.Id == id);
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
            var obj = _produk.Produk.GetFirstorDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _produk.Produk.Remove(obj);
            _produk.Save();
            TempData["success"] = "Berhasil Dihapus";
            return RedirectToAction("Tampilan");


        }
    }
}

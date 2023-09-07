using BW5_ExamenFinalReprise.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using TP2.Models;
using TP2.Models.Data;
using TP2.Services;
using TP2.Utility;
using TP2.ViewModels;

namespace TP2.Controllers
{
    public class ParentsController : Controller
    {

        //private TPDbContext _baseDonnees { get; set; }


        private IParentServices _serviceP;
        private IEnfantServices _serviceE;

        ////public ParentsController(TPDbContext baseDonnees)
        //{
        //    _baseDonnees = baseDonnees;
        //}

        public ParentsController(IParentServices serviceP, IEnfantServices serviceE)
        {
           _serviceP = serviceP;
            _serviceE = serviceE;
            //_baseDonnees = baseDonnees;

        }

        // GET: ParentsControllers
        public async Task<IActionResult> Index()
        {
            //List<Parent> parentsList = await _baseDonnees.Parents.ToListAsync();
            List<Parent> parentsList = (List<Parent>) await _serviceP.GetAllAsync();

            return View(parentsList);
        }

        // GET: ParentsControllers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //var parentsDetails = _baseDonnees.Enfants.Where(x => x.IdParent == id);
            //ParentVM parentVM = new()
            //{
            //    parent = new(),
            //    EnfantList = parentsDetails.ToList(),
            //    EnfantCount = parentsDetails.Count()
            //};

            //parentVM.parent = await _baseDonnees.Parents.FirstOrDefaultAsync(z => z.Id == id);
            //return View(parentVM);

            var enfant = await _serviceE.GetAllByParentAsync(id);

            ParentVM parentVm = new()
            {
                parent = new(),
                EnfantList = enfant,
                EnfantCount = enfant.Count(),
              
            };

            parentVm.parent = await _serviceP.GetByIdAsync(id);
            return View(parentVm);
        }

        // GET: ParentsControllers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParentsControllers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Parent parent)
        {
            //if (ModelState.IsValid)
            //{
            //    await _baseDonnees.Parents.AddAsync(parent);
            //    await _baseDonnees.SaveChangesAsync();

            //    TempData[AppConstants.Success] = $"{parent.Nom} le statut a été ajouté";
            //    return this.RedirectToAction("Index");

            //}
            //return this.View(parent);

            if (ModelState.IsValid)
            {
                await _serviceP.CreateAsync(parent);
               
                return this.RedirectToAction("Index", parent);

            }
            return this.View(parent);
        }

        // GET: ParentsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            //Parent parent = await _baseDonnees.Parents.FindAsync(id);
            //return View(parent);
            Parent? parent = await _serviceP.GetByIdAsync(id);

            return View("Edit", parent);
        }

        // POST: ParentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Parent parent)
        {
            //    if (ModelState.IsValid)
            //    {
            //        _baseDonnees.Parents.Update(parent);
            //        await _baseDonnees.SaveChangesAsync();
            //        TempData[AppConstants.Success] = $"Statut {parent.Nom} a été modifié";
            //        return this.RedirectToAction("Index", "parents");
            //    }
            //    return View(parent);
            if (ModelState.IsValid)
            {
                await _serviceP.EditAsync(parent);
                return this.RedirectToAction("Index");
            }

            return View("Edit", parent);

        }

        // GET: ParentsControllers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            //Parent? parent = await _baseDonnees.Parents.FindAsync(id);
            //if (parent == null)
            //{
            //    return View("NonTrouve", "Le statut demandé n'a pas été trouvé!");

            //}
            //return View(parent);

            Parent? parent = await _serviceP.GetByIdAsync(id);
            if (parent == null)
            {
                return NotFound();
            }

            return View("Delete", parent);
        }

        // POST: ParentsControllers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            //Parent? parent = await _baseDonnees.Parents.FindAsync(id);
            //if (parent == null)
            //{
            //    return View("NonTrouve", "Le statut demandé n'a pas été trouvé!");

            //}
            //_baseDonnees.Parents.Remove(parent);
            //await _baseDonnees.SaveChangesAsync();
            //TempData[AppConstants.Success] = $"Statut {parent.Nom} a été suprrimé";
            //return RedirectToAction("Index");
            Parent? parent = await _serviceP.GetByIdAsync(id);
            if (parent == null)
            {
                return NotFound();
            }

            await _serviceP.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}

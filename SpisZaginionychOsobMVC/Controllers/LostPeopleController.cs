using SpisZaginionychOsobMVC.Enums;
using SpisZaginionychOsobMVC.Helpers;
using SpisZaginionychOsobMVC.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SpisZaginionychOsobMVC.Controllers
{
    public class LostPeopleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public async Task<ActionResult> Index(string genderFilter)
        {
            if(genderFilter == null || genderFilter == "All")
            {
                return View(await db.LostPersons.ToListAsync());
            }else
            {
                var gender = (Genders)Enum.Parse(typeof(Genders), genderFilter);
                var filteredList = await db.LostPersons.Where(x => x.Gender == gender).ToListAsync();
                ViewBag.activeFilter = gender.ToString();
                return View(filteredList);
            }
        }
        // GET: LostPeople/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostPerson lostPerson = await db.LostPersons.FindAsync(id);
            if (lostPerson == null)
            {
                return HttpNotFound();
            }
            return View(lostPerson);
        }

        [AuthorizeWithRole(Enums.Roles.ContentEditor)]
        // GET: LostPeople/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LostPeople/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [AuthorizeWithRole(Enums.Roles.ContentEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Surname,Age,Gender,Description")] LostPerson lostPerson)
        {
            if (ModelState.IsValid)
            {
                db.LostPersons.Add(lostPerson);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(lostPerson);
        }

        [AuthorizeWithRole(Enums.Roles.ContentEditor)]
        // GET: LostPeople/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostPerson lostPerson = await db.LostPersons.FindAsync(id);
            if (lostPerson == null)
            {
                return HttpNotFound();
            }
            return View(lostPerson);
        }

        // POST: LostPeople/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [AuthorizeWithRole(Enums.Roles.ContentEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Surname,Age,Gender,Description")] LostPerson lostPerson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lostPerson).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(lostPerson);
        }

        [AuthorizeWithRole(Enums.Roles.ContentEditor)]
        // GET: LostPeople/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostPerson lostPerson = await db.LostPersons.FindAsync(id);
            if (lostPerson == null)
            {
                return HttpNotFound();
            }
            return View(lostPerson);
        }

        // POST: LostPeople/Delete/5
        [AuthorizeWithRole(Enums.Roles.ContentEditor)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LostPerson lostPerson = await db.LostPersons.FindAsync(id);
            db.LostPersons.Remove(lostPerson);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
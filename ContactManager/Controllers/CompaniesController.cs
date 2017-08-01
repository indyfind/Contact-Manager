using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactManager.Models;

namespace ContactManager.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ContactManagerContext _context;

        public CompaniesController(ContactManagerContext context)
        {
            _context = context;    
        }

        // GET: Companies
        public async Task<IActionResult> Index(string sortOrder, string companyCategory, string searchString)
        {
            // Use LINQ to get list of categories.
            IQueryable<string> categoryQuery = from c in _context.Company
                                            orderby c.Category
                                            select c.Category;

            var companies = from c in _context.Company
                         select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                companies = companies.Where(s => s.Phone.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(companyCategory))
            {
                companies = companies.Where(x => x.Category == companyCategory);
            }

            if (!String.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "Name":
                        companies = companies.OrderBy(s => s.Name);
                        break;
                    case "Address1":
                        companies = companies.OrderBy(s => s.Address1);
                        break;
                    case "Address2":
                        companies = companies.OrderBy(s => s.Address2);
                        break;
                    case "City":
                        companies = companies.OrderBy(s => s.City);
                        break;
                    case "State":
                        companies = companies.OrderBy(s => s.State);
                        break;
                    case "Zip":
                        companies = companies.OrderBy(s => s.Zip);
                        break;
                    case "Phone":
                        companies = companies.OrderBy(s => s.Phone);
                        break;
                    case "Fax":
                        companies = companies.OrderBy(s => s.Fax);
                        break;
                    case "Category":
                        companies = companies.OrderBy(s => s.Category);
                        break;
                    default:
                        companies = companies.OrderBy(s => s.Name);
                        break;
                }
            }

            var companyCategoryVM = new CompanyCategoryViewModel();
            companyCategoryVM.categories = new SelectList(await categoryQuery.Distinct().ToListAsync());
            companyCategoryVM.companies = await companies.ToListAsync();
            
            return View(companyCategoryVM);
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .SingleOrDefaultAsync(m => m.ID == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Address1,Address2,City,State,Zip,Phone,Fax,Category")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company.SingleOrDefaultAsync(m => m.ID == id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Address1,Address2,City,State,Zip,Phone,Fax,Category")] Company company)
        {
            if (id != company.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .SingleOrDefaultAsync(m => m.ID == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Company.SingleOrDefaultAsync(m => m.ID == id);
            _context.Company.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.ID == id);
        }
    }
}

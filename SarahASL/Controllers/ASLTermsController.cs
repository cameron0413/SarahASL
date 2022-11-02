using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SarahASL.Data;
using SarahASL.Models;
using SarahASL.Services.Interfaces;

namespace SarahASL.Controllers
{
    public class ASLTermsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ASLUser> _userManager;
        private readonly IVideoService _videoService;
        private readonly IDictionaryService _dictionaryService;

        public ASLTermsController(ApplicationDbContext context,
                                  UserManager<ASLUser> userManager,
                                  IVideoService videoService,
                                  IDictionaryService dictionaryService)
        {
            _context = context;
            _userManager = userManager;
            _videoService = videoService;
            _dictionaryService = dictionaryService;
        }

        // GET: ASLTerms
        public async Task<IActionResult> Index(int tagId)
        {
            string appUserId = _userManager.GetUserId(User);
            List<ASLTerm> aslTerms = new List<ASLTerm>();

            ASLUser aslUser = await _context.Users
                                            .Include(u => u.ASLTerms)
                                            .ThenInclude(a => a.Tags)
                                            .FirstOrDefaultAsync(u => u.Id == appUserId);

            if (tagId == 0)
            {
                aslTerms = aslUser.ASLTerms
                                  .OrderBy(c => c.EnglishPhrase)
                                  .ToList();
            }
            else
            {
                aslTerms = aslUser.Tags.FirstOrDefault(c => c.Id == tagId)
                                  .ASLTerms
                                  .OrderBy(a => a.EnglishPhrase)
                                  .ToList();
            }

            ViewData["TagId"] = new SelectList(aslUser.Tags, "Id", "Name");
            return View(aslTerms);
        }

        // GET: ASLTerms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ASLTerm == null)
            {
                return NotFound();
            }

            var aslTerm = await _context.ASLTerm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aslTerm == null)
            {
                return NotFound();
            }

            return View(aslTerm);
        }

        // GET: ASLTerms/Create
        public async Task<IActionResult> Create()
        {
            string appUserId = _userManager.GetUserId(User);
            ViewData["TagList"] = new MultiSelectList(await _dictionaryService.GetUserTagsAsync(appUserId), "Id", "Name");
            return View();
        }

        // POST: ASLTerms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EnglishPhrase,FileData,FileType,Created,Tags")] ASLTerm aslTerm)
        {
            ModelState.Remove("AslUserId");


            if (ModelState.IsValid)
            {
                aslTerm.AslUserId = _userManager.GetUserId(User);
                _context.Add(aslTerm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aslTerm);
        }

        // GET: ASLTerms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ASLTerm == null)
            {
                return NotFound();
            }

            var aSLTerm = await _context.ASLTerm.FindAsync(id);
            if (aSLTerm == null)
            {
                return NotFound();
            }
            return View(aSLTerm);
        }

        // POST: ASLTerms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EnglishPhrase,FileData,FileType,Created")] ASLTerm aSLTerm)
        {
            if (id != aSLTerm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aSLTerm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ASLTermExists(aSLTerm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aSLTerm);
        }

        // GET: ASLTerms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ASLTerm == null)
            {
                return NotFound();
            }

            var aSLTerm = await _context.ASLTerm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aSLTerm == null)
            {
                return NotFound();
            }

            return View(aSLTerm);
        }

        // POST: ASLTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ASLTerm == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ASLTerm' is null.");
            }
            var aSLTerm = await _context.ASLTerm.FindAsync(id);
            if (aSLTerm != null)
            {
                _context.ASLTerm.Remove(aSLTerm);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Search for ASL Terms
        [Authorize]
        public async Task<IActionResult> Search(string searchString)
        {
            string appUserId = _userManager.GetUserId(User);

            List<ASLTerm> aslTerms = new List<ASLTerm>();


            ASLUser aslUser = await _context.Users
                                      .Include(u => u.ASLTerms)
                                      .ThenInclude(a => a.Tags)
                                      .FirstOrDefaultAsync(u => u.Id == appUserId);



            if (String.IsNullOrEmpty(searchString))
            {

                aslTerms = aslUser!.ASLTerms
                                  .OrderBy(a => a.EnglishPhrase)
                                  .ToList();

            }
            else
            {
                aslTerms = aslUser!.ASLTerms
                                   .Where(c => c.EnglishPhrase!.ToLower().Contains(searchString.ToLower()))
                                   .OrderBy(c => c.EnglishPhrase)
                                   .ToList();
            }

            ViewData["TagId"] = new SelectList(await _dictionaryService.GetUserTagsAsync(appUserId), "Id", "Name");

            return View(nameof(Index), aslTerms);


        }

        private bool ASLTermExists(int id)
        {
          return _context.ASLTerm.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using QualyteamTeste.Models;

namespace QualyteamTeste.Controllers
{
    public class DocumentoesController : Controller
    {
        private readonly DbConection _context;

        public DocumentoesController(DbConection context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Document != null ?
                        View(await _context.Document.ToListAsync()) :
                        Problem("Entity set 'DbConection.Documentos'  is null.");
        }

        public ActionResult CreateSuccess(string msg)
        {
            ViewBag.Message = msg;
            return View();
        }

        public ActionResult CreateError(string msg)
        {
            ViewBag.Message = msg;
            return View();
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Document == null)
            {
                return NotFound();
            }

            var document = await _context.Document
                .FirstOrDefaultAsync(m => m.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        public IActionResult Create()
        {
            List<Models.Process> listProcess = _context.Process.ToList();
            ViewBag.Process = new SelectList(listProcess, "process", "process");
         
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Document document, IFormFile File)
        {
            List<Models.Process> listProcess = _context.Process.ToList();
            ViewBag.Process = new SelectList(listProcess, "process", "process");
         
            var extension = new Collection<string>
            {
                ".pdf",
                ".doc",
                ".docx",
                ".xls",
                ".xlsx"
            };
            var msg = "";


            if (ModelState.IsValid)
            {
                bool uniqueCode = !_context.Document.Any(x => x.Code == document.Code);
                if (!uniqueCode)
                {
                    ModelState.AddModelError("Code", "This code is already in use. ");
                    return View(document);
                }

                if (File != null)
                {
                    var fileName = document.Code + " - " + document.Title + " - " + File.FileName;
                    var fileExtension = Path.GetExtension(File.FileName);

                    if (extension.Contains(fileExtension))
                    {
                        var caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);
                        using (var stream = new FileStream(caminho, FileMode.Create))
                        {
                            await File.CopyToAsync(stream);
                        }
                        document.FilePath = caminho;
                    }
                    else
                    {
                        msg = "Error: The extension of the file is not avialiabe";
                        return RedirectToAction("CreateError", new { msg = msg });
                    }
                }


                _context.Add(document);
                await _context.SaveChangesAsync();
                msg = "Document created";
                return RedirectToAction("CreateSuccess", new { msg = msg });
            }


            if (!ModelState.IsValid)
            {
                msg = "Error: the information sent is not in the scope";
                return RedirectToAction("CreateError", new { msg = msg });
                
            }

            return View(document);
        }

        public FileResult Download(string path)
        {            
            var fileName = Path.GetFileName(path);
          
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            var mimeType = "application/octet-stream"; 
            return File(bytes, mimeType, fileName);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Document == null)
            {
                return NotFound();
            }

            var document = await _context.Document.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            return View(document);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Models.Document document, IFormFile File)
        {
            if (id != document.Id)
            {
                return NotFound();
            }
            var extensions = new Collection<string>
            {
                ".pdf",
                ".doc",
                ".docx",
                ".xls",
                ".xlsx"
            };
            var msg = "";


            if (ModelState.IsValid)
            {

                if (File != null)
                {
                    var fileName = document.Code + " - " + document.Title + " - " + File.FileName;
                    var fileExtension = Path.GetExtension(File.FileName);

                    if (extensions.Contains(fileExtension))
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await File.CopyToAsync(stream);
                        }
                        document.FilePath = filePath;
                    }
                    else
                    {
                        msg = "Error: The extension of the file is not avialiabe"; ;
                        return RedirectToAction("CreateError", new { msg = msg });
                    }
                }

                try
                {
                    _context.Update(document);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentoExists(document.Id))
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
            return View(document);
        }
      
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Document == null)
            {
                return NotFound();
            }

            var document = await _context.Document
                .FirstOrDefaultAsync(m => m.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Document == null)
            {
                return Problem("Entity set 'DbConection.Documentos'  is null.");
            }
            var document = await _context.Document.FindAsync(id);
            if (document != null)
            {
                _context.Document.Remove(document);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentoExists(int id)
        {
          return (_context.Document?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

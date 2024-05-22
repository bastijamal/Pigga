using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PiggaProject.DAL;
using PiggaProject.Models;

namespace PiggaProject.Areas.Manage.Controllers
{
    [Area("Manage")]

    public class ChefsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ChefsController(AppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            //ATTENTION  !!
            var chefs = _context.Chefs.ToList();
            return View(chefs);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Chefs chef)
        {
         
            if (!ModelState.IsValid) return View();


            if (!chef.ImgFiel.ContentType.Contains("image/")) return View(chef);

            string path = _environment.WebRootPath + @"/upload/";


            string filename = Guid.NewGuid().ToString() + chef.ImgFiel.FileName;



            using (FileStream strem = new FileStream(Path.Combine( path + filename), FileMode.Create))
            {
                await chef.ImgFiel.CopyToAsync(strem);
            }

            chef.PhotoUrl = filename;
            _context.Chefs.Add(chef);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }




        public IActionResult Update(int id)
        {

            var Chef = _context.Chefs.FirstOrDefault(x => x.Id == id);

            if (Chef == null)
            {
                return NotFound();
            }
            return View(Chef);
        }


        [HttpPost]
        public IActionResult Update(Chefs chefs)
        {
            if (!ModelState.IsValid && chefs.ImgFiel!=null)
            {
                return View();
            }



            return View();
        }




        public IActionResult Delete(int id)
        {
            var Chef = _context.Chefs.FirstOrDefault(x => x.Id == id);
            _context.Chefs.Remove(Chef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}


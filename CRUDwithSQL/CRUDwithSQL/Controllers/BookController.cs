using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDwithSQL.Data;
using CRUDwithSQL.Models;

namespace CRUDwithSQL.Controllers
{
    public class BookController : Controller
    {
       
        public BookController()
        {
            
        }

        // GET: Book
        public IActionResult Index()
        {
            return View();
        }


        // GET: Book/AddOrEdit/
        public IActionResult AddOrEdit(int? id)
        {
            BookViewModel bookViewModel = new BookViewModel();
         
            return View(bookViewModel);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, [Bind("BookID,Title,Author,Price")] BookViewModel bookViewModel)
        {
           

            if (ModelState.IsValid)
            {
             
                return RedirectToAction(nameof(Index));
            }
            return View(bookViewModel);
        }

        // GET: Book/Delete/5
        public IActionResult Delete(int? id)
        {
           

            return View();
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {    
            return RedirectToAction(nameof(Index));
        }

       
    }
}
